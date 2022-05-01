using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacters2 : MonoBehaviour
{

    private Animator animator;

    //Key to denying other moves or other stuff

    [SerializeField]
    float speed = 3.0f;


    [SerializeField]
    int LightDmg = 10;

    [SerializeField]
    int UniqueDmg = 15;


    private string tag;

    [SerializeField]
    HealthBar healthBar;

    private int hitDmg;

    private Rigidbody2D rb2d;

    private Collider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        tag = this.gameObject.tag;
        Debug.Log(gameObject.name +": "+ tag);
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

            if(Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("input", 1);

                if(animator.GetBool("isGrounded")){
                    Jump();
                }
            }

            if(!animator.GetBool("crouch"))
            {
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
                this.gameObject.tag = "Player";
                Debug.Log(gameObject.name + ": " + tag);
            }
            else if(Input.GetKeyDown(KeyCode.P)){
                UniqueAttack();
                this.gameObject.tag = "Player";
                Debug.Log(gameObject.name + ": " + tag);
            }
            else if(Input.GetKeyDown(KeyCode.I)){
                Block();
                this.gameObject.tag = "Player";
                Debug.Log(gameObject.name + ": " + tag);
            }
        }
    }

    void LightAttack(){
        this.gameObject.tag = "Attacking";
        Debug.Log(gameObject.name + ": " + tag);
        setDmgCount(LightDmg);
        animator.SetBool("lightAttack", true);
        animator.SetBool("canAct", false);
        //Whether the character can move or 
        //not is set in behavior scripts per action
    }
    void UniqueAttack(){
        this.gameObject.tag = "Attacking";
        Debug.Log(gameObject.name + ": " + tag);
        setDmgCount(UniqueDmg);
        animator.SetBool("uniqueAttack", true);
        animator.SetBool("canAct", false);
        //Whether the character can move or 
        //not is set in behavior scripts per action
    }

    void Block(){
        this.gameObject.tag = "Defending";
        Debug.Log(gameObject.name + ": " + tag);
        animator.SetBool("block", true);
        animator.SetBool("canAct", false);
    }

    void Jump(){

    }

    public void setDmgCount(int dmg)
    {
        hitDmg = dmg;
    }

    public int getDmgCount()
    {
        return hitDmg;
    }
}