using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAutoMove : MonoBehaviour
{
    public CarAutoMove autoMove;
    public GameObject policeCar;
    public GameObject player;

    
    
    public void Update()
    {
        if (Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
        {
            policeCar.GetComponent<CarAutoMove>().enabled = false;
            policeCar.GetComponent<CarMovement>().enabled = true;
        }
        if (player.activeSelf)
        {
            policeCar.GetComponent<CarAutoMove>().enabled = false;
            policeCar.GetComponent<CarMovement>().enabled = false;
        }

    }











}
