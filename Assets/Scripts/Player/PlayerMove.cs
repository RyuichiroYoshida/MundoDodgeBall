using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _speedLimit = 2;

    private Rigidbody _rb;
    private Playerinput _playerInput;
    private Vector2 _moveInputValue;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        // PlayerInputをインスタンス化
        _playerInput = new Playerinput();
        // MoveやJumpのメソッドをInputSystemのデリゲートに追加
        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OffMove;
        _playerInput.Player.Jump.performed += OnJump;
        _playerInput.Enable();
    }

    private void OnDestroy()
    {
        _playerInput?.Dispose();
    }
    private void FixedUpdate()
    {
        if (_rb.velocity.magnitude < _speedLimit)
            _rb.AddForce(new Vector3(_moveInputValue.x, 0, _moveInputValue.y) * _moveSpeed);
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInputValue = context.ReadValue<Vector2>();
    }
    private void OffMove(InputAction.CallbackContext context)
    {
        _moveInputValue = Vector2.zero;
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
