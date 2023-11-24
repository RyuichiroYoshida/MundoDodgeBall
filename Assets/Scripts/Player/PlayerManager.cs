using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int _hp = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            other.TryGetComponent<WeaponController>(out WeaponController controller);
            _hp -= controller.Damage;
            Debug.Log(_hp);
        }
    }
}