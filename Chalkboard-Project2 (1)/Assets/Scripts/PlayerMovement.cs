using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    float MAXIMUMMOVEMENTSPEED;
    public float groundDrag;
    public float jumpForce;
    public float airCooldown;
    public float airMultiplier;
    bool readyToJump;




    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    [Header("Ground check")]
    public float PlayerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        MAXIMUMMOVEMENTSPEED = moveSpeed * 3f * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * .5f + .2f, whatIsGround); 
        MyInput();
        SpeedControl();

        rb.drag = grounded ? groundDrag : 0;
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), airCooldown); 
        }
    }

    private void MovePlayer() {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        float speed = ChaseManager.chase ? MAXIMUMMOVEMENTSPEED : moveSpeed;

        //on ground
        if (grounded)
        {
            if (moveDirection.magnitude == 0)
            {
                rb.velocity = Vector3.zero;
            }
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        else if(!grounded) 
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //limit velocity if needed
        /*if(Input.GetKey(sprintKey))
        {
            MAXIMUMMOVEMENTSPEED = moveSpeed * 3f;
        }
        else
        {
            MAXIMUMMOVEMENTSPEED = moveSpeed;
        }*/
        if(flatVel.magnitude > MAXIMUMMOVEMENTSPEED)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }

    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); 
    }

    private void ResetJump()
    {
        readyToJump = true;

    }

}
