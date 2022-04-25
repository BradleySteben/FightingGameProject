using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation2 : StateMachineBehaviour
{
    void OnStateExit(Animator animator){
        animator.SetBool("lightAttack", false);
        animator.SetBool("uniqueAttack", false);
        animator.SetBool("canAct", true);
    }
}
