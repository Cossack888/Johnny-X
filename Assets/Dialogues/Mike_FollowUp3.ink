
VAR reset = false

->start
===start===

{reset==false: So what are the news?}
*[I believe I have found the culprit.]->1a
*[I know who did it!]->1a
+[I still need more time.]

Come back when you are ready
~reset=true
->start

===1a===
Well do not keep me in suspense. 
*[It was a gang hit.] 
Ok. What is your proof?
** [Actually I have none.]
->1b
** [The victim had a gun and gang attire in his room]
What was the gang?
*** [I do not recognize them. It is a snake.]
I'll figure it out. Give me the gun for now.
**** [(you pass on the gun)] ->1c

+[No, that is all.]

** [It just reeks of gangsters.]
->1b
** [Leo Mann over there told me that gangsters often visited the victims apartment.]
->1b

===1b===
Well I suppose that is on me for sending a rookie to do a detective's job. We are done here...
(CaseFailed)
->DONE

===1c===
Nicely done kid. Go write your report and I'll keep investigating.
(CaseFailed)

->DONE