using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;

	Vector2 jumpVector;
	Vector2 movement;
	public GameObject gun;
	private GameObject player;
	public Animator animator;
	float horizontalMove = 0f;
	public float moveSpeed = 40f;
	public float m_JumpForce;
	bool crouch = false;
	public float runSpeed = 1;
	public PhysicsMaterial2D HighFriction;
	public PhysicsMaterial2D LowFriction;
	private Rigidbody2D rb;
	private BoxCollider2D bc;
	public bool m_FacingRight = true;
	public bool weaponDrawn;
	public bool isGrounded = true;
	bool jump = false;
	public bool obstacle = false;
	public float timer;
	public ClimbingWall climbing;
	public bool wallGrab;
	public float oldGravity;



	// Update is called once per frame

	private void Start()
	{
		player = gameObject;
		rb = player.GetComponent<Rigidbody2D>();
		bc = player.GetComponent<BoxCollider2D>();
		climbing = GetComponent<ClimbingWall>();
		oldGravity = rb.gravityScale;
	}

    void Update()
	{
		animator.SetBool("climbing", wallGrab);
		

		if (climbing.onTheWall)
        {
			animator.SetBool("obstacle", true);
        }
		if (!climbing.onTheWall)
		{
			animator.SetBool("obstacle", false);
		}

		if(climbing.onTheWall && Input.GetKeyDown(KeyCode.C))
        {
			wallGrab = true;
        }
		if (!climbing.onTheWall || Input.GetKeyUp(KeyCode.C))
		{
			wallGrab = false;
		}
		if (climbing.onTheWall && Input.GetKeyDown(KeyCode.V))
		{
			
			animator.SetBool("ledge", true);
		}





		if (wallGrab)
        {
			rb.gravityScale = 0;
			rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else
        {
			rb.gravityScale = oldGravity;
        }


		if (weaponDrawn)
        {
			gun.SetActive(true);
        }
        else if (!weaponDrawn){
			gun.SetActive(false);
			animator.SetBool("WeaponDrawn", false);
		}
		horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed * runSpeed;
		animator.SetFloat("Speed", horizontalMove);
		

		if (Input.GetKey(KeyCode.LeftShift))
		{
			runSpeed = 2;
			animator.SetBool("Running", true);
			weaponDrawn = false;

		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			runSpeed = 1;
			animator.SetBool("Running", false);

		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			

		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (!m_FacingRight)
		{
			animator.SetBool("FacingLeft", true);
		}
		if (m_FacingRight)
		{
			animator.SetBool("FacingLeft", false);
		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			crouch = true;
			animator.SetBool("isCrouching", true);
		}
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			crouch = false;
			animator.SetBool("isCrouching", false);
		}

		if (Input.GetButtonDown("Draw") && weaponDrawn == false)
		{
			DrawWeapon();
			weaponDrawn = true;
		}
		else if (weaponDrawn == true && Input.GetButtonDown("Draw"))
		{
			animator.SetBool("WeaponDrawn", false);
			weaponDrawn = false;
		}

	}

	public void OnLanding()
	{
		animator.SetBool("isJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("isCrouching", isCrouching);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "stairs")
		{


			bc.sharedMaterial = HighFriction;
			rb.sharedMaterial = HighFriction;

			if (Input.GetButton("Horizontal"))
			{
				bc.sharedMaterial = LowFriction;
				rb.sharedMaterial = LowFriction;
			}

		}
		//(collision.gameObject.tag == "ground")
		if (collision.gameObject.layer == 3)
		{

			isGrounded = true;

			animator.SetBool("isJumping", false);


		}

	}

	private void OnTriggerStay2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "obstacle")
		{
			obstacle = true;
			animator.SetBool("obstacle", true);

		}

		if (collision.gameObject.tag == "obstacle" && Input.GetButton("Jump"))
		{

			BoxCollider2D box = collision.gameObject.transform.Find("top").gameObject.GetComponent<BoxCollider2D>();


			Vector2 target = new Vector2(collision.gameObject.transform.position.x, box.size.y - 2);
			timer = timer + Time.deltaTime;


			if (timer > 0.5)
			{

				transform.position = Vector2.MoveTowards(transform.position, target, 5);
				//transform.position = target;
				animator.SetBool("climbing", false);
				timer = 0;
			}


		}
	}

	private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "obstacle")
		{
			obstacle = false;
			animator.SetBool("obstacle", false);
			animator.SetBool("climbing", false);
		}
	}

    private void OnCollisionExit2D(Collision2D collision)
	{

		if (collision.gameObject.layer == 3)
		{

			isGrounded = false;
			animator.SetBool("Running", false);
			animator.SetBool("isJumping", true);


		}


	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;





        if (!weaponDrawn)
        {
			if (horizontalMove > 0 && !m_FacingRight)
			{

				
				Flip();
			}

		
			else if (horizontalMove < 0 && m_FacingRight)
			{
				
				Flip();
			}
		}

	
	}

	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}

	void DrawWeapon()
	{
		animator.SetBool("WeaponDrawn", true);
	}



	void HolsterWeapon()
	{
		animator.SetBool("WeaponDrawn", false);
		weaponDrawn = false;
	}
}