using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAway : MonoBehaviour
{
    public Transform destination;
    public CSISceneManager scene;
    public GameObject blackout;
    // Start is called before the first frame update
    void Start()
    {
        destination = gameObject.transform.GetChild(0);
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!scene.hitLeo&&!scene.arrestedLeo)
        {
            blackout.SetActive(true);
            collision.transform.position = destination.position;
        }
            
        
    }
   







}
