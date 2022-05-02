using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    private Animator animator;

    //Key to denying other moves or other stuff

    [SerializeField]
    float speed = 3.0f;

    [SerializeField]
    float jump = 2.0f;

    [SerializeField]
    float tatsu = 2.5f;

    [SerializeField]
    HealthBar healthBar;

    private int hitDmg;

    private Rigidbody2D rb2d;

    private Collider2D hitbox;

    [SerializeField]
    GameObject lightAttack, specialAttack;

    [SerializeField]
    Transform releaseRight, releaseLeft;

    private bool isAttacking = false;
    private bool isBlocking = false;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("canAct")){

            if(Input.GetKey(KeyCode.DownArrow))
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

                if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetInteger("input", 1);

                if(animator.GetBool("isGrounded")){
                    Jump();
                }
            }
                
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    animator.SetBool("isWalking", true);
                    animator.SetInteger("input", 2);
                    
                    transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;
                }

                if(Input.GetKey(KeyCode.LeftArrow))
                {
                    animator.SetBool("isWalking", true);
                    animator.SetInteger("input", 4);

                    transform.position = transform.position - new Vector3(speed,0,0) * Time.deltaTime;
                }
            }
                if((!(Input.GetKey(KeyCode.LeftArrow))
                && !(Input.GetKey(KeyCode.UpArrow)) 
                && !(Input.GetKey(KeyCode.RightArrow)) 
                && !(Input.GetKey(KeyCode.DownArrow)))
                || ((Input.GetKey(KeyCode.LeftArrow)) 
                && (Input.GetKey(KeyCode.RightArrow)) 
                && !(animator.GetBool("crouch"))))
                    {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("crouch", false);
                    animator.SetInteger("input", 0);
                    }

            if(Input.GetKeyDown(KeyCode.Comma)){
                LightAttack();
            }
            else if(Input.GetKeyDown(KeyCode.Period)){
                UniqueAttack();
            }
            else if(Input.GetKeyDown(KeyCode.M)){
                Block();
                isBlocking = true;
            }
            else if (Input.GetKeyUp(KeyCode.M))
            {
                isBlocking = false;
            }
        }
    }

    void LightAttack(){
        if(animator.GetBool("isGrounded")){
        animator.SetBool("lightAttack", true);
            Instantiate(lightAttack, releaseRight.position, releaseRight.rotation);
        animator.SetBool("canAct", false);
        //Whether the character can move or 
        //not is set in behavior scripts per action
        }
    }
    void UniqueAttack(){
        animator.SetBool("uniqueAttack", true);
            Instantiate(specialAttack, releaseRight.position, releaseRight.rotation);
            Instantiate(specialAttack, releaseLeft.position, releaseLeft.rotation);
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
        animator.SetBool("block", true);
        animator.SetBool("canAct", false);
    }

    void Jump(){
        animator.SetBool("jump", true);
        animator.SetBool("isGrounded", false);
        rb2d.AddForce(Vector3.up * jump * 100);
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Attack" && isBlocking != true)
        {
            Debug.Log(collision.transform.name + " is " + collision.transform.tag);
            //Debug.Log(this.name + " is " + this.tag);
            if(collision.gameObject.name == "LightAttack(Clone)")
            {
                healthBar.TakeDamage(10);
                Debug.Log(this.name + "took 10 damage");
            }
            else
            {
                healthBar.TakeDamage(15);
                Debug.Log(this.name + "took 15 damage");
            }
        }
    }
}