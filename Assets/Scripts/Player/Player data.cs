using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;
    public int FinnConvo;
    public int DispatchConvo;
    public int FloristConvo;
    public int AccountantConvo;
    public int Teller1Convo;
    public int Teller2Convo;
    public bool shotgun;
    public bool easyModeData;


    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;
        FinnConvo = player.FinnConvo;
        DispatchConvo = player.DispatchConvo;
        FloristConvo = player.FloristConvo;
        AccountantConvo = player.AccountantConvo;
        Teller1Convo = player.Teller1Convo;
        Teller2Convo = player.Teller2Convo;
        shotgun = player.shotgun;
        easyModeData = player.easyModeData;


        position = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;


    }
}
