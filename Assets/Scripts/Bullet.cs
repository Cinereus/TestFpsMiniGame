using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletStats _stats;

    private bool _isCanMove;
    private float _speed;
    private float _blowStrength;
    private Vector3 _target;

    void Awake()
    {
        _speed = _stats.Speed;
        _blowStrength = _stats.BlowStrength;
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
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed);
            Debug.Log(distance);
        }
        else
        {
            //replace to pool object
            Destroy(gameObject);
        }
    }

    public void Move(Vector3 position)
    {
        _target = position;
        _isCanMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.ActivateRagdoll();
        }

        if (other.CompareTag("RagdollPart"))
        {
            Debug.Log("KEK");
            var rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * _blowStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}