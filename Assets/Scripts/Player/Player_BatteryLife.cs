using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Player_BatteryLife : MonoBehaviour
{
    private float _batteryLife;
    public Slider batteryBar;
    private AudioSource _audioSource;
    public GameObject playerFlashlight, flashlightModel;
    private Light playerLight;
    private Player_Death _playerDeath;

    void Start()
    {
        _playerDeath = gameObject.GetComponent<Player_Death>();
        playerLight = playerFlashlight.GetComponent<Light>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _batteryLife = 50;
    }

    public void RefillBattery()
    {
        _batteryLife = 100;
    }

    void Update()
    {
        batteryBar.value = (_batteryLife / 100);

        _batteryLife -= Time.deltaTime * 0.3f;
        playerLight.intensity = 0.25f + (_batteryLife / 100);
        
        if (_batteryLife < 0)
        {
            StartCoroutine(batteryOff());
        }
    }

    IEnumerator batteryOff()
    {
        yield return new WaitForSeconds(3);
        _playerDeath.Battery_Death();
        _audioSource.Play();
        playerFlashlight.SetActive(false);
        flashlightModel.SetActive(false);
    }
}