using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatsuAttack : MonoBehaviour
{
    Rigidbody2D rb2d;

    //[SerializeField]
    //float speed;

    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        //rb2d.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(this.gameObject, 0.25f);
    }
}
