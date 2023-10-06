using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private bool _attackInput = false;
    [SerializeField] private bool _buttonPushQ = false;

    public bool AttackInput => _attackInput;
    public bool ButtonPushQ => _buttonPushQ;
    private void Start()
    {
        
    }
    private void Update()
    {
        var current = Keyboard.current;
        if (current == null)
            return;
        var qKey = current.qKey;
        if (qKey.wasPressedThisFrame)
            _attackInput = true;
        if (qKey.wasReleasedThisFrame)
            _attackInput = false;
    }
}
