using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public Chase chase;

    public void Start()
    {
        chase = GetComponentInParent<Chase>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        chase.enabled = true;
    }
}
