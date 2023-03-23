using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private float timer;
        public float delay;
    public bool active=false;
    public GameObject activator;
    public int numberSpawned;
    public int Spawns;

    void Update()
    {
        

        if (active&&numberSpawned<Spawns)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                Instantiate(enemy, transform.position, transform.rotation);
                
                numberSpawned++;
                timer = 0;
            }
        }
        if (numberSpawned == Spawns)
        {
            activator.SetActive(true);
        }

    }
}
