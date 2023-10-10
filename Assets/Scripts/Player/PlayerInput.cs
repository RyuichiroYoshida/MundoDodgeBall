using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputAction _action;
    private float _value = 0;
    public float Value => _value;
    private void OnEnable()
    {
        _action.performed += OnPerformed;
        _action?.Enable();
    }

    private void OnDisable()
    {
        _action.performed -= OnPerformed;
        _action?.Disable();
    }
    
    private void OnPerformed(InputAction.CallbackContext context)
    {
        _value = context.ReadValue<float>();
        print($"Action : {_value}");
    }
}
