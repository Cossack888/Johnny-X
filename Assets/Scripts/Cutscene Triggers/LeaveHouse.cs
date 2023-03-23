using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHouse : MonoBehaviour
{
    public GameObject player;
    public GameObject prompt;
    public GameObject blackscreen;
    public GameObject Camera1;
    public float positionX;
    public float positionY;
    public float positionZ;

    public bool moved = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (moved == false)
            {
                prompt.SetActive(true);



            }
            if (moved == true)
            {
                prompt.SetActive(false);
            }

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.SetActive(true);
            if (Input.GetButton("Interact"))
            {

                blackscreen.SetActive(true);
                player.transform.position = new Vector3(positionX, positionY, positionZ);
                moved = true;
                Camera1.SetActive(false);
            }


        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);

    }

}