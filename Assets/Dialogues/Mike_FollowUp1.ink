
VAR reset = false

->start
===start===

{reset==false:So what are the news?}
*[I believe I have found the culprit.]->1a
*[I know who did it!]->1a
+[I still need more time.]

Come back when you are ready
~reset=true
->start

===1a===
Well do not keep me in suspense. 
*It was Linda Gervaise. The woman standing over there. 
Ok. What is your proof?
** Actually I have none.
->1b
** She has a history o violence towards the victim. She was his girlfriend but they broke up.
Where do you get this information? 
*** The neighbor told me. 
Do you have anything else?
**** I have a photo of her and the victim. ->1c

+[No, that is all.]
** She was the one who called 911. She could have killed him an then made the call.
->1b
** She just seems guilty.
->1b


===1b===
Well I suppose that is on me for sending a rookie to do a detective's job. We are done here... 
(CaseFailed)
->DONE

===1c===
Nicely done kid. Go write your report and I'll take her in.
(CaseFailed)
->DONE