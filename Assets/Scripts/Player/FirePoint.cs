using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;
    public int shots;
    private float timer;
    public float delay=1;




    // Update is called once per frame
    void Update()
    {
        if(shots!=0)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && (timer > delay || timer==0))
        {
            
            shots++;
            

            if (shots != 6 )
            {
                Instantiate(bullet, transform.position, transform.rotation);
                source.PlayOneShot(clip);
                timer = 0;
            }
            
            if (shots == 6)
            {
                source.PlayOneShot(clip2);
                shots = 0;
                timer = 0;
            }
           
        }
    }
}
