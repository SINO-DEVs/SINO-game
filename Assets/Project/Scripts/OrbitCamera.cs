using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotXSpeed = 3.0f;
    public float rotYSpeed = 1.5f;
    public float maxYAngle = 20;
    public float minYAngle = -20;

    private float _rotY;
    private float _rotX;
    private Vector3 _offset;
    private Vector3 _offsetStart;


    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;
        _offsetStart = _offset;
    }

    void LateUpdate()
    {
        _rotY += Input.GetAxis("Mouse X") * rotXSpeed;
        _rotX -= Input.GetAxis("Mouse Y") * rotYSpeed;

        if(_rotX > maxYAngle || _rotX < minYAngle) {
            _rotX = _rotX > 0 ? maxYAngle : minYAngle;
        }

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offsetStart);

        //close distance if there is a obstacle between player and camera
        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            _offset = transform.position.normalized * hit.distance;
            transform.position = target.position - (rotation * _offset);
        } 

        transform.LookAt(target);
    }
}
