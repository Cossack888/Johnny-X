using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoTrigger2 : MonoBehaviour
{
    public GameObject conversation;
    public GameObject conversation2;
    public GameObject triggerConvo1;
    public DialogueManager manager;
    public DialogueManager manager2;
    public GameObject dialogueMenu;
    public GameObject prompt;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&manager2.finished)
        {
            dialogueMenu.SetActive(true);
            conversation.SetActive(true);
            triggerConvo1.SetActive(false);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {




       /// if (!conversation.activeSelf && collision.CompareTag("Player"))
       /// {
        ///    dialogueMenu.SetActive(false);
         //   prompt.SetActive(true);
       // }



        if (collision.CompareTag("Player") && manager.finished == true)
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
        }

    }






}