using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    
    private Camera _camera;
    private float _rotationX;
    private float _rotationY;
    
    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    { 
        var isButtonPressed = Input.GetMouseButtonDown(0);
        var mousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        _rotationX -= mousePos.y/10f;
        _rotationY += mousePos.x/10f;

        _rotationX = Mathf.Clamp(_rotationX, -3f, 0f);
        _rotationY = Mathf.Clamp(_rotationY, -3, 3f);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);

        if (isButtonPressed)
        {
            var bullet = Instantiate(_bullet).GetComponent<Bullet>();
            var position = transform.position;
            
            bullet.gameObject.SetActive(true);
            bullet.transform.position = new Vector3(position.x, position.y+0.06f, position.z+0.3f);
            bullet.Move(new Vector3(mousePos.x, mousePos.y, mousePos.z));
        }
    }
}
