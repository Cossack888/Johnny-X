INCLUDE globals.ink

VAR tookMoney =0
VAR closedEyes = 0
VAR dollars = 50
VAR putInBag = 0
VAR rubberGloves =0
VAR stared = 0

->Start
===Start===
{rubberGloves==0:The man is laying on the floor in the pool of blood. You have to assume it is his.| You put on rubber gloves. It is a good thing they are standard issue.}
*[Examine the head.]->2b
*[Look at his face]->2a
+[Check his pockets]. ->2d
*[Look at his hands.]->2c
*[Put some gloves on.]
~rubberGloves=1 
->Start
+[Leave]->3a



===2a===


{closedEyes ==0 :The cold dead eyes stare at you.|Thankfully his eyes are closed now. Forever...}

*{closedEyes==0} [Stare back at him.]
~stared=1
Clearly he is better at this than you. You have to close your eyes eventually.->2a
*{closedEyes==0}[Reach down and close his eyes.]
~closedEyes=1
You wish someone will do the same for you one day.->2a 

*[Look at his face.]
You see a Chinese man about 30 years old. There is some swelling around his right eye as if he got hit by a left hand swing.->2a  

+[Go back to examining the body.]->Start

===2b===
There is a wound on the back of his head. It seems he got hit with a heavy object.
*[Look at his face]->2a
+[Go back to examining the body.]->Start

===2c===
His hands are smooth to the touch. There is no dirt under his fingernails. 
+[Go back to examining the body.]->Start


===2d===
You reach down and check his pockets.
{putInBag==0:The only thing you find is a leather wallet.|There is nothing there}

 +{tookMoney==0} [Check inside.]->2e

+{tookMoney==1} [There is nothing in there. You made sure if that.]->2e
+{putInBag==0} [Put it back. You shouldn't have touched it anyway]
~putInBag=0
->Start
+{putInBag==1} [Put the wallet back in the dead man's pocket]
~putInBag=0
->Start
+{putInBag==0} [Put it in the evidence bag.]
~putInBag=1
->Start
+{putInBag==1}[ The wallet is safely in the bag]
->Start



===2e===

Inside there is an ID card, a condom and {dollars} dollars.
{tookMoney==1:That is suspicious!}
*[Examine the ID.]
The man's name was Chei Wong and he was 32 years old. He was a United States citizen.
**[write the name down]->2e

*[Look at the condom]
It is past its expiration date.->2e
+{tookMoney==0}[Take the money]
~tookMoney=1
~dollars=0
->2e
+{tookMoney==0}[Take half of the money]
~tookMoney=1
~dollars=25
You look around nervously. No one saw you so it doesn't count.->2e
+{tookMoney==1} [Put the money back]
~tookMoney=0
~dollars=50
->Start
+{putInBag==0} [Put it back. You shouldn't have touched it anyway]
~putInBag=0
->Start
+{putInBag==1} [Put the wallet back in the dead man's pocket]
~putInBag=0
->Start
+{putInBag==0} [Put it in the evidence bag.]
~putInBag=1
->Start
+{putInBag==1} [The wallet is safely in the bag]
->Start

===3a===
*[You have all you need.]->DONE
*[Get back to examining the body]->Start


