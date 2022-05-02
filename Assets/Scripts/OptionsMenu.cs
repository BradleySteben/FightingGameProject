using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField]
    Canvas optionsMenu;

    [SerializeField]
    Slider volumeSlider;

    //[SerializeField]
    //Toggle mute;

    [SerializeField]
    Button returnBtn;

    private bool isDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && isDisplayed == false)
        {
            optionsMenu.enabled = true;
            isDisplayed = true;

        }
        else if (Input.GetKeyUp(KeyCode.Escape) && isDisplayed != false)
        {
            optionsMenu.enabled = false;
            isDisplayed = false;
        }
    }

    public void Return()
    {
        optionsMenu.enabled = false;
        isDisplayed = false;
    }

    public void ChangeVolume()
    {
        //if (mute.isOn)
        //{
           // AudioListener.volume = 0;
        //}
        //else
        //{
            //AudioListener.volume = volumeSlider.value;
        //}
    }

}
