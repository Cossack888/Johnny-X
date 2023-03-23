using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDamage : MonoBehaviour
{
    public Restart restart;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        restart.gameOver(); 
    }




}
