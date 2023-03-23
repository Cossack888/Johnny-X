INCLUDE globals.ink

Ok. I never told you to arrest anyone. Can you tell me why that man is in handcuffs?
* [I believe he is the culprit, sir.]
Believe? So are you a believer then, son? And what about the evidence? ->evidence
* [Yeah, he did it.]
Really? And what is your evidence?->evidence


===evidence===
*{confession==true}[He told me he did it.]
He did what? How did you swing that?
**[Good old fashioned police work]
Well I'm gonna go get his statement now before he changes his mind.->goodwork
**[Eh, I actually scared him shitless]
Good enough for me. Maybe not for the D.A. but we shall see.  I'm gonna go get his statement now before he changes his mind.->goodwork
*[actually I have none.]
And yet you decided to arrest him? Are you that dense? 
 Do you know that he can sue the entire department for false arrest now? 
**[Sorry, sir]
Well sorry is not gonna cut it. Get the hell out of my crime scene. 
(CaseFailed)
->DONE
**[I just thought...]
You thought wrong. Get the hell out of my crime scene.
(CaseFailed)
->DONE



===goodwork===
You did good kid. Better than I have expected. I'll make sure you get that promotion.
(CaseSolved)
->DONE