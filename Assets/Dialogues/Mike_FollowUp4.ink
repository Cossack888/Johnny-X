
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
+[Actually forget it]->1b
*[It was you. You killed him.] 
Well that was unexpected. What is your proof?
** [Actually I have none.]
->1b
** [Put your hands behind your back. You are going down.]
->arrest
** [You seem guilty]
->1b



** [Look I do not care that you killed him but I want compensation for keeping it to myself.]
->1b
++[Nothing, that is all.]->1b

===1b===
I have a feeling you are a fucking clown. We are done here...
(CaseFailed)
->DONE

===arrest===
Are you crazy kid? You can't do something like that.
*[Yeah maybe you are right. I'll give you a pass this time.]
*[My principles are like iron. You are going to prison.]
- He is too dumbfounded to protest when you cuff him.
* You have the right to remain silent. Anything you say can and will be used against you in the court of law..
(CaseFailed)
->DONE

