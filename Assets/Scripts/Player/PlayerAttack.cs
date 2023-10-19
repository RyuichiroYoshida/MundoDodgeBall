using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    private Playerinput _playerinput;

    private void Awake()
    {
        _playerinput = new Playerinput();
        _playerinput.Player.Attack.performed += OnAttack;
        _playerinput.Enable();
    }

    private void OnDestroy()
    {
        _playerinput?.Dispose();
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        Instantiate(_weaponPrefab, Vector3.forward, Quaternion.Euler(0, 180, 0));
    }
}
