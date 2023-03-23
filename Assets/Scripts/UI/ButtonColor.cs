using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public Button button;
    


  public void ChangeColor()
    {
        button.GetComponent<Image>().color = Color.red;



    }
}
