using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllElements : MonoBehaviour
{
    float currentTime;
    [SerializeField]
    float startingTime;
    [SerializeField]
    Text CountDown;

    [SerializeField]
    HealthBar healthBar1, healthBar2;

    [SerializeField]
    int dmgRate;
    [SerializeField]
    KeyCode key1, key2;

    [SerializeField]
    Canvas results, pause;
    [SerializeField]
    Text announcement;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        results.enabled = false;
        pause.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountDown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        if (Input.GetKeyDown(key1))
        {
            healthBar1.TakeDamage(dmgRate);
        }
        if (Input.GetKeyDown(key2))
        {
            healthBar2.TakeDamage(dmgRate);
        }

        if(healthBar1.getHealth() == 0)
        {
            Debug.Log("Player 2 WIN!!");
            Time.timeScale = 0;
            results.enabled = true;
            announcement.text = "Player 2 WIN!!";
        }
        if (healthBar2.getHealth() == 0)
        {
            Debug.Log("Player 1 WIN!!");
            Time.timeScale = 0;
            results.enabled = true;
            announcement.text = "Player 1 WIN!!";
        }
        if(currentTime == 0)
        {
            if(healthBar1.getHealth() > healthBar2.getHealth())
            {
                Debug.Log("Player 1 WIN!!");
                Time.timeScale = 0;
                results.enabled = true;
                announcement.text = "Player 1 WIN!!";
            }
            else if(healthBar1.getHealth() == healthBar2.getHealth())
            {
                Debug.Log("Draw");
                Time.timeScale = 0;
                results.enabled = true;
                announcement.text = "Draw!!!";
            }
            else
            {
                Debug.Log("Player 2 WIN!!");
                Time.timeScale = 0;
                results.enabled = true;
                announcement.text = "Player 2 WIN!!";
            }
        }
    }
}
