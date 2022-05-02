using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make2Appear : MonoBehaviour
{

    [SerializeField]
    GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Equals)){
           Player2.SetActive(true);
       } 
       if(Input.GetKeyDown(KeyCode.Minus)){
           Player2.SetActive(false);
       }
    }
}
