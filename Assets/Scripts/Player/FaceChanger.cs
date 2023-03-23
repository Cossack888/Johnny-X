using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceChanger : MonoBehaviour
{



    public SceneManagerArcade scene;
    public Sprite LawfullFace1;
    public Sprite LawfullFace2;
    public Sprite LawfullFace3;
    public Sprite HeartFace1;
    public Sprite HeartFace2;
    public Sprite HeartFace3;
    public Sprite BrutalFace1;
    public Sprite BrutalFace2;
    public Sprite BrutalFace3;
    public Sprite NeutralFace;
    public Sprite Agression;

    public int imgNumberCount;


    void Update()
    {
        if (scene.prof==true) {
            imgNumberCount = scene.alignement ;
        }
        if (scene.agressive==true)
        {
            imgNumberCount = scene.alignement + 6;
        }
        if (scene.kind==true)
        {
            imgNumberCount = scene.alignement + 3;
        }
        if (scene.violent == true)
        {
            imgNumberCount = 10;
        }

        /* else
         {
             imgNumberCount = 0;
         }
        */


        switch (imgNumberCount)
        {

            case 0:
                GetComponent<Image>().sprite = NeutralFace;

                break;
            case 1:
                GetComponent<Image>().sprite = LawfullFace1;

                break;
            case 2:
                GetComponent<Image>().sprite = LawfullFace2;

                break;
            case 3:
                GetComponent<Image>().sprite = LawfullFace3;

                break;
            case 4:
                GetComponent<Image>().sprite = HeartFace1;

                break;
            case 5:
                GetComponent<Image>().sprite = HeartFace2;

                break;
            case 6:
                GetComponent<Image>().sprite = HeartFace3;

                break;
            case 7:
                GetComponent<Image>().sprite = BrutalFace1;

                break;
            case 8:
                GetComponent<Image>().sprite = BrutalFace2;

                break;
            case 9:
                GetComponent<Image>().sprite = BrutalFace3;

                break;
            case 10:
                GetComponent<Image>().sprite = Agression;

                break;

            default:
                Debug.Log("Error");
                break;
        }
    }


}
