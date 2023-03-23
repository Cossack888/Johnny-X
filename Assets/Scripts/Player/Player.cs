using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject playerCharacter;
    public Animator police;
    
    public bool menuActive;
    public int health = 100;
    public bool isShot = false;
    public Rigidbody2D rb;
    public GameObject gameOverScreen;
    public int level = 1;
    public int FinnConvo;
    public int DispatchConvo;
    public int FloristConvo;
    public int AccountantConvo;
    public int Teller1Convo;
    public int Teller2Convo;
    public float[] position;
    public float time;
    public float delay = 3;
    public bool life;
    public bool deathByTrap;
    public bool shotgun;
    public Inventory inventory;
    public GameObject cam1;
    public NewMovement movement;
    public Death death;
    public EasyMode easymode;
    public bool easyModeData;
    


    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        police = GetComponent<Animator>();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ConstructionSite")
        {
            easymode = GameObject.Find("Easy Mode").GetComponent<EasyMode>();

            inventory = playerCharacter.GetComponent<Inventory>();
        }


        
    }
   public void Update()
    {
        if (easymode)
        {
            easyModeData = easymode.easyMode;
        }

        if (inventory)
        {
            shotgun = inventory.GunShotgun;
        }
        
    }
 

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        FinnConvo = data.FinnConvo;
        DispatchConvo = data.DispatchConvo;
        FloristConvo = data.FloristConvo;
        AccountantConvo = data.AccountantConvo;
        Teller1Convo = data.Teller1Convo;
        Teller2Convo = data.Teller2Convo;
        shotgun = data.shotgun;
        easyModeData = data.easyModeData;
        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
       
       transform.position = position;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ConstructionSite")
        {
            playerCharacter.tag = "Player";
            gameOverScreen.SetActive(false);

            police.SetBool("dead", false);
            cam1.SetActive(false);


            movement.enabled = true;
            police.enabled = true;
            death.deathTimer = false;
            death.timer = 0;
        }

        
        
    }
    public void NewGame()

    {
        RestartLevel();
        isShot = false;

    }
    public void EndGame()

    {
        Application.Quit();

    }


}





