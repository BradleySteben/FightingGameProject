using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacters : MonoBehaviour
{

    private Animator animator;

    //Key to denying other moves or other stuff
    private bool canAct = false;
    private bool onGround = true;
    private bool isWalking = false;
    private bool blocking = false;

    [SerializeField]
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;
            animator.SetBool("isWalking", true);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position = transform.position - new Vector3(speed,0,0) * Time.deltaTime;
            animator.SetBool("isWalking", true);
        }
        if(!(Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.A))){
            animator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate(){

    }
}
