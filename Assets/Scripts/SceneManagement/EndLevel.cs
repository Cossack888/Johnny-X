using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject robot;
    public GameObject changelevel;
    public float timer;
    public float delay=10;


    // Update is called once per frame
    void Update()
    {




        if (!robot)
        {
            
            
                    changelevel.SetActive(true);
           
        }
        
    }
}
