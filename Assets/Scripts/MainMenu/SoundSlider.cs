using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public float sliderVal;
    public AudioSource[] audioSources;


    public void SoundChange()
    {
        sliderVal = gameObject.GetComponent<Slider>().value;

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = sliderVal;
        }
    }
}