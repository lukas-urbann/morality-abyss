using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCamera_Animator : MonoBehaviour
{
    private Animator anim;
    private Player_Controller player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = Player_Controller.instance;
    }

    private void Update()
    {
        if (player.characterController.velocity.magnitude > 0.1f && player.characterController.isGrounded)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);
    }
}
