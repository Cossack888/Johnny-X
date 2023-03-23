INCLUDE Globals.ink
You approach the woman
+[Continue]
{hitTeller1==true: Please sir. We do not keep any money here. It is all in the vault.|Good morning sir. What can I do for you?}
**{hitTeller1==true} [It is ok. I am a policeman conducting investigation.]
Well You could have fooled me. Look what you did to poor Greg. I am calling the police. Real police this time... (END) ->DONE
**{hitTeller1==false}  [I am conducting an investigation. Have you seen this man?]
No I have not but I only just came in. Greg could tell you more I suppose but he is very strict.

->1a

===1a===
*{friendly>0} [Is there anything you can tell me that would help me convince Greg?]
Well you could tell him I asked. He is a bit sweet on me you know.
~sweetOnLinda=true
->1b 
* [Well I suppose I have to get back to my case.]
(END)
->DONE




===1b===
* [Thank you very much. Can't say I don't understand Greg. You are a keeper.]
~friendly=friendly+1
(END) ->DONE 
* Thank you very much.
(END) ->DONE
