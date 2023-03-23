using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilitySwitch : MonoBehaviour
{
    public SpriteRenderer[] sprite;
    public GameObject patches;
    public GameObject cover;
   
    private void Start()
    {

       
        sprite = GetComponentsInChildren<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                if (sprite[i])
                {
                    sprite[i].enabled = false;
                    
                }
            }
            patches.SetActive(true);
            cover.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                if (sprite[i])
                {
                    sprite[i].enabled = true;

                }
            }
            patches.SetActive(false);
            cover.SetActive(true);
        }
    }




}
