using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncuff : MonoBehaviour
{

    public CSISceneManager scene;
    public GameObject LindaNPC;
    public Sprite image;
    public GameObject trigger;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (scene.arrestedLinda)
        {
            if (Input.GetButton("Interact"))
            {
                LindaNPC.GetComponent<Animator>().enabled = false;
                LindaNPC.GetComponent<SpriteRenderer>().sprite = image;
                
                scene.releasedLinda = true;
            }
        }
    }
}
