using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputAction _action;

    private void OnEnable()
    {
        _action?.Enable();
    }

    private void OnDisable()
    {
        _action?.Disable();
    }
    
    private void Update()
    {
        if (_action == null)
            return;
        var value = _action.ReadValue<float>();
        print($"Actionの入力値 {value}");
    }
}
