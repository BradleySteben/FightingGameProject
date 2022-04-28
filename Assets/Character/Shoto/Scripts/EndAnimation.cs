using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : StateMachineBehaviour
{
    void OnStateExit(Animator animator){
        animator.SetBool("lightAttack", false);
        animator.SetBool("uniqueAttack", false);
        animator.SetBool("canAct", true);
        animator.SetBool("jump", false);
        animator.SetBool("isGrounded", true);
    }
}
