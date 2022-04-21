using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player_Controller : MonoBehaviour
{
    private Player_Vars _vars;
    public CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public static Player_Controller instance;
    
    public bool canMove = true;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _vars = GetComponent<Player_Vars>();
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (_vars.walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (_vars.walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            Player_Footsteps.instance.PlayJump();
            moveDirection.y = _vars.jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Gravitace
        if (!characterController.isGrounded)
        {
            moveDirection.y -= _vars.gravity * Time.deltaTime;
        }

        // Pohyb
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotace kamery
        if (canMove)
        {
            //_vars.playerFootsteps.PlayWalk();
            rotationX += -Input.GetAxis("Mouse Y") * _vars.lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -_vars.lookXLimit, _vars.lookXLimit);
            _vars.playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _vars.lookSpeed, 0);
        }
    }
}