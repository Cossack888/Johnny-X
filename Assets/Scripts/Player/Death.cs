using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Restart restart;
    public NewMovement movement;
    public GameObject playerCharacter;
    public GameObject cam1;
    public Rigidbody2D rb;
    public int health = 200;
    public int MaxHealth = 200;
    public Animator anim;
    public bool isShot=false;
    public float timer;
    public float delay=5;
    public bool deathTimer;
    public Inventory inventory;
    public GameObject firepoint1;
    public GameObject firepoint2;
    public CursorMode cursorMode = CursorMode.Auto;
    public HealthBar healthBar;
    public CarryBoxDestruction carryBox;

    public void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        health = MaxHealth;
        if (scene.name == "ConstructionSite")
        {
            healthBar.MaxHealth(health);
            carryBox = GameObject.Find("boxesAnim").GetComponent<CarryBoxDestruction>();
        }

           
    }


    public void Update()
    {
        /* if (movement.hitByCar == true)
         {
             restart.gameOver();
         }

         */

        
        if (deathTimer == true)
        {
            timer += Time.deltaTime;
            
            cam1.SetActive(true);
            inventory.boxanimation.enabled = false;
            movement.weaponDrawn = false;
            movement.enabled = false;
            firepoint1.SetActive(false);
            firepoint2.SetActive(false);
            Cursor.SetCursor(null, Vector2.zero, cursorMode);


        }

        if (timer > delay)
        {
            restart.gameOver();
            timer = 0;
            deathTimer = false;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            restart.gameOver();
        }

       
    }

    public void TakeDamage(int damage)
    {
        if (carryBox.boxHit || carryBox.spriteRend.enabled==false){

            health -= damage;
            healthBar.SetHealth(health);

            if ((health <= 0) && isShot == false)
            {
                KIA();
            }

        }
        




    }


    public void KIA()
    {
        anim.SetBool("dead",true);
        deathTimer = true;


       
    }












}


