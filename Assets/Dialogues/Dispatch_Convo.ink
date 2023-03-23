INCLUDE Globals.ink

You hear some static and then a faint voice. 
Yes?
*[This is officer Johnny Podolsky. Badge number AS438.]->1a
* [Hi Larry. This is Johnny for the 2nd Precinct. How is the wifey?]->1b

===1a===
Hello officer. What is your situation?
->1c

===1b===
Doing just fine, thank you man.
->1c

===1c===
What is your situation?
*[I am chasing a suspect. The name is Fred Jackson. ]->1c
*{armed==true}[The suspect is armed and dangerous.]
~DispatchArmed=true
->1c
* {armed==false}[The suspect doesn't appear to be armed. ]->1c
*{constructionSite==true}[The suspect has fled to a nearby construction site. ]
~DispatchConstructionSite=true
->1c
*{constructionSite==false && ladyFriend==false}[I have no idea where the suspect went. ]->1c
* {ladyFriend==true} [The suspect is visiting a lady friend of his. I do not know the address.]
~DispatchLadyFriend=true
->1c
* {licensePlates==true} [The suspect is driving a car. License plates are 8 AFD 244]->1c
~DispatchLicensePlates=true
* {licensePlates==false} [I believe the suspect is on foot.]->1c
+ [That is all the  information  I gathered]->1d


===1d===
{DispatchConstructionSite==true: You are the closest officer to that location.}
{DispatchLadyFriend==true: He is currently involved with Claire Reeves. She lives at 238 North Street. You are the closest officer to that location.}
{DispatchArmed==true: Do not attempt to apprehend the suspect. Wait for backup.}
{DispatchArmed==false&&DispatchConstructionSite==true: You are cleared to apprehend the suspect. Proceed with care.}
{DispatchArmed==false&&DispatchLadyFriend==true: You are cleared to apprehend the suspect. Proceed with care.}
{DispatchLicensePlates==true: The car is registered to one Ricky Moon. It is a known alias of Jacksons accomplice. }
{DispatchConstructionSite==false&&DispatchLadyFriend==false: If that is all than get back to base.}
*[Copy that dispatch.]
*[Yeah Yeah...]
-Over. (END)
->DONE



