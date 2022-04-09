using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideAttackShoto : StateMachineBehaviour
{
[SerializeField]
float speed = 1.5f;

    void OnStateUpdate(GameObject gameObject){
        //Learn how to move character mid animation
    }
    void OnStateExit(Animator animator){
        animator.SetBool("uniqueAttack", false);
        animator.SetBool("canAct", true);
    }
}
