using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMode : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject Boss;
    public Life[] life;
    public EnemyFire[] enemyFire;
    public bool easyMode =false;

    // Start is called before the first frame update
    void Start()
    {
        //life[0] = enemy1.GetComponent<Life>();
       // life[1] = enemy2.GetComponent<Life>();
       // life[2] = Boss.GetComponent<Life>();
       // enemyFire[0] = enemy1.GetComponentInChildren<EnemyFire>();
       // enemyFire[1] = enemy2.GetComponentInChildren<EnemyFire>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeModeToEasy()
    {
        life[0].currentHitpoints = 25;
        life[0].currentStamina = 25;
        life[1].currentHitpoints = 50;
        life[1].currentStamina = 50;
        life[2].currentHitpoints = 500;
        life[2].currentStamina = 500;
        enemyFire[0].spawnRate = 3;
        enemyFire[1].spawnRate = 1;
        easyMode = true;


    }


}
