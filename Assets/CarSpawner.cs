using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;
    public GameObject car9;
    public GameObject car10;
    public int CarCount;
    public int randomator;
    public int laneSwitch;
    public int lane1;
    public int lane2;
    public int lane3;
    public float timer;
    public float delay;
    public TrafficLights traffic;
    public int x;
    public int y;
    


    Vector3 pos;
   
    void Update()
    {
        timer = timer + Time.deltaTime;

        traffic = GameObject.Find("TraficLightSwitch").GetComponent<TrafficLights>();
        

        if (traffic.RedLight == false)
        {
            delay = Random.Range(2, 5);
            laneSwitch = Random.Range(0, 3);
            if (timer > delay)
            {

                switch (laneSwitch)
                {
                    case 0:
                        y  = lane1;

                        break;

                    case 1:
                        y = lane2;

                        break;
                    case 2:
                        y = lane3;

                        break;
                }




                timer = 0;
                CarCount = Random.Range(0, 10);
                

                
                //x = Random.Range(-30, -40);
                pos = new Vector3(x, y, 0);

             /*   randomator = Random.Range(1, 11);
                if (randomator == 10)
                {
                    Instantiate(car10, new Vector3(-40,-25,0), transform.rotation);
                }
             */
                switch (CarCount)
                {

                    case 0:
                        Instantiate(car1, pos, transform.rotation);

                        break;
                    case 1:
                        Instantiate(car2, pos, transform.rotation);

                        break;
                    case 2:
                        Instantiate(car3, pos, transform.rotation);

                        break;
                    case 3:
                        Instantiate(car4, pos, transform.rotation);

                        break;
                    case 4:
                        Instantiate(car5, pos, transform.rotation);

                        break;
                    case 5:
                        Instantiate(car6, pos, transform.rotation);

                        break;
                    case 6:
                        Instantiate(car7, pos, transform.rotation);

                        break;
                    case 7:
                        Instantiate(car8, pos, transform.rotation);

                        break;
                    case 8:
                        Instantiate(car9, pos, transform.rotation);

                        break;
                    case 9:
                        Instantiate(car10, pos, transform.rotation);

                        break;


                    default:
                        Debug.Log("Error");
                        break;
                }
            }
        }
       



    }
















}
