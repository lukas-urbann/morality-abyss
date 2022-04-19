using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public Dropdown dropdown;
    
    public void ShowSettings()
    {
        if (optionsMenu.activeSelf)
        {
            Debug.Log("menuoff");
            optionsMenu.SetActive(false);
        }
        else
        {
            Debug.Log("menuon");
            optionsMenu.SetActive(true);
        }
    }
    
    public void ScreenSwitch()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ChangeResolution()
    {
        dropdown = GameObject.Find("Dropdown-Resolution").GetComponent<Dropdown>();
    }
}
