using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squashed : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heavy"))
        {
            anim.SetBool("isZapped", true);
            gameObject.tag = "dead";
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }


        }
    }
}
