using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSIMindPalace : MonoBehaviour
{
    public CSISceneManager scene;
    public GameObject LindaKiller;
    public GameObject LindaAgressive;
    public GameObject ChengHeartbroken;
    public GameObject Gang;
    public GameObject FightSounds;
    public GameObject LeoKiller;
    public GameObject Statue;
    public GameObject Mafia;
    public GameObject MikeKiller;
    public GameObject unknownMurderWeapon;
    



    public bool LindaKilled = false;
    public bool LeoKilled = false;
    public bool MikeKilled = false;
    public bool MurderWeapon = false;
    public bool MafiaKilled = false;

    void Update()
    {

        if (scene.LindaKiller)
        {
            LindaKiller.SetActive(true);
        }
        if (scene.FightSounds)
        {
            FightSounds.SetActive(true);
        }


        if (scene.LeoKiller)
        {
            LeoKiller.SetActive(true);
        }
        if (scene.Mafia)
        {
            Mafia.SetActive(true);
        }
        if (scene.LindaAgressive)
        {
            LindaAgressive.SetActive(true);
        }
        if (scene.ChengHeartbroken)
        {
            ChengHeartbroken.SetActive(true);
        }
        if (scene.Gang)
        {
            Gang.SetActive(true);
        }
        if (scene.Statue)
        {
            Statue.SetActive(true);
        }

      
    }

    public void ChooseOne()
    {
        LindaKilled = true;
       LeoKiller.SetActive(false);
        Gang.SetActive(false);
        Mafia.SetActive(false);
        MikeKiller.SetActive(false);
        scene.MikeKiller = false;
        scene.Gang = false;
        scene.Mafia = false;
        scene.LeoKiller = false;

    }
    public void ChooseTwo()
    {
        
    }
    public void ChooseThree()
    {
       

    }
    public void ChooseFour()
    {
        
       


    }
    public void ChoosefFive()
    {
        
        

    }
    public void ChooseSix()
    {
        LeoKilled = true;
        LindaKiller.SetActive(false);
        Gang.SetActive(false);
        Mafia.SetActive(false);
        MikeKiller.SetActive(false);
        scene.MikeKiller = false;
        scene.Gang = false;
        scene.Mafia = false;
        scene.LindaKiller = false;

    }
    public void ChooseSeven()
    {
        MurderWeapon = true;
        unknownMurderWeapon.SetActive(false);
        
    }
    public void ChooseEight()
    {
        MafiaKilled = true;
        LeoKiller.SetActive(false);
        LindaKiller.SetActive(false);
        MikeKiller.SetActive(false);
        scene.LeoKiller = false;
        scene.LindaKiller = false;
        scene.MikeKiller = false;
    }
    public void ChooseNine()
    {
        MikeKilled = true;
        LeoKiller.SetActive(false);
        Gang.SetActive(false);
        Mafia.SetActive(false);
        LindaKiller.SetActive(false);
        scene.LeoKiller = false;
        scene.Gang = false;
        scene.Mafia = false;
        scene.LindaKiller = false;




    }
    public void ChooseTen()
    {
        Statue.SetActive(false);
        scene.Statue = false;
    }


}
