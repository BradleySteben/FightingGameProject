using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    float currentTime;
    [SerializeField]
    float startingTime;
    [SerializeField]
    Text CountDown;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -=1 * Time.deltaTime;
        CountDown.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
         }
    }
}
