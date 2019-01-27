using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	
	[SerializeField] float rotSpeed = 180f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] LayerMask ground;
    [SerializeField] float distToGround;
    [SerializeField]float gravity = 30f;

    CharacterController cc;
    Rigidbody rb;
    [SerializeField] bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        isGrounded = true;
    }

    private void FixedUpdate() {
        isGrounded = CheckGrounded();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !Cursor.visible;
        }

        float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * moveSpeed;
        //cc.Move(moveDirection * Time.deltaTime * moveSpeed);
     



        float h = rotSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h * Time.deltaTime, 0);


        ////if (Input.GetButtonDown("Jump") && isGrounded) {
        //if (Input.GetButtonDown("Jump")&& isGrounded) { //THIS IS HACKY
        //    //rb.AddForce(transform.up * jumpForce);
        //    moveDirection.y = jumpForce ;
        //}
        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        cc.Move(moveDirection * Time.deltaTime);
    }

    bool CheckGrounded() {
   
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void OnDrawGizmosSelected() {
        
        //Debug.DrawLine(transform.position,  transform.position - distToGround, Color.red);
    }
}
