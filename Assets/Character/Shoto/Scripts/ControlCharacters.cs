using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacters : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb2d;

    //Key to denying other moves or other stuff

    [SerializeField]
    float speed = 3.0f;

    [SerializeField]
    float jump = 2.0f;

    [SerializeField]
    float tatsu = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("canAct")){

            if(Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("input", 3);

                if(animator.GetBool("isGrounded"))
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("crouch", true);
                }
            }
            else
            {
                 animator.SetBool("crouch", false);
            }

            if(!animator.GetBool("crouch"))
            {

                if(Input.GetKeyDown(KeyCode.W))
            {
                animator.SetInteger("input", 1);

                if(animator.GetBool("isGrounded")){
                    Jump();
                }
            }
                
                if(Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("isWalking", true);
                    animator.SetInteger("input", 2);
                    
                    transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;
                }

                if(Input.GetKey(KeyCode.A))
                {
                    animator.SetBool("isWalking", true);
                    animator.SetInteger("input", 4);

                    transform.position = transform.position - new Vector3(speed,0,0) * Time.deltaTime;
                }
            }
                if((!(Input.GetKey(KeyCode.A))
                && !(Input.GetKey(KeyCode.W)) 
                && !(Input.GetKey(KeyCode.D)) 
                && !(Input.GetKey(KeyCode.S)))
                || ((Input.GetKey(KeyCode.A)) 
                && (Input.GetKey(KeyCode.D)) 
                && !(animator.GetBool("crouch"))))
                    {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("crouch", false);
                    animator.SetInteger("input", 0);
                    }

            if(Input.GetKeyDown(KeyCode.O)){
                LightAttack();
            }
            else if(Input.GetKeyDown(KeyCode.P)){
                UniqueAttack();
            }
            else if(Input.GetKeyDown(KeyCode.I)){
                Block();
            }
        }
    }

    void LightAttack(){
        if(animator.GetBool("isGrounded")){
        animator.SetBool("lightAttack", true);
        animator.SetBool("canAct", false);
        //Whether the character can move or 
        //not is set in behavior scripts per action
        }
    }
    void UniqueAttack(){
        animator.SetBool("uniqueAttack", true);
        animator.SetBool("canAct", false);
        
        if(2 == animator.GetInteger("input")){
            rb2d.AddForce(Vector3.right * tatsu * 100);
        }
        else if(4 == animator.GetInteger("input")){
            rb2d.AddForce(Vector3.left * tatsu * 100);
        }
        //Whether the character can move or 
        //not is set in behavior scripts per action
    }

    void Block(){
        if(animator.GetBool("isGrounded")){
        animator.SetBool("block", true);
        animator.SetBool("canAct", false);
        }
    }

    void Jump(){
        animator.SetBool("jump", true);
        animator.SetBool("isGrounded", false);
        rb2d.AddForce(Vector3.up * jump * 100);
    }
}