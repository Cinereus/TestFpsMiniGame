using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    
    private Camera _camera;
    private float rotationX;
    private float rotationY;
    
    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    { 
        var isButtonPressed = Input.GetMouseButtonDown(0);
        var mousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        rotationX -= mousePos.y/10f;
        rotationY += mousePos.x/10f;

        rotationX = Mathf.Clamp(rotationX, -5f, 5f);
        rotationY = Mathf.Clamp(rotationY, -5, 5f);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);

        if (isButtonPressed)
        {
            var bullet = Instantiate(_bullet).GetComponent<Bullet>();
            var position = transform.position;
            
            bullet.gameObject.SetActive(true);
            bullet.transform.position = new Vector3(position.x, position.y, position.z+0.2f);
            bullet.Move(new Vector3(mousePos.x, mousePos.y, mousePos.z));
        }
    }
}
