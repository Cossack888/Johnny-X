using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryItem : MonoBehaviour
{
    public GameObject prompt;
    public SpriteRenderer sprite;
    public bool itemPickedUp;
    public BoxCollider2D[] bc;
    public Rigidbody2D rb;
    public Inventory inventory;
    public NewMovement movement;
    public CarryBoxDestruction carryBox;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        bc = GetComponents<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ConstructionSite")
        {
            movement = GameObject.FindGameObjectWithTag("Player").GetComponent<NewMovement>();
            carryBox = GameObject.Find("boxesAnim").GetComponent<CarryBoxDestruction>();

        }

       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !itemPickedUp && !movement.weaponDrawn)
        {
            prompt.SetActive(true);
        }

        if (Input.GetButton("Interact") && !movement.weaponDrawn)
        {
            carryBox.boxHit = false;
            sprite.enabled = false;
            prompt.SetActive(false);
            itemPickedUp = true;
            
            this.gameObject.tag = "itemPicked";
      


            for (int i = 0; i < bc.Length; i++)
            {
                if (bc[i])
                {
                    bc[i].enabled = false;
                   
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(false);
        }
    }

    public void EnableColliders()
    {
        for (int i = 0; i < bc.Length; i++)
        {
            if (bc[i])
            {
                bc[i].enabled = true;

            }
        }

         
    }


}
