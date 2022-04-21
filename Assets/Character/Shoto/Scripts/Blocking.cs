using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : StateMachineBehaviour
{

    void OnStateEnter(Animator animator)
    {
        
    }
    
    void OnStateUpdate(Animator animator){

            if(Input.GetKey(KeyCode.I))
            {
                
            }
            else{
                 animator.SetBool("block", false);
            }
    }
    

    void OnStateExit(Animator animator)
    {
        //make canAct true in pt2 of anim
        //animator.SetBool("canAct", true);
    }
}
