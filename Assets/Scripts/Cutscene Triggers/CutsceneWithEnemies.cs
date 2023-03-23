using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneWithEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject robotBoss;
    public Animator anim;
    private Spawner spawner;

    private float timer;
    public float delay;
    public AudioSource source;
    public AudioClip clip;
    private bool clipPlayed;
    Chase[] childChase;
    RobotFighter robot;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
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
                
                clipPlayed = true;
            }



            timer += Time.deltaTime;

            if (timer > delay / 2 && timer < delay)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
                source.PlayOneShot(clip);
            }
            
            
            if (timer > delay)
            {
                cam1.SetActive(false);
                cam2.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
          
            rb = robotBoss.GetComponent<Rigidbody2D>();
            rb.gravityScale = 20;
            rb.bodyType = RigidbodyType2D.Dynamic;
            sprite = robotBoss.GetComponent<SpriteRenderer>();
            sprite.enabled = true;
            robot = robotBoss.GetComponent<RobotFighter>();
            robot.enabled = true;
            
            //spawner = GetComponentInChildren<Spawner>();
           // spawner.active = true;
            cam1.SetActive(true);
            childChase = enemy.GetComponentsInChildren<Chase>();

            for (int i = 0; i < childChase.Length; i++)
            {
                if (childChase[i])
                {
                    childChase[i].enabled = true;
                    
                }
            }
            


        }


    }


}
