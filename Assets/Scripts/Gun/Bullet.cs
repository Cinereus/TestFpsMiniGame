using Enemy;
using ScriptableObjects;
using UnityEngine;
using Utilities.ObjectPool;

namespace Gun
{
    [RequireComponent(typeof(PoolObject))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletStats _stats;

        private bool _isCanMove;
        private float _speed;
        private float _blowStrength;
        private Vector3 _target;
        private PoolObject _poolObject;

        void Awake()
        {
            _speed = _stats.Speed;
            _blowStrength = _stats.BlowStrength;
            _poolObject = GetComponent<PoolObject>();
        }

        private void FixedUpdate()
        {
            if (!_isCanMove)
            {
                return;
            }

            var distance = Vector3.Distance(transform.position, _target);

            if (distance >= 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.timeScale);
            }
            else
            {
                _poolObject.ReturnToPool();
            }
        }

        public void Move(Vector3 position)
        {
            _target = position;
            _isCanMove = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<EnemyController>();
        
            if (enemy != null)
            {
                enemy.ActivateRagdoll();
                return;
            }
        
            var enemyPart = other.GetComponent<EnemyPart>();
        
            if (enemyPart != null)
            {
                enemyPart.GetShot(_blowStrength);
                _poolObject.ReturnToPool();
            }
        }
    }
}