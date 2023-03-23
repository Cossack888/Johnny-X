
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
*[It was Leo Mann. The man standing over there.] 
Ok. What is your proof?
** [Actually I have none.]
->1b
** [He had a bloody statue of a falcon in his drawer.]
You entered his apartment without a warrant?
*** [Yes I did. Is that a problem? ]
I'll figure it out. Give me the statue for now.
**** [(you pass on the statue)] ->1c

+[No, that is all.]

** [He just seems guilty.]
->1b


===1b===
Well I suppose that is on me for sending a rookie to do a detective's job. We are done here...
(CaseFailed)
->DONE

===1c===
Nicely done kid. Go write your report and I'll take him in.
(CaseSolved)
->DONE