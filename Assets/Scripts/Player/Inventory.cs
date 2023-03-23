using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Inventory : MonoBehaviour
{
    public List<object> inventory = new List<object>();


    public GameObject shotgun;
    public GameObject shotgun2;
   
    public GameObject box;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public Carrier carrier;
    public Image SecondItem;
    public Image FirstItem;
    public GameObject inventoryMenu;
    public bool GunShotgun = false;
    public bool carryBox = false;
    public SpriteRenderer boxanimation;
    public Animator player;
    public Player playerinfo;
    public BoxCollider2D boxCollider;
    public CarryBoxDestruction destruct;
    

    public void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name== "ConstructionSite")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            boxanimation = GameObject.Find("boxesAnim").GetComponent<SpriteRenderer>();
            boxanimation.enabled = false;
            playerinfo = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boxCollider = GameObject.Find("boxesAnim").GetComponent<BoxCollider2D>();
            destruct = GameObject.Find("boxesAnim").GetComponent<CarryBoxDestruction>();
        }

        
        
       


    }


    public void Update()
    {
       
       
      




        if (shotgun.GetComponent<InventoryItem>().itemPickedUp == true)
        {
            inventory.Add(shotgun);
            GunShotgun = true;
            playerinfo.shotgun = true;
        }
        else if(shotgun.GetComponent<InventoryItem>().itemPickedUp == false)
        {
            inventory.Remove(shotgun);
            GunShotgun = false;
            playerinfo.shotgun = false;
        }




        if (box.GetComponent<InventoryItem>().itemPickedUp == true || box1.GetComponent<InventoryItem>().itemPickedUp == true
           || box2.GetComponent<InventoryItem>().itemPickedUp == true|| box3.GetComponent<InventoryItem>().itemPickedUp == true )
        {

            if (!destruct.boxHit)
            {
                inventory.Add(box);
                carryBox = true;
                boxanimation.enabled = true;
                player.SetBool("WeaponDrawn", true);
                boxCollider.enabled = true;
                carrier.thrown = false;
            }
            
            else if (destruct.boxHit)
            {
                inventory.Remove(box);
                carryBox = false;
                boxanimation.enabled = false;
                boxCollider.enabled = false;
                player.SetBool("WeaponDrawn", false);
                box.GetComponent<InventoryItem>().itemPickedUp = false;
                box1.GetComponent<InventoryItem>().itemPickedUp = false;
                box2.GetComponent<InventoryItem>().itemPickedUp = false;
                box3.GetComponent<InventoryItem>().itemPickedUp = false;


                box.tag = "BoxDown";
                box.tag = "BoxDown";
                box.tag = "BoxDown";
                box.tag = "BoxDown";

                destruct.boxHit = false;



            }

        }


        else if(box.GetComponent<InventoryItem>().itemPickedUp == false && box1.GetComponent<InventoryItem>().itemPickedUp == false
           && box2.GetComponent<InventoryItem>().itemPickedUp == false && box3.GetComponent<InventoryItem>().itemPickedUp == false )
        {
            inventory.Remove(box);
            carryBox = false;
            boxanimation.enabled = false;
            boxCollider.enabled = false;

        }

          
            
       




        if (Input.GetKeyDown(KeyCode.I) && !inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(true);


            if (inventory.Contains(shotgun))
            {
                Debug.Log("You have a shotgun");
                FirstItem.enabled = true;

            }
            if (inventory.Contains(box))
            {
                Debug.Log("You have a box");
                FirstItem.enabled = true;

            }



            else
            {
               FirstItem.enabled = false;
                Debug.Log("You have nothing");
            }
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(false);



        }
    }


   


}
