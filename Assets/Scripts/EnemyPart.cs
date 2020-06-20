using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   private Rigidbody _rigidbody;

   private void Awake()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   public void GetShot(float bulletStrength)
   {
      _animator.enabled = false;
      _rigidbody.AddForce(Vector3.forward*bulletStrength, ForceMode.Impulse);
   }
}
