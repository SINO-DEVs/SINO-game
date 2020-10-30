using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AnimationStateController : MonoBehaviour {
    Animator animator;
    private float distance = 20f;
    private float speed = 5f;
    private float spinSpeed = 3f;
    private float current_distance = 1f;
    private int spinCount = 0;
    private float degree = 180;
    private bool isForward = true;
    private int isWalkingHash;
    private int isFoundTargetHash;


    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isFoundTargetHash = Animator.StringToHash("isFoundTarget");
    }

    // Update is called once per frame
    void Update() {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isFoundTarget = animator.GetBool(isFoundTargetHash);


        if (isFoundTarget) {
            animator.SetBool(isWalkingHash, false);
        } else if (((int)current_distance) % distance != 0 && isWalking) {
            transform.rotation=Quaternion.LookRotation(((isForward) ? Vector3.right : Vector3.left));

            current_distance += speed * Time.deltaTime;
            animator.SetBool(isWalkingHash, true);
            transform.position += ((isForward) ? Vector3.right : Vector3.left) * Time.deltaTime * speed;
        } else {
            if (spinCount < degree / spinSpeed) {
                transform.Rotate(Vector3.up * spinSpeed);
                spinCount += 1;
            } else {
                spinCount = 0;
                current_distance = 1;
                isForward = !isForward;
            }
        }

    }
    private IEnumerator LetAnimationHappen() {
        yield return new WaitForSeconds(0.7f);
    }
}
