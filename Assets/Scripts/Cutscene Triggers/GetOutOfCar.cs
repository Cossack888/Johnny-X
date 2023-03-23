using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutOfCar : MonoBehaviour
{
    public GameObject player;
    public GameObject prompt;
    public GameObject line;
    public GameObject lineForCars;
    public GameObject GoalFrame;
    public GameObject YellPrompt;
    public GameObject Camera;
    public GameObject DispatchConvoTrigger;
    public Vector2 pos;
    public float timer;


    public void Update()
    {
        if (player.activeSelf && !DispatchConvoTrigger.activeSelf)
        {
            timer = timer + Time.deltaTime;
        }

        if (timer > 40)
        {
            DispatchConvoTrigger.SetActive(true);
            timer = 0;
            
        }



    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
        
        if (collision.CompareTag("GetOutSpot")){
           
            pos = new Vector2(collision.transform.position.x, collision.transform.position.y);
            prompt.SetActive(true);

            if (Input.GetButton("Interact"))
            {
                YellPrompt.SetActive(false);
                player.SetActive(true);
                prompt.SetActive(false);
                lineForCars.SetActive(false);
                GoalFrame.SetActive(false);
                line.GetComponent<BoxCollider2D>().isTrigger=false;
                player.transform.position =  pos;
                this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                this.GetComponent<BoxCollider2D>().isTrigger = true;
                Camera.SetActive(false);

            }
        }
        
        
    }
}
