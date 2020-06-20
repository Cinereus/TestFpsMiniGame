using UnityEngine;
using Utilities.ObjectPool;

namespace Gun
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _shootRange = 10f;
    
        private Camera _camera;
        private Pool _bulletPool;
        private float _rotationX;
        private float _rotationY;

        private const int BULLET_POOL_SIZE = 100;
        private const float ROTATION_OFFSET = 3f;
    
        private void Awake()
        {
            _camera = Camera.main;
            _bulletPool = Pool.CreatePool(_bullet, BULLET_POOL_SIZE);
        }
    
        private void Update()
        { 
            var isButtonPressed = Input.GetMouseButtonDown(0);
            var mousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _shootRange));

            _rotationX -= mousePos.y/10f;
            _rotationY += mousePos.x/10f;

            _rotationX = Mathf.Clamp(_rotationX, -ROTATION_OFFSET, 0f);
            _rotationY = Mathf.Clamp(_rotationY, -ROTATION_OFFSET, ROTATION_OFFSET);

            transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);

            if (isButtonPressed)
            {
                var position = transform.position;
                var bullet = _bulletPool.GetObject().GetComponent<Bullet>();
            
                bullet.gameObject.SetActive(true);
                bullet.transform.position = new Vector3(position.x, position.y+0.06f, position.z+0.3f);
                bullet.Move(new Vector3(mousePos.x, mousePos.y, mousePos.z));
            }
        }
    }
}
