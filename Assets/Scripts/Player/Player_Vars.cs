using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Vars : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public AudioSource audioSource;

    [HideInInspector] public Player_Footsteps playerFootsteps;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerFootsteps = GetComponent<Player_Footsteps>();
    }
}
