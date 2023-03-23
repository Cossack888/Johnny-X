using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject self;
    public float timer;
    public float delay;


    void Update()
    {

        if (timer > delay)
        {
            self.SetActive(false);
            timer = 0;
        }



        if (self.activeSelf)
        {
            timer = timer + Time.deltaTime;
        }
    }
}
