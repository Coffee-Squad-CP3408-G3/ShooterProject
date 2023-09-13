using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData playerData;
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true; 

    public Transform orientation;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
  

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = (moveSpeed * playerData.PlayerSpeedModifier);
    }   

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {   
        // Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //Drag
        if(grounded)
        {
            rb.drag =groundDrag;
        }
        else {
            rb.drag = 0;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump),jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward *verticalInput + orientation.right * horizontalInput;
        
        if(Input.GetKey(sprintKey)) {
            if(grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 50f, ForceMode.Force);
            }
        }

        else {
            if(grounded){
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
            
            else if(!grounded){
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }
        }
    } 

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y,limitedVel.z);
        }
    }

    private void Jump()
    {
        if(Input.GetKey(sprintKey)) {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * (jumpForce + 5), ForceMode.Impulse);
        }

        else{
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }


}
