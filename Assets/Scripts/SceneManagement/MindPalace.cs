using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindPalace : MonoBehaviour
{
    public SceneManagerArcade scene;
    public GameObject armed;
    public GameObject unarmed;
    public GameObject Lady;
    public GameObject Construction;
    public GameObject licencePlates;


    public bool weaponOn=false;
    public bool weaponOff=false;
    public bool ladyFriend=false;
    public bool constructionSite=false;
    public bool locationUnknown=false;
    public bool licensePlatesKnown=false;
    public bool licensePlatesUnknown=false;








    void Update()
    {
       
        if (scene.armed &&weaponOff==false)
        {
           
            armed.SetActive(true);
        }
        if (scene.Lady && locationUnknown == false)
        {
            Lady.SetActive(true);
        }
        if (scene.Construction && locationUnknown==false)
        {
            
            Construction.SetActive(true);
        }
        
        
        
        if (scene.licencePlates && licensePlatesUnknown == false)
        {
            
            
            licencePlates.SetActive(true);
        }
        if (scene.unarmed && weaponOn == false)
        {
          
            unarmed.SetActive(true);
        }
    }

    public void ChooseOne()
    {
        weaponOn = true;
        unarmed.SetActive(false);
        
        
    }
    public void ChooseTwo()
    {
        weaponOff = true;
        armed.SetActive(false);
        
    }
    public void ChooseThree()
    {
        ladyFriend = true;
        
        Construction.SetActive(false);

    }
    public void ChooseFour()
    {
        constructionSite= true;
        ladyFriend = false;
       

    }
    public void ChoosefFive()
    {
        locationUnknown = true;
        constructionSite = false;
        ladyFriend = false;

    }
    public void ChooseSix()
    {
        licensePlatesKnown = true;
        licensePlatesUnknown = false;

    }
    public void ChooseSeven()
    {
       licensePlatesUnknown = true;
        licensePlatesKnown = false;

    }









}
