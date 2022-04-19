using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pause : MonoBehaviour
{

    public Player_Controller p_cont;
    public GameObject menuScreen;
    public bool pause = false;
    bool playerMovement = false;
    
    void Start()
    {
        p_cont = gameObject.GetComponent<Player_Controller>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            
            Switch(pause);
        }
    }

    public void Switch(bool isPaused)
    {
        if (isPaused)
        {
            if (p_cont.canMove)
            {
                playerMovement = true;
            }
            else
            {
                playerMovement = false;
            }

            p_cont.canMove = false;
            menuScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            p_cont.canMove = playerMovement;
            menuScreen.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pause = false;
        }
    }
}
