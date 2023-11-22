using UnityEngine;
using DG.Tweening;

public class WeaponController : MonoBehaviour
{
    /// <summary>武器の飛翔速度</summary>
    [SerializeField] private float _flyingSpeed = 10;
    /// <summary>武器の自動破壊時間</summary>
    [SerializeField] private float _lifeTime = 5;
    /// <summary>武器の飛翔時の回転速度</summary>
    [SerializeField] private float _rotateSpeed = 0.5f;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * _flyingSpeed;
        // X軸方向に無限回転する
        transform.DOLocalRotate(new Vector3(-360, 0, 0), _rotateSpeed, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .SetLink(this.gameObject);
        Destroy(this.gameObject, _lifeTime);
    }
    private void Update()
    {
        //_rb.AddForce(transform.forward * _flyingSpeed);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
    }
}