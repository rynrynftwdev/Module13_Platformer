using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Simple 2D platformer movement script
//Left/Right with A/D or Arrow Keys
//Jump when grounded (space key)
//Add to the player. Assign GroundCheck and Ground Layer in the Inspector

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementSimple : MonoBehaviour
{
    //Declare the rigidbody2D
    private Rigidbody2D rb;

    //Movement variables
    [Header("Move")]
    public float moveSpeed = 7f;

    //Jump variables
    [Header("Jump")]
    public float jumpForce = 17f;

    //Ground Check variables
    [Header("Ground Check")]
    public Transform groundCheck; //tiny, empty shape at the feet
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer; //Set to ground layer in the Inspector

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizonal Movement
        float inputX = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        //Jumping
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //Draw a small Ground Check Circle in Scene View
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
