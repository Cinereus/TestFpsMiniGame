using System;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private bool _slowMotionEffect;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void GetShot(float strength)
    {
        _rigidbody.AddForce(Vector3.forward * strength, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Floor") && _slowMotionEffect)
        {
            SlowMotion.StartSlowMotion();
        }
    }
}
