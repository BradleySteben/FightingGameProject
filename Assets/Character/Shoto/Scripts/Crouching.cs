using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : StateMachineBehaviour
{
    void OnStateUpdate(Animator animator){

            if(Input.GetKey(KeyCode.S))
            {
                animator.SetBool("crouch", true);
            }
            else{
                 animator.SetBool("crouch", false);
            }
    }
}
