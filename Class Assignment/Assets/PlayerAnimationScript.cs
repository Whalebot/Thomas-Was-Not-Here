using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator animator;
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", movement.inputDirection.x != 0);
        animator.SetBool("isGrounded", movement.isGrounded);
    }
}
