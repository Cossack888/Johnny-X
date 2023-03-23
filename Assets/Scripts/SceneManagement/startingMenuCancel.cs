using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingMenuCancel : MonoBehaviour
{
    public GameObject menu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            menu.SetActive(false);
        }
    }
}
