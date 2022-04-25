using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlock2 : StateMachineBehaviour
{
    void OnStateExit(Animator animator){
        animator.SetBool("canAct", true);
    }
}
