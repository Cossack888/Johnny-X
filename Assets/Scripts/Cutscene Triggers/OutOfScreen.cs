using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreen : MonoBehaviour
{
    public GameObject WentOutTheScreen;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OutOfScreen"))
        {
            WentOutTheScreen.SetActive(true);
        }
    }
}
