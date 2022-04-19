using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    void Start()
    {
        if(Screen.fullScreen)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
        } else { gameObject.GetComponent<Toggle>().isOn = false; }
    }
}
