using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private Vector3 offset;
    private Vector3 offsetStart;

    [SerializeField] private float rotXSpeed = 3.0f;
    [SerializeField] private float rotYSpeed = 1.5f;
    [SerializeField] private float maxYAngle = 20;
    [SerializeField] private float minYAngle = -20;

    private float rotY;
    private float rotX;

    void Start()
    {
        rotY = transform.eulerAngles.y;
        rotX = transform.eulerAngles.x;
        offset = target.position - transform.position;
        offsetStart = offset;
    }

    void LateUpdate()
    {
        if (!LifeManager.Instance.Alive)
        {
            return;
        }

        rotY += Input.GetAxis("Mouse X") * rotXSpeed;
        rotX -= Input.GetAxis("Mouse Y") * rotYSpeed;

        if (rotX > maxYAngle || rotX < minYAngle)
        {
            rotX = rotX > 0 ? maxYAngle : minYAngle;
        }

        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
        transform.position = target.position - (rotation * offsetStart);

        //close distance if there is a obstacle between player and camera
        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            offset = transform.position.normalized * hit.distance;
            transform.position = target.position - (rotation * offset);
        }

        transform.LookAt(target);
    }
}
