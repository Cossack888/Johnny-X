using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamShort : MonoBehaviour
{

    public GameObject activatedObject;
    public GameObject textPrompt;
    public bool run=false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !run)
        {
            activatedObject.SetActive(true);
            textPrompt.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activatedObject.SetActive(false);
            run = true;

        }
    }


}