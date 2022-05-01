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

    [SerializeField]
    Toggle mute;

    [SerializeField]
    Button returnBtn;

    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            optionsMenu.enabled = true;
        }
    }

    public void Return()
    {
        optionsMenu.enabled = false;
    }

    public void ChangeVolume()
    {
        if (mute.isOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
    }

}
