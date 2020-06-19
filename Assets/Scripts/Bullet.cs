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
            transform.position = Vector3.MoveTowards(transform.position, _target, 0.1f);
        }
        else
        {
            Debug.Log(distance);
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
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward*_blowStrength, ForceMode.Impulse);
            //return to pool stuff
            Destroy(gameObject);
        }
    }
}
