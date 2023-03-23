using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoSwitch : MonoBehaviour
{
    public int convNumber;
   
    public GameObject firstconvo;
    public GameObject Linda;
    public GameObject Leo;
    public GameObject Mafia;
    public GameObject Mike;
    public GameObject hitLeo;
    public GameObject arrestedLinda;
    public GameObject arrestedMike;
    public GameObject arrestedLeo;
    public GameObject secondConvo;
    public GameObject conv11;
    public CSIMindPalace mindPalace;
    public CSISceneManager scene;
    public GameObject dialogueMenu;
    public AlignementChange choices;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (scene.releasedLinda)
        {
            convNumber = 10;
            choices = conv11.GetComponentInParent<AlignementChange>();
        }


        if (scene.hitLeo)
        {
            convNumber = 5;
            choices = hitLeo.GetComponentInParent<AlignementChange>();
        }
        if (scene.arrestedLinda&&!scene.releasedLinda)
        {
            convNumber = 6;
            choices = arrestedLinda.GetComponentInParent<AlignementChange>();
        }
        if (scene.arrestedMike)
        {
            convNumber = 7;
            choices = arrestedMike.GetComponentInParent<AlignementChange>();
        }
   
        if (scene.arrestedLeo&&mindPalace.Statue)
        {
            convNumber = 8;
            choices = arrestedLeo.GetComponentInParent<AlignementChange>();
        }



        else
        {
            if (mindPalace.LindaKilled)
            {
                convNumber = 1;
                choices = Linda.GetComponentInParent<AlignementChange>();

            }
            if (mindPalace.LeoKilled&&mindPalace.Statue)
            {
                convNumber = 2;
                choices = Leo.GetComponentInParent<AlignementChange>();

            }
            if (mindPalace.LeoKilled && !mindPalace.Statue)
            {
                convNumber = 9;
                choices = Leo.GetComponentInParent<AlignementChange>();

            }


            if (mindPalace.MafiaKilled)
            {
                convNumber = 3;
                choices = Mafia.GetComponentInParent<AlignementChange>();

            }
            if (mindPalace.MikeKilled&&scene.arrestedMike==false)
            {
                convNumber = 4;
                choices = Mike.GetComponentInParent<AlignementChange>();

            }
           
        }
        
     

        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueMenu.SetActive(true);
            switch (convNumber)
            {

                case 0:
                    ResetConvo();
                    firstconvo.SetActive(true);

                    break;
                case 1:
                    ResetConvo();
                    Linda.SetActive(true);

                    break;
                case 2:
                    ResetConvo();
                    Leo.SetActive(true);

                    break;
                case 3:
                    ResetConvo();
                    Mafia.SetActive(true);

                    break;
                case 4:
                    ResetConvo();
                    Mike.SetActive(true);

                    break;
                case 5:
                    ResetConvo();
                    hitLeo.SetActive(true);

                    break;
                case 6:
                    ResetConvo();
                    arrestedLinda.SetActive(true);

                    break;
                case 7:
                    ResetConvo();
                    arrestedMike.SetActive(true);

                    break;
                case 8:
                    ResetConvo();
                    arrestedLeo.SetActive(true);

                    break;
                case 9:
                    ResetConvo();
                    secondConvo.SetActive(true);

                    break;
                case 10:
                    ResetConvo();
                    conv11.SetActive(true);

                    break;

                default:
                    Debug.Log("Error");
                    break;
            }



        }
    }
 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ResetConvo();
            dialogueMenu.SetActive(false);
         
        }
    }
    public void ResetConvo()
    {
        firstconvo.SetActive(false);
        Linda.SetActive(false);
        Leo.SetActive(false);
        Mafia.SetActive(false);
        Mike.SetActive(false);
        hitLeo.SetActive(false);
        arrestedLinda.SetActive(false);
        arrestedMike.SetActive(false);
        arrestedLeo.SetActive(false);
        secondConvo.SetActive(false);
        conv11.SetActive(false);
       

    }


}
