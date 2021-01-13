using System.Collections;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private Animator animator;

    [SerializeField] private float angleVision = 25;
    [SerializeField] private float distVision = 8;

    private bool targetKilled = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        //to test
        Vector3 guardT = transform.position + Vector3.up * 1.0f;
        Vector3 targetT = target.position + Vector3.up * 1.0f;

        float angle = Vector3.Angle(targetT - guardT, transform.forward);
        float dist = Vector3.Distance(targetT, guardT);

        //raycast to check obstacles
        Ray ray = new Ray(guardT, targetT - guardT);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (angle < angleVision && dist < distVision && hit.collider.CompareTag("Player"))
        {
            //retrive script palyer
            Player targetScript = hit.transform.gameObject.GetComponent<Player>();

            //rotation guard in y
            Quaternion rot = Quaternion.LookRotation(target.position - transform.position);
            rot.x = 0;
            rot.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.01f);

            //animations
            targetScript.ReactToGuard(transform);
            if (!targetKilled) //avoid repeating animation
                animator.SetBool("isFoundTarget", true);
            StartCoroutine(AfterAnimation());
        }
    }

    private IEnumerator AfterAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        targetKilled = true;
        animator.SetBool("isFoundTarget", false);
        //animationEvents
        //animator.SetBool("isWalking", true);
    }

}
