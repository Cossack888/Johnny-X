INCLUDE globals.ink

{hitTeller1==true: You again? I didn't tell anyone. I swear. | Yes?}
+{hitTeller1==false}[You approach the teller]
Yes?->1g
+{hitTeller1==true}[I'll know if you do.]->DONE


===1g===
*{sweetOnLinda==true}[Hi. Linda says she would really appreciate it if you told me about this man on the photo. Have you seen him?]
Well yes. I suppose there is no harm in telling you. You just missed him. He went out 10 minutes ago.
**[Well I have to be quick then]->DONE
**[You should have told me sooner]->DONE
*[Hello, sir. I have questions regarding an investigation.]
*[Hi, wanna answer some questions?]
*[Stop staring man, I have important business.]
- Yes?
* [Have you seen this man?]
No I have not.
** [You haven't even looked at the photo.]
** [Look at the photo or help me god I will shove it in your face.]
- I do not need to look at the photo. Any comings and goings of our customers are subject to banking confidentiality.->1a

===1a===
If that is all...
* [Sir, this is important police business. ]
In that case please come back with a warrant.->1b
* [Look man it is really important. Would you please look at the photo?]
No.->1b
* [Look you goddamn money grubber. Either you tell me If he was or wasn't here or I'll smash your face.]
There is no point in using profanity. My position stands. ->1b


===1b===
Is that all?
* [I suppose it must be.]->1c
* [I guess...]->1c
* [Dunno]->1c
* [(Grab his neck and hit his head against the counter)]
(You resorted to violence)
~hitTeller1=true
He has a bloody nose and has lost a tooth or two. 
What the hell man?! Are you insane? I will press charges against you...->1d

===1c===
In that case please leave the premises unless you wish to make a deposit.
(END) ->DONE

===1d===
*[So are you listening to me now punk? Are you? You have one last chance to tell me. Have you seen this man?]
 Yes! Yes! God damn you I have seen him. He was here 10 minutes ago.
**[Shit. Gotta go.]
**[If you tell anyone about this I will be back.]
- He just stands there. Bleeding.(END)
-> DONE