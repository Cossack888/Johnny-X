using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform destination;
    public GameObject prompt;
    public GameObject blackout;
    // Start is called before the first frame update
    void Start()
    {
        destination = gameObject.transform.GetChild(0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        prompt.SetActive(true);

        if (Input.GetButton("Interact"))
        {
            blackout.SetActive(true);
            collision.transform.position = destination.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
    }




}
