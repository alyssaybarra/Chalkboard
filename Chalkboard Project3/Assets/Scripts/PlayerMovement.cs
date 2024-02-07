using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float sprintMultiplier;
    public float airMultiplier;
    public float jumpForce;

    [Header("Ground check")]
    public float PlayerHeight;
    public LayerMask whatIsGround;

    private Rigidbody rb;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * .5f + .2f, whatIsGround); 
        SpeedControl();

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        rb.drag = grounded ? groundDrag : 0;
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }

    private void MovePlayer() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //calculate movement direction
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        if (moveDirection.magnitude == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        //sprint if shift is held
        float speed = grounded && Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintMultiplier : moveSpeed; 

        float airMoveMult = grounded ? 1 : airMultiplier;

        rb.AddForce(moveDirection.normalized * speed * 10f * airMoveMult, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed )
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
