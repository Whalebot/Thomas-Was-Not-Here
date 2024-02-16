using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [Header("Inputs")]
    public Vector2 inputDirection;
    public bool jump;
    public bool sprinting;
    bool isSprinting;

    [Header("Running")]
    public float runVelocity;
    public float sprintVelocity;
    public float deaccelerationMultiplier;
    public float airDeaccelerationMultiplier;

    [Header("Jumping")]
    public float jumpForce;
    public bool isGrounded;
    public float groundDetectionRange;
    public LayerMask groundLayers;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump && isGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        GroundDetection();
        FlipBehaviour();
        MovementBehaviour();
    }
    void FlipBehaviour()
    {
        //If there is a input, flip the scale to that direction
        if (inputDirection.x != 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x) * Mathf.Sign(inputDirection.x);
            transform.localScale = theScale;
        }
    }
    void GroundDetection()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRange, groundLayers);
        isGrounded = (groundHit.collider != null && rb.velocity.y <= 0);
    }

    void MovementBehaviour()
    {
        //Specify when you can and can't disable sprinting
        if (isGrounded && sprinting && inputDirection.x != 0)
            isSprinting = true;
        else if (sprinting != true || inputDirection.x == 0)
            isSprinting = false;

        if (isSprinting)
            rb.velocity = new Vector2(inputDirection.x * sprintVelocity, rb.velocity.y);
        else if (inputDirection.x != 0)
        {
            rb.velocity = new Vector2(inputDirection.x * runVelocity, rb.velocity.y);
        }
        else
        {
            //Deacceleration when having no input
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x * deaccelerationMultiplier, rb.velocity.y);
            else
                rb.velocity = new Vector2(rb.velocity.x * airDeaccelerationMultiplier, rb.velocity.y);
        }
    }

    void Jump()
    {
        jump = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
