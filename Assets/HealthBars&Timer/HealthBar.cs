using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    int maxHealth, currentHealth;

    //[SerializeField]
    //int maxHealth;

    //[SerializeField]
    //int damage;

    //[SerializeField]
    //Rigidbody2D rb2d;
    void Start()
    {
        currentHealth = maxHealth;
        this.MaxHealth(maxHealth);
    }

    public void  MaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }
  public void Health(int health){
        slider.value = health;
    }
    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
        this.Health(currentHealth);
    }

    public int getHealth()
    {
        return this.currentHealth;
    }

}
