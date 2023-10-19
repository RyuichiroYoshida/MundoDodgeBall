using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float _flyingSpeed = 10;
    [SerializeField] private float _lifeTime = 5;
    [SerializeField] private float _rotateSpeed = 0.5f;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.forward * _flyingSpeed;
        transform.DOLocalRotate(new Vector3(-360, 0, 0), _rotateSpeed, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .SetLink(this.gameObject);
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(this);
    }
}