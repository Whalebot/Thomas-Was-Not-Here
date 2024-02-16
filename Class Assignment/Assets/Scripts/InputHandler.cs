using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 inputDirection;
    public bool jumpButton;
    public bool sprintButton;
    SetVelocityController setVelocityController;
    AddForceController addForceController;
    Movement movement;
    private void Start()
    {
        setVelocityController = GetComponent<SetVelocityController>();
        addForceController = GetComponent<AddForceController>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Store the inputs in a variable
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        jumpButton = Input.GetButtonDown("Jump");
        sprintButton = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TransitionManager.Instance.ToggleFade();
        }

        //Send the inputs to the controller
        if (setVelocityController != null)
        {
            setVelocityController.inputDirection = inputDirection;
            setVelocityController.jump = jumpButton;
        }

        if (addForceController != null)
        {
            addForceController.inputDirection = inputDirection;
            addForceController.jump = jumpButton;
        }
        if (movement != null)
        {
            movement.inputDirection = inputDirection;
            movement.jump = jumpButton;
            movement.sprinting = sprintButton && movement.inputDirection.x != 0;
        }
    }
}
