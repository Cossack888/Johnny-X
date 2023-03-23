using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ActivateCutscene : MonoBehaviour
{
    public GameObject enemy;
    public GameObject cam1;
    public Animator anim;
    private Spawner spawner;
    
    private float timer;
    public float delay;
    public AudioSource source;
    public AudioClip clip;
    private bool clipPlayed;
    public bool timerOn;
    public Animator[] childAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cam1.activeSelf)
        {

            if (clipPlayed == false)
            {
                source.PlayOneShot(clip);
                clipPlayed = true;
            }
            


            timer += Time.deltaTime;
            
            if (timer > delay)
            {
                cam1.SetActive(false);

            }
        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            spawner = GetComponentInChildren<Spawner>();
            spawner.active = true;
            cam1.SetActive(true);
            childAnim = enemy.GetComponentsInChildren<Animator>();
            timerOn = true;

            for (int i = 0; i < childAnim.Length; i++)
            {
                if (childAnim[i])
                {
                    childAnim[i].enabled = true;
                    childAnim[i].SetBool("active", true);
                }
            }


          
        }


    }
}
