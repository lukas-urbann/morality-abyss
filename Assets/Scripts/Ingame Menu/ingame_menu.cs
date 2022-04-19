using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_menu : MonoBehaviour
{
    public GameObject optionsScreen;
    public Player_Pause pPause;

    public void Continue()
    {
        pPause.Switch(!pPause.pause);
    }
    
    public void ShowPreferences()
    {
        if (optionsScreen.activeSelf)
        {
            optionsScreen.SetActive(false);
        }
        else
        {
            optionsScreen.SetActive(true);
        }
        
    }
    
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void FullscreenSwitch()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ChangeRes(int val)
    {
        bool fs = false;
        
        if (Screen.fullScreen)
        {
            fs = true;
        }
        else
        {
            fs = false;
        }
        
        if (val == 0)
        {
            Screen.SetResolution(1920, 1080, fs);
        } else if (val == 1)
        {
            Screen.SetResolution(1280, 720, fs);
        } else if (val == 2)
        {
            Screen.SetResolution(854, 480, fs);
        } else if (val == 3)
        {
            Screen.SetResolution(640, 360, fs);
        }
    }
}
