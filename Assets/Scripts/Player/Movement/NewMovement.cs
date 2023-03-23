using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Inventory inv;
	public Death death;
	private RobotFighter melee;
	public GameObject gun;
	public GameObject taser;
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
	private CapsuleCollider2D cc;
	public bool m_FacingRight = true;
	public bool weaponDrawn;
	bool jump = false;
	public float timer;
	public float fallingtimer;
	public float deathByFalling;
	//public ClimbingWall climbing;
	//public CollisionIndentifier collisionIdent;
	public bool hanging = false;
	public bool ledgeclimbing = false;
	public float oldGravity;
	public bool canHangOnLedge=true;
	public bool kicking;
	public GameObject hands;
	public GameObject kick;
	public GameObject fallingIndicator;
	public Vector2 handsPos;
	
	public float posX;
	public float posY=2;


	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
		cc = GetComponent<CapsuleCollider2D>();
	//	climbing = GetComponent<ClimbingWall>();
		oldGravity = rb.gravityScale;
		inv = GetComponent<Inventory>();
		death = GetComponent<Death>();
		


	}

    // Update is called once per frame
    void Update()
    {
		animator.SetBool("WeaponDrawn", weaponDrawn);
		if (!controller.m_Grounded&&!hanging)
        {
			//fallingtimer += Time.deltaTime;
            if (fallingtimer > deathByFalling)
            {
				fallingIndicator.SetActive(true);
            }
        }
		if (controller.m_Grounded)
		{
			fallingtimer = 0;
		}





		if (Input.GetKey(KeyCode.G))
        {
			timer += Time.deltaTime;
			kicking = true;
			if (timer > 1){
				kick.SetActive(true);
				timer = 0;
			}

		}
		if (Input.GetKeyUp(KeyCode.G))
		{
			kicking = false;
			kick.SetActive(false);
		}
		animator.SetBool("kicking", kicking);
		animator.SetBool("ledgeClimbing", ledgeclimbing);
		animator.SetBool("isJumping", !controller.m_Grounded);



		
		if (Input.GetKey(KeyCode.W) && !controller.m_Grounded)
        {
			hands.SetActive(true);
        }
		if (Input.GetKeyUp(KeyCode.W) )
		{
			hands.SetActive(false);
			rb.gravityScale = oldGravity;
			hanging = false;
			animator.SetBool("hanging", false);
		}

		if (Input.GetButtonUp("Jump")&&hanging)
		{

			hands.SetActive(false);
			ledgeclimbing = false;
			timer = 0;
			rb.gravityScale = oldGravity;
			hanging = false;
			animator.SetBool("hanging", false);
		}
		if (hanging && Input.GetButton("Jump"))
		{
            
			
			fallingtimer = 0;
			if (GameObject.FindGameObjectWithTag("hands").transform.position.x > transform.position.x)
			{
				posX = 1;
				
			}
			if (GameObject.FindGameObjectWithTag("hands").transform.position.x < transform.position.x)
			{
				posX = -1;
				
			}


			handsPos = new Vector2(GameObject.FindGameObjectWithTag("hands").transform.position.x + posX,
								GameObject.FindGameObjectWithTag("hands").transform.position.y + posY);
				ledgeclimbing = true;
				timer += Time.deltaTime;

				if (timer >0.8f)
				{
					transform.position = Vector2.MoveTowards(transform.position, handsPos, 3);
					ledgeclimbing = false;
					timer = 0;
					rb.gravityScale = oldGravity;
					hanging = false;
					animator.SetBool("hanging", false);
				}
			
			



		}

	
		if (weaponDrawn && inv.GunShotgun)
		{
			gun.SetActive(true);
		}
		if (weaponDrawn && inv.GunShotgun==false)
		{
			taser.SetActive(true);
		}

		

		else if (!weaponDrawn)
		{
			gun.SetActive(false);
			taser.SetActive(false);
			
		}
		horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed * runSpeed;
		animator.SetFloat("Speed", horizontalMove);


		if (Input.GetKey(KeyCode.LeftShift)&& inv.carryBox == false)
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

		if (Input.GetButtonDown("Draw") && weaponDrawn == false && inv.carryBox==false)
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
		Debug.Log(collision.gameObject.name);

    }


    private void OnCollisionStay2D(Collision2D collision)
	{

		fallingtimer = 0;
		if (collision.gameObject.tag == "stairs")
		{
			controller.m_Grounded = true;
			rb.gravityScale = oldGravity;
			
			bc.sharedMaterial = HighFriction;
			rb.sharedMaterial = HighFriction;
			cc.sharedMaterial = HighFriction;

            if (Input.GetButtonDown("Jump"))
            {
				rb.gravityScale = oldGravity;
				rb.AddForce(new Vector2(0f, controller.m_JumpForce));
			}


			if (Input.GetButton("Horizontal"))
			{
				bc.sharedMaterial = LowFriction;
				rb.sharedMaterial = LowFriction;
				cc.sharedMaterial = LowFriction;

				rb.velocity= new Vector2(horizontalMove * 0.1f, rb.velocity.y);
				rb.gravityScale = 0;

			}

		}
		

	}
    private void OnCollisionExit2D(Collision2D collision)
    {
		rb.gravityScale = oldGravity;
		rb.velocity = controller.m_Rigidbody2D.velocity;
	}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("canNotClimb"))
        {
			canHangOnLedge = false;
        }

		if (collision.CompareTag("Melee"))
        {
			melee = collision.gameObject.GetComponentInParent<RobotFighter>();
			melee.DealDamage();
			


        }



	}

    public void OnTriggerStay2D(Collider2D collision)
    {
		if (collision.CompareTag("Melee"))
		{
			melee = collision.gameObject.GetComponentInParent<RobotFighter>();
			melee.anim.SetBool("walking", false);
			melee.anim.SetBool("attackLow", true);
			timer += Time.deltaTime;
            if (timer > 1)
            {
				death.TakeDamage(25);
				timer = 0;
            }
		}
	}

    public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("canNotClimb"))
		{
			canHangOnLedge = true;
		}
		if (collision.CompareTag("climbPoint"))
        {
			ledgeclimbing = false;
			hanging = false;
        }
		if (collision.CompareTag("Melee"))
		{
			melee = collision.gameObject.GetComponentInParent<RobotFighter>();
			
			
			melee.anim.SetBool("walking", true);

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

