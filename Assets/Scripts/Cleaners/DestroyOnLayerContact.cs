using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class DestroyOnLayerContact : MonoBehaviour
{
  
    public float timer;
    public bool TimerOn;

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TimerOn = true;
    }

    public void Update()
    {
        if (TimerOn == true)
        {
            timer += Time.deltaTime;
        }

      
        if (timer > 2)
        {
            Destroy(gameObject);
        }

    }

    
}
