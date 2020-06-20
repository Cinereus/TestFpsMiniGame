using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private Collider _activationArea;
    private List<Collider> _colliders;
    private List<Rigidbody> _rigidbodies;
    
    public void ActivateRagdoll()
    {
        _animator.enabled = false;
        SetRigidbodiesState(false);
        SetRagdollCollidersState(true);
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _activationArea = GetComponent<Collider>();
        _colliders = GetComponentsInChildren<Collider>().ToList();
        _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
        
        _colliders.Remove(_activationArea);
        _rigidbodies.Remove(GetComponent<Rigidbody>());
        
        SetRagdollCollidersState(false);
        SetRigidbodiesState(true);
    }

    private void SetRagdollCollidersState(bool isActive)
    {
        foreach (var ragdoll in _colliders)
        {
            ragdoll.enabled = isActive;
        }

        _activationArea.enabled = !isActive;
    }
    
    private void SetRigidbodiesState(bool isActive)
    {
        foreach (var rb in _rigidbodies)
        {
            rb.isKinematic = isActive;
        }
    }
}
