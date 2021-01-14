using UnityEngine;

public class StupidTranslation : MonoBehaviour
{
    public float speedMultiplier = 1.0f;
    public float downLimit;
    public float upLimit;

    private float direction = 1.0f;

    // Awake is called before Start
    void Awake()
    {
        // Initialize stuff here

    }

    // Start is called before the first frame update
    void Start()
    {
        // Get data from other components/gameobjects here

    }

    // Update is called once per frame
    void Update()
    {
        // transform is present in every monobehaviour and it refers to the Transform component

        // gameobject refers to object that holds this script
        if (transform.position.x < downLimit)
            direction = 1.0f;
        else if (transform.position.x > upLimit)
            direction = -1.0f;

        transform.Translate(Time.deltaTime * speedMultiplier * direction * Vector3.right, Space.Self);
    }
}
