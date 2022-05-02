using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHit : MonoBehaviour
{
    [SerializeField]
    HealthBar healthBar;

    [SerializeField]
    int hitDmg;

    private Rigidbody2D rb2d;

    private Collider2D hitbox;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name + ": " + gameObject.tag);
        rb2d = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Attack" && this.tag != "Defending")
        {
            Debug.Log(collision.transform.name + " is " + collision.transform.tag);
            Debug.Log(this.name + " is " + this.tag);
            healthBar.TakeDamage(hitDmg);
        }
    }
}
