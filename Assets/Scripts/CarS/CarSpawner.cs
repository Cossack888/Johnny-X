using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{


    public GameObject car;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;



    public float spawnRate = 2;
    public float spawnRate2 = 5;
    private float timer = 0;
    private float timer2 = 0;
    


    // Update is called once per frame
    void Update()
    {



        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;

        }
        else
        {
            Instantiate(car, transform.position, transform.rotation);
            timer = 0;
        }

        if (timer2 < spawnRate2)
        {
            timer2 = timer2 + Time.deltaTime;

        }
        else
        {
            Instantiate(car2, transform.position, transform.rotation);
            timer2 = 0;
        }


    }
}
