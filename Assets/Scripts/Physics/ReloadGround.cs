using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGround : MonoBehaviour
{
    public float timer;
    public bool timerOn;
 
    public GameObject groundPrefab;
    // Start is called before the first frame update
    public void Start()
    {
        Instantiate(groundPrefab, this.transform.position, this.transform.rotation, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (timerOn)
        {
            timer += Time.deltaTime;
        }

        if (timer > 3)
        {
            Reload();
            timer = 0;
            timerOn = false;
        }
                    }
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>().CompareTag("Player"))
        {
            timerOn = true;
        }
    }



    public void Reload()
    {
        Instantiate(groundPrefab, this.transform.position, this.transform.rotation, gameObject.transform);
    }


}
