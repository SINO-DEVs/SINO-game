using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private float _rotX;
    private Vector3 _offset;
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        _rotX += Input.GetAxis("Mouse Y") * rotSpeed * -1;

        if(_rotX > 20 || _rotX < -20) {
            _rotX = _rotX > 0 ? 20 : -20;
        }

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}
