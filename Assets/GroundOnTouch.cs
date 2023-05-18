using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundOnTouch : MonoBehaviour
{

    public float wait;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());

        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(wait);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<Rigidbody2D>().gravityScale = 3;
    }
}
