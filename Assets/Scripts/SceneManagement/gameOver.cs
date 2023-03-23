using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{

    public GameObject Player;
    public GameObject screen;
    public GameObject campoint;
    public GameObject scientist;
    public float timer;
    public float delay=3;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(Player.tag == "PlayerDead")
        {
            campoint.SetActive(false);
            scientist.SetActive(true);
            timer += Time.deltaTime;
            if (timer > delay)
            {
                screen.SetActive(true);
            }
        }
    }
}
