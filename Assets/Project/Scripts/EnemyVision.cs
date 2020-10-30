using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float angleVision = 25;
    public float distVision = 8;

    private Animator _animator;
    private bool targetKilled = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(target.position - transform.position, transform.forward);
        float dist = Vector3.Distance(target.position, transform.position);

        //raycast to check obstacles
        Ray ray = new Ray(transform.position, target.position - transform.position + Vector3.up * 0.5f);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        
        if (angle < angleVision && dist < distVision && hit.collider.CompareTag("Player"))
        {
            //retrive script palyer
            RelativeMovement targetScript = hit.transform.gameObject.GetComponent<RelativeMovement>();

            //rotation guard in y
            Quaternion rot = Quaternion.LookRotation(target.position - transform.position);
            rot.x = 0;
            rot.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.01f);

            //animations
            targetScript.reactToGuard(transform);
            if (!targetKilled) //avoid repeating animation
                _animator.SetBool("isFoundTarget", true);
            StartCoroutine(AfterAnimation());
        }   
    }

    private IEnumerator AfterAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        targetKilled = true;
        _animator.SetBool("isFoundTarget", false);
        _animator.SetBool("isWalking", true);
    }

}
