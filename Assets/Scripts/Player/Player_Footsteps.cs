using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Footsteps : MonoBehaviour
{
    public List<AudioClip> footsteps = new List<AudioClip>();
    public AudioClip jumpStep;
    public AudioClip fallStep;
    public AudioSource audioSource;
    public static Player_Footsteps instance;
    private Player_Controller player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = Player_Controller.instance;
    }
    
    public void PlayJump()
    {
        audioSource.clip = jumpStep;
        audioSource.Play();
    }
    
    public void PlayFall()
    {
        audioSource.clip = fallStep;
        audioSource.Play();
    }

    public void PlayWalk()
    {
        if (player.characterController.isGrounded && player.characterController.velocity.magnitude > 1f && !audioSource.isPlaying)
        {
            audioSource.pitch = Random.Range(1f, 1.5f);
            if (Random.Range(0, 2) > 1)
                audioSource.clip = footsteps[0];
            else
                audioSource.clip = footsteps[1];
            audioSource.Play();
        }
    }
}
