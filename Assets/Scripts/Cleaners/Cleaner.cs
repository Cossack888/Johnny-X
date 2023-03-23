using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    GameObject deadObject;
    public float timer;
    public float delay=5;
    
   
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("dead"))
        {
            timer += Time.deltaTime;
        }
        if (timer > delay)
        {
            Destroy(deadObject);

            timer = 0;
        }


        if (GameObject.FindGameObjectWithTag("dead")){
            deadObject = (GameObject.FindGameObjectWithTag("dead"));
            
        }




}
}
