using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Shooting : MonoBehaviour
{

   public Vector3 MousePos;
    public float speed = 10;
    public CinemachineVirtualCamera MainCamera;
    public NewMovement movement;
    public GameObject player;
    public SpriteRenderer sprite;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
       // MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      

        MousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (rotZ != 0)
        {

            if (!movement.m_FacingRight)
            {
                sprite.flipY = true;

            }
            if (movement.m_FacingRight)
            {
                sprite.flipY = false;

            }


            if (rotZ < 90 && rotZ > -90 && !movement.m_FacingRight)
            {
                movement.Flip();
               // sprite.flipY=false;
            }



            if ((rotZ > 90 && rotZ > -180 || rotZ > -180 &&  rotZ < -90    ) && movement.m_FacingRight)
            {
                movement.Flip();
               // sprite.flipY = true;
            }

        }

       


    }
}
