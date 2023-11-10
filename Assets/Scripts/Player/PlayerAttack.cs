using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
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
        Instantiate(_weaponPrefab, new Vector3(pos.x, pos.y, pos.z + 1), Quaternion.Euler(0, 180, 0));
    }
}
