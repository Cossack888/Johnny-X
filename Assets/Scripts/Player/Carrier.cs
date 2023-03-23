using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour
{
    public Inventory inv;
    public GameObject box;
    public GameObject BoxPile;
    public GameObject BoxPile1;
    public GameObject BoxPile2;
    public GameObject BoxPile3;
    
    public bool thrown;
    public InventoryItem box1;
    public SpriteRenderer boxanimation;
    public Animator player;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        boxanimation = GameObject.Find("boxesAnim").GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (BoxPile.CompareTag("itemPicked"))
        {
            box1 = BoxPile.GetComponent<InventoryItem>();
        }
        if (BoxPile1.CompareTag("itemPicked"))
        {
            box1 = BoxPile1.GetComponent<InventoryItem>();
        }
        if (BoxPile2.CompareTag("itemPicked"))
        {
            box1 = BoxPile2.GetComponent<InventoryItem>();
        }
        if (BoxPile3.CompareTag("itemPicked"))
        {
            box1 = BoxPile3.GetComponent<InventoryItem>();
        }


        if (Input.GetKeyDown(KeyCode.Q)&&inv.carryBox&&thrown==false)
        {

            Instantiate(box, transform.position, transform.rotation);
            inv.inventory.Remove(box);
            box1.itemPickedUp = false;
            BoxPile.GetComponent<InventoryItem>().itemPickedUp = false;
            BoxPile1.GetComponent<InventoryItem>().itemPickedUp = false;
            BoxPile2.GetComponent<InventoryItem>().itemPickedUp = false;
            BoxPile3.GetComponent<InventoryItem>().itemPickedUp = false;


            BoxPile.tag = "BoxDown";
            BoxPile1.tag = "BoxDown";
            BoxPile2.tag = "BoxDown";
            BoxPile3.tag = "BoxDown";
            
            
            inv.carryBox = false;
            box1.sprite.enabled = true;
            box1.EnableColliders();
            boxanimation.enabled = false;
            player.SetBool("WeaponDrawn", false);
            inv.carryBox = false;
            thrown = true;
        }
    }
}
