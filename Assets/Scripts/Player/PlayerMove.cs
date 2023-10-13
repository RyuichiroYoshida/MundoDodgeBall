using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _jumpForce = 5;

    private Rigidbody _rigidbody;
    private Playerinput _playerinput;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
