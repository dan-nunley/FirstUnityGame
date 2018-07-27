using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;

	private Rigidbody2D myRigidbody;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public int doubleJumpCount;
	public bool isGrounded;

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(Input.GetAxisRaw("Horizontal") > 0f){
			myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
			transform.localScale = new Vector3(1f, 1f, 1f);
		}else if(Input.GetAxisRaw("Horizontal") < 0f){
			myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}else{
			myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
		}

		if(Input.GetButtonDown("Jump") && (isGrounded || (doubleJumpCount%2 == 0))){
			myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
			doubleJumpCount++;
		}

		myAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
		myAnimator.SetBool("Grounded", isGrounded);
	}

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
