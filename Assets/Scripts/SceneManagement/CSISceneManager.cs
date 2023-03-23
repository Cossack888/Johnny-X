using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSISceneManager : MonoBehaviour
{
    public AlignementChange Leo;
    public AlignementChange Mike;
    public AlignementChange MikeArrest;
    public AlignementChange Linda;
    public AlignementChange Cheng;
    public AlignementChange LeoDrawer;
    public AlignementChange ChengDrawer;
    public Animator leo;
    public Animator linda;
    public Animator mike;
    public GameObject MindPalace;
    public CSIMindPalace script;
    public GameObject menu;
    public bool menuActive = false;
    public Rigidbody2D rb;


    public int agression = 0;
    public int professional = 0;
    public int heart = 0;
    public int violence = 0;
    public int alignement;
    public bool agressive;
    public bool kind;
    public bool violent;
    public bool prof;
    public bool Mafia;
    public bool Statue;
    public bool LindaKiller;
    public bool LeoKiller;
    public bool MikeKiller = true;
    public bool hitLeo = false;
    public bool LindaAgressive;
    public bool ChengHeartbroken;
    public bool FightSounds;
    public bool LeoStatue;
    public bool Gang;
    public bool arrestedLinda;
    public bool arrestedLeo;
    public bool arrestedMike;
    public bool releasedLinda;
    public bool caseSolved;
    public bool caseUnsolved;
    public GameObject EndGameSuccess;
    public GameObject EndGameFail;
    public GameObject Endgame;
    public GameObject EndgameContinue;
    public AlignementChange FollowUp;
    public AlignementChange FollowUp1;
    public AlignementChange FollowUp2;
    public AlignementChange FollowUp3;
    public AlignementChange FollowUp4;
    public AlignementChange FollowUp5;
    public AlignementChange FollowUp6;
    public AlignementChange FollowUp7;
    public AlignementChange FollowUp8;
    public AlignementChange FollowUp9;
    public AlignementChange FollowUp10;
    public float timer;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == false)
        {
            menu.SetActive(true);
            menuActive = true;
            rb.bodyType = RigidbodyType2D.Static;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            menu.SetActive(false);
            menuActive = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if(FollowUp.caseSolved || FollowUp1.caseSolved || FollowUp2.caseSolved || FollowUp3.caseSolved || FollowUp4.caseSolved || FollowUp5.caseSolved ||
            FollowUp6.caseSolved || FollowUp7.caseSolved || FollowUp8.caseSolved || FollowUp9.caseSolved || FollowUp10.caseSolved)
        {

            caseSolved = true;
        }

        if (FollowUp.caseUnsolved || FollowUp1.caseUnsolved || FollowUp2.caseUnsolved || FollowUp3.caseUnsolved || FollowUp4.caseUnsolved 
            || FollowUp5.caseUnsolved || FollowUp6.caseUnsolved || FollowUp7.caseUnsolved || FollowUp8.caseUnsolved || FollowUp9.caseUnsolved
            || FollowUp10.caseUnsolved)
        {

            caseUnsolved = true;
        }



        if (caseSolved)
        {
            timer += Time.deltaTime;

            if (timer > 5 && timer<=10)
            {
                Endgame.SetActive(true);
                EndGameSuccess.SetActive(true);
            }
            if (timer > 10)
            {
                Endgame.SetActive(true);
                EndGameSuccess.SetActive(false);
                EndgameContinue.SetActive(true);
            }


        }
        if (caseUnsolved)
        {
            timer += Time.deltaTime;

            if (timer > 5)
            {
                Endgame.SetActive(true);
                EndGameFail.SetActive(true);
                caseUnsolved = false;
                timer = 0;
            }
        }


        if (Leo.violence > 0)
        {
            hitLeo = true;
          
        }

        if(hitLeo || arrestedLeo)
        {
            leo.SetBool("down", true);

        }

        if (arrestedLinda)
        {
            linda.SetBool("cuffed", true);

        }
        if (arrestedMike)
        {
            mike.SetBool("cuffed", true);

        }


        arrestedLeo = Leo.arrested;
        arrestedLinda = Linda.arrested;
        arrestedMike = MikeArrest.arrested||Mike.arrested;

        violence = Leo.violence + Mike.violence + Linda.violence + Cheng.violence;
        agression = Leo.agression + Mike.agression + Linda.agression + Cheng.agression;
        professional = Leo.professional + Mike.professional + Linda.professional +Cheng.professional;
        heart = Leo.heart + Mike.heart + Linda.heart + Cheng.heart;


        if (violence > 0)
        {
            violent = true;
        }
        if (agression > heart && agression > professional)
        {
            alignement = (int)Mathf.Floor(agression / 4) + 1;
            agressive = true;
        }
        if (heart > professional && heart > agression)
        {
            alignement = (int)Mathf.Floor(heart / 4) + 1;
            kind = true;
        }

        if (professional > heart && professional > agression)
        {
            alignement = (int)Mathf.Floor(professional / 4) + 1;
            prof = true;
        }
       
       /* if (script.LindaKilled)
        {
            ResetState();
            LindaKiller = true;
        }

        if (script.LeoKilled)
        {
            ResetState();
            LeoKiller = true;
        }

        if (script.MikeKilled)
        {
            ResetState();
            MikeKiller = true;
        }
        if (script.MurderWeapon)
        {
            Statue = true;
            LeoStatue = true;

        }
        if (script.unknownMurderWeapon)
        {
            Statue = false;
            LeoStatue = false;
        }
        if (script.MafiaKilled)
        {
            ResetState();
            Mafia = true;
        }

        */

       

       



        if (!MindPalace.activeSelf && Input.GetKeyDown(KeyCode.M))
        {
            MindPalace.SetActive(true);
        }
        else if (MindPalace.activeSelf && Input.GetKeyDown(KeyCode.M))
        {
            MindPalace.SetActive(false);
        }
        


    }
    public void ResetState()
    {
        Mafia = false;
        Statue = false;
        LindaKiller = false;
        LeoKiller = false;
        MikeKiller = false;
        LindaAgressive = false;
        ChengHeartbroken = false;
        FightSounds = false;
        LeoStatue = false;
        Gang = false;
    }

    public void InitiateMindPalace()
    {
        LindaKiller = Leo.FirstClue;
        LeoKiller = Linda.SecondClue || LeoDrawer.FirstClue || Leo.ThirdClue;
        Mafia = Leo.SecondClue;
        LindaAgressive = Leo.FirstClue;
        ChengHeartbroken = Leo.SecondClue || ChengDrawer.SecondClue;
        FightSounds = Linda.FirstClue;
        Gang = ChengDrawer.FirstClue;
        Statue = LeoDrawer.FirstClue;
        script.MikeKiller.SetActive(true);
        script.unknownMurderWeapon.SetActive(true);
    }



}
