using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeScript : MonoBehaviour
{
    public ActivateCutscene cutscene;
    public Animator scientist;
    public Rigidbody2D flyingScientist;

    public float timer;
    public float delay=20;


    public void Update()
    {
        if (cutscene.timerOn)
        {
            timer += Time.deltaTime;
        }
        if (timer > delay)
        {
            scientist.SetBool("flying", true);
            scientist.SetBool("active", false);
            flyingScientist.velocity = new Vector2(-3, 2);
            cutscene.childAnim[0].SetBool("active", false);
            cutscene.childAnim[1].SetBool("active", false);
            cutscene.childAnim[2].SetBool("active", false);
        }

    }






}
