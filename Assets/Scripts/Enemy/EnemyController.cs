using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Animator _animator;
        private Collider _activationArea;
        private Vector3 _startPosition;
        private List<Collider> _colliders;
        private List<Rigidbody> _rigidbodies;
    
        public void ActivateRagdoll()
        {
            _animator.enabled = false;
            SetRigidbodiesState(false);
            SetRagdollCollidersState(true);
        }

        public void ResetEnemy()
        {
            SlowMotion.DisableSlowMotion();
            transform.position = _startPosition;
            SetRagdollCollidersState(false);
            SetRigidbodiesState(true);
            _animator.enabled = true;
        }
    
        private void Awake()
        {
            _startPosition = transform.position;
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
}
