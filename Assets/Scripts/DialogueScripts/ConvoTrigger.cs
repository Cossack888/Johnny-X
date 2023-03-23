using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoTrigger : MonoBehaviour
{
    public GameObject conversation;
    public GameObject ThisTrigger;
    public GameObject Trigger2;
    public Player player;
    public DialogueManager manager;
    public GameObject dialogueMenu;
    public GameObject prompt;


    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && manager.finished==false && !player.menuActive)
        {
            dialogueMenu.SetActive(true);
            conversation.SetActive(true);
            
            
        }
        if (collision.CompareTag("Player") && manager.finished == true && !player.menuActive)
        {
            prompt.SetActive(true);
            if (Input.GetButton("Interact"))
            {
                conversation.SetActive(true);
                dialogueMenu.SetActive(true);
            }
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player") && manager.finished == true && !player.menuActive)
        {
            prompt.SetActive(true);
            if (Input.GetButton("Interact"))
            {
                conversation.SetActive(true);
                dialogueMenu.SetActive(true);
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            conversation.SetActive(false);
            dialogueMenu.SetActive(false);
            prompt.SetActive(false);

            if (manager.finished==true)
            {

                ThisTrigger.SetActive(false);
                Trigger2.SetActive(true);
            }
        }

    }

   




}
