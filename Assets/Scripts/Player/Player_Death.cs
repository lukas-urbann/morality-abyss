using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Death : MonoBehaviour
{
    private AudioSource _audioSource;
    private Player_Controller _playerController;
    [SerializeField] private AudioClip batteryDeath;
    private bool _playSound = false;
    private Animator fadeAnim;
    
    void Start()
    {
        _playerController = gameObject.GetComponent<Player_Controller>();
        fadeAnim = GameObject.Find("LoseFade").GetComponent<Animator>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Guardian"))
        {
            _playerController.canMove = false;
            StartCoroutine(PlayerDeath());
        }
    }

    public void Battery_Death()
    {
        StartCoroutine(PlayerDeath());
    }

    void Enemy_Death()
    {
        
    }

    IEnumerator PlayerDeath()
    {
        if (!_playSound)
        {
            _audioSource.PlayOneShot(batteryDeath);
            _playSound = true;
        }
        
        fadeAnim.SetTrigger("fade");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(4);
    }
}
