using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float _flyingSpeed = 10;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.forward * _flyingSpeed;
        Destroy(this, 3);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(this);
    }
}