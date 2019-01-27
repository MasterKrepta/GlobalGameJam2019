using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	
	[SerializeField] float rotSpeed = 180f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float distToGround;
    [SerializeField] LayerMask groundlayer;
    Rigidbody rb;
    [SerializeField] bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        isGrounded = CheckGrounded();
    }
    // Update is called once per frame
    void Update()
    {
        
        float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,0);
    
		transform.Translate( Vector3.right * inputX * Time.deltaTime * moveSpeed);
		transform.Translate( Vector3.forward * inputY * Time.deltaTime * moveSpeed);
		
		float h = rotSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h * Time.deltaTime, 0);

        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(transform.up * jumpForce);
        }
	
	}

    bool CheckGrounded() {
        RaycastHit hitInfo;
        //if (Physics.SphereCast(groundCheck.position, .5f, -Vector3.up, out hitInfo)) {
        //    return true;
        //}
        //else {
        //    return false;
        //}
        
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void OnDrawGizmosSelected() {
        
        //Debug.DrawLine(transform.position,  transform.position.y - distToGround, Color.red);
    }
}
