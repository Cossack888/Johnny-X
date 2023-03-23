using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public bool RedLight=true;
    public float timer;
    public float changeLighs;
    public float Reset;


    public void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > changeLighs)
        {

            RedLight = false;


        }
        if (timer > Reset)
        {
            timer = 0;
            if (RedLight == true)
            {
                RedLight = false;
            }
            else if (RedLight == false)
            {
                RedLight = true;
            }


        }






    }


}
