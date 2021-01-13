using System.Collections;
using UnityEngine;

public class JustWalk : MonoBehaviour
{
    Animator animator;
    private float speed = 5f;
    private int isWalkingHash;
    private int isFoundTargetHash;
    private CharacterController charController;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isFoundTargetHash = Animator.StringToHash("isFoundTarget");
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isFoundTarget = animator.GetBool(isFoundTargetHash);


        if (isFoundTarget)
        {
            animator.SetBool(isWalkingHash, false);
        }
        else
        {
            animator.SetBool(isWalkingHash, true);
            //transform.position += transform.forward * Time.deltaTime * speed;
            charController.Move(transform.forward * Time.deltaTime * speed);
        }
       
        

    }
    private IEnumerator LetAnimationHappen()
    {
        yield return new WaitForSeconds(0.7f);
    }
}
