using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [Tooltip("Rotation angle per second")]
    public float rotatingSpeed = 360f;

    void Update()
    {
        // Handle rotating
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime, Space.Self);
    }
}
