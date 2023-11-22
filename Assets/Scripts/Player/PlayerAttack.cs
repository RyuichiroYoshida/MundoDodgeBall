using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Transform _spawnPos;
    private Playerinput _playerinput;

    private void Awake()
    {
        // PlayerInputをインスタンス化
        _playerinput = new Playerinput();
        // 攻撃メソッドをInputSystemのデリゲートに追加
        _playerinput.Player.Attack.performed += OnAttack;
        _playerinput.Enable();
    }

    private void OnDestroy()
    {
        _playerinput?.Dispose();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        var pos = this.transform.position;
        Instantiate(_weaponPrefab, _spawnPos.position, Quaternion.Euler(0, 180, 0));
    }
}
