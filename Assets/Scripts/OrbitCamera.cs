using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotXSpeed = 4.5f;
    public float rotYSpeed = 1.5f;
    public float maxYAngle = 20;
    public float minYAngle = -20;

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
        _rotY += Input.GetAxis("Mouse X") * rotXSpeed;
        _rotX += Input.GetAxis("Mouse Y") * rotYSpeed;

        if(_rotX > maxYAngle || _rotX < minYAngle) {
            _rotX = _rotX > 0 ? maxYAngle : minYAngle;
        }

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}
