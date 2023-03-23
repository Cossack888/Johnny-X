using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerArcade : MonoBehaviour
{
    public AlignementChange florist1;
    public AlignementChange accountant1;
    public AlignementChange teller1;
    public AlignementChange teller2;
    public AlignementChange Fin;
    public advanceLevel advance;
    public GameObject MindPalace;
    public MindPalace script;
    public GameObject menu;
    public bool menuActive = false;
    public Rigidbody2D rb;
    public GameObject Player;
    public int agression = 0;
    public int professional = 0;
    public int heart = 0;
    public int violence = 0;
    public int alignement;
    public bool agressive;
    public bool kind;
    public bool violent;
    public bool prof;
    public bool Lady;
    public bool Construction;
    public bool armed;
    public bool unarmed;
    public bool licencePlates;
    public bool hitTeller = false;
    public GameObject TellerHit;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == false && Player.activeSelf)
        {
            menu.SetActive(true);
            menuActive = true;
            rb.bodyType = RigidbodyType2D.Static;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuActive == true && Player.activeSelf)
        {
            MenuOut();
        }




        if (teller1.violence > 0)
        {
            hitTeller = true;
            TellerHit.SetActive(true);
        }
        if (Fin.finished)
        {
            advance.levelchanger.SetActive(true);
        }

        violence = florist1.violence + accountant1.violence + teller1.violence + teller2.violence;
        agression = florist1.agression + accountant1.agression + teller1.agression + teller2.agression;
            professional = florist1.professional + accountant1.professional + teller1.professional + teller2.professional;
        heart = florist1.heart + accountant1.heart + teller1.heart + teller2.heart;


        if (violence > 0)
        {
            violent = true;
        }
        if (agression > heart && agression > professional)
            {
                alignement = (int)Mathf.Floor(agression/4)+1; 
                agressive = true;
            }
            if (heart > professional && heart > agression)
            {
                alignement = (int)Mathf.Floor(heart / 4)+1;
            kind = true;
            }

            if (professional > heart && professional > agression)
             {
            alignement = (int)Mathf.Floor(professional / 4)+1;
            prof = true;
               }

        if (script.weaponOn)
        {
            unarmed = true;
            armed = false;
        }

        if (script.weaponOff)
        {
            armed = true;
            unarmed = false;
        }

        if (script.constructionSite)
        {
            Lady = false;
        }
        if (script.ladyFriend)
        {
            Construction = false;
        }
        if (script.locationUnknown)
        {
            Lady = false;
            Construction = false;
        }
        if (script.licensePlatesUnknown)
        {
            licencePlates = false;
        }



        Construction = florist1.FirstClue;
        Lady = florist1.SecondClue;
        unarmed = florist1.ThirdClue;

        armed = accountant1.SecondClue;
        licencePlates = accountant1.FirstClue;

        

        if (!MindPalace.activeSelf && Input.GetKeyDown(KeyCode.M)) {
            MindPalace.SetActive(true);
        }
        else if (MindPalace.activeSelf && Input.GetKeyDown(KeyCode.M))
        {
            MindPalace.SetActive(false);
        }

    }



    public void MenuOut()
    {
        menu.SetActive(false);
        menuActive = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
   
}
