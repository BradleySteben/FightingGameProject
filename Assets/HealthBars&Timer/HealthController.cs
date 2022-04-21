using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 100;
    [SerializeField]
    int currentHealth;
    [SerializeField]
    HealthBar healthBar;

    [SerializeField]
    int dmgRate;
    [SerializeField]
    KeyCode key;
    [SerializeField]
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) )
        {
            TakeDamage(dmgRate);
        }
        if(currentHealth == 0)
        {
            Debug.Log(healthBar.name + " has lost");
        }
    }
    void TakeDamage(int damage)
    {
       currentHealth -= damage;
       healthBar.Health(currentHealth);
    }
}
