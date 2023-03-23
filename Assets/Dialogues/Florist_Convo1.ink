INCLUDE Globals.ink


A middle aged woman is running this flower shop. She smiles when you enter and says. "Hello officer. I didn't expect you to come so soon."
*[Hello M'am. I came as soon as possible.]
~professional=1
->Start
*[If only dispatch had told me I'd be meeting such a lovely lady I'd change first.]
~friendly=1
->Start
*[Yeah, yeah. Whatever...]
~agressive=1
->Start

===Start===
{professional>0: So formal. I guess that is to be expected.}
{friendly>0: (You are being kind) Aren't you a charmer dear.}
{agressive>0: Not the most pleasant fellow are you?}
I am the one who called 911. I saw that awful man here in my shop. He was buying a bouquet just like a normal fellow but I knew something was wrong immediately. He had like a thousand dollars in cash in his pocket.  
*[At what time exactly did the encounter take place?]
~professional=professional+1
->1a
*[I'm sure you were terrified when you recognized him?]
~friendly=friendly+1
->1c
*[Where is he now. Speak!]
~agressive=agressive+1
->1a

===1a===
{agressive==2: (You are being aggressive) I will not be spoken to in this tone.}
{professional>1: (You are being professional) He left 20 minutes ago. You should still be able to catch him.|I can't really tell. 30 minutes maybe? }->1b



===1b===
{agressive==2: I think you should leave|Do you have any questions?}

*[Do you know where he might be now?]
{professional==2: (You are being professional) I think he might be at the construction site. He had an engineer's helmet with him. |No I' can't say for sure.}
**{professional==2}[Yes I think that might be it.]
~location=true
~constructionSite=true
(You have found your first clue !)
->1d

**[Thank you for your assistance.]
->0END
**[Well thanks for nothing. ]

~agressive=agressive+1 
->0END
**{professional>1}[I actually have some more questions]
{friendly<2: Yes officer?.|Yes dear?}
->1d
* {agressive<2}[Actually quite a few]
Yes?
->1d
* {agressive==2}[Yeah I will leave and you can expect charges for obstruction.]
->0END


===1c===
{friendly>1: (You are being kind) It was horrible. I thought he would kill me right there. | I am a tough cookie officer. I didn't flinch.}->1d

===1d===
*[Did he carry a weapon?]
Not in my shop.
(That is your third clue)
->1d
->1d
* {professional<2}[Are you sure you do not know where he went?]
Well he was buying flowers for a lady friend. Maybe he went to visit her?
~ladyFriend=true
(You have your second clue !)
->1d
* {agressive==2} [God damn you woman! You are wasting my time!!!]
->0END
* [What did he buy?]
Lilies. A whole bouquet... Paid cash->1d
* Thank you for your assistance.
{friendly>0: Sure thing sweety.|You could have been nicer you know.}->0END
* Enough of this you old bat.
(You are being aggressive) I will report you behavior young man.->0END
* {location==true} Time to go get him.->0END



===0END===
{agressive>1: (You are being aggressive) This was not a pleasant conversation. | I hope you catch him young man.}
(END)
+[Finish]
->DONE
