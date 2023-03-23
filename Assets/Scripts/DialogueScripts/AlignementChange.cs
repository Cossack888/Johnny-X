using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignementChange : MonoBehaviour
{
    public DialogueManager conversation;
    public int agression = 0;
    public int heart = 0;
    public int professional = 0;
    public int violence = 0;
    public string textOnScreen;
    public bool FirstClue;
    public bool SecondClue;
    public bool ThirdClue;
    public bool finished;
    public bool arrested;
    public bool caseSolved;
    public bool caseUnsolved;




    void Update()
    {
        
        if (conversation.isActiveAndEnabled)
        {
            textOnScreen = conversation.CurrentText;





            if (textOnScreen.Contains("(You are being agressive)"))
            {

                agression = conversation.agression;

            }

                if (textOnScreen.Contains("(You are being kind)"))
                {
                heart = conversation.heart;
                }
                if (textOnScreen.Contains("(You are being professional)"))
                {
                professional = conversation.professional;
                }
            if (textOnScreen.Contains("(You resorted to violence)"))
            {
                violence = conversation.violence;
            }


        }
        if (textOnScreen.Contains("first clue"))
        {
            FirstClue = true;
        }

        if (textOnScreen.Contains("second clue"))
        {
            SecondClue = true;
        }

        if (textOnScreen.Contains("third clue"))
        {
            ThirdClue = true;
        }

        if (textOnScreen.Contains("You have the right to remain slient"))
        {
            arrested=true;
        }
        if (textOnScreen.Contains("(End)"))
        {
            finished = true;
        }
        if (textOnScreen.Contains("(CaseSolved)"))
        {
            caseSolved = true;
        }
        if (textOnScreen.Contains("(CaseFailed)"))
        {
            caseUnsolved = true;
        }


    }
    }


