using UnityEngine;

public class FirstPCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;

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
        target.rotation = rotation;
    }
}
