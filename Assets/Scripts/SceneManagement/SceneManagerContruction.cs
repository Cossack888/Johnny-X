using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerContruction : MonoBehaviour
{

    public GameObject menu;
    public bool menuActive = false;
    public Rigidbody2D rb;

    public GameObject box;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public InventoryItem boxInv;
    public InventoryItem boxInv1;
    public InventoryItem boxInv2;
    public InventoryItem boxInv3;


    public float timer;
    public void Start()
    {
        boxInv = box.GetComponent<InventoryItem>();
        boxInv1 = box1.GetComponent<InventoryItem>();
        boxInv2 = box2.GetComponent<InventoryItem>();
        boxInv3 = box3.GetComponent<InventoryItem>();

    }

    public void Update()
    {



        if (box.GetComponent<InventoryItem>().itemPickedUp == true || box1.GetComponent<InventoryItem>().itemPickedUp == true
                  || box2.GetComponent<InventoryItem>().itemPickedUp == true || box3.GetComponent<InventoryItem>().itemPickedUp == true)
        {
            timer = 0;
        }
        timer += Time.deltaTime;
        if (timer>30)
        {
            boxInv.itemPickedUp = false;
            boxInv1.itemPickedUp = false;
            boxInv2.itemPickedUp = false;
            boxInv3.itemPickedUp = false;
            box.tag = "BoxDown";
            box1.tag = "BoxDown";
            box2.tag = "BoxDown";
            box3.tag = "BoxDown";
            boxInv.EnableColliders();
            boxInv1.EnableColliders();
            boxInv2.EnableColliders();
            boxInv3.EnableColliders();
            boxInv.sprite.enabled = true;
            boxInv1.sprite.enabled = true;
            boxInv2.sprite.enabled = true;
            boxInv3.sprite.enabled = true;
            timer = 0;


        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == false)
        {
            menu.SetActive(true);
            menuActive = true;
            rb.bodyType = RigidbodyType2D.Static;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            MenuOut();
        }

    }


    public void MenuOut()
    {
        menu.SetActive(false);
        menuActive = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }



}
