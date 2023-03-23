INCLUDE globals.ink


VAR questions = false
The woman seems to be in distress. Clearly she has been waiting here for a while before you showed up.
*[Hello M'am. I believe you were the person to make the 911 call?]
*[Hi. are you the one who called us?]
-Yes officer. I called as soon as I found him. Laying like that in a pool of blood. 
*[Ok M'am. Please state your name and address for the report.]
*[So what is your name and address Miss...]
-I am Linda. Linda Gervaise. I live ... Oh my god does it matter? I didn't kill him or anything.
*[I wasn't suggesting that. Where were you at 12.00 pm last night?] ->1a
* [Sure thing Linda. I know you didn't. I just need to get the facts. Where were you at 12.00 pm last night?] ->1b
*[Oh really? It seems to me that you did.]->1c

===1a===
Home. Sleeping.
*[Can anyone confirm it?]->1f

===1b===
I was home. Sleeping. (Your calm voice has a soothing effect on her)
*[Can anyone confirm it?]->1f

===1c===
What? How dare you. You show up after I've been here for an hour and accuse me of murder?
* [Well the simplest answers are usually true. You were the one who called. You could have killed him and then make the call.]->1d
*[Yeah, come to think about it doesn't make sense]->2a

===2a===
*[So where were you the night of the murder?]->1a

===1d===
So what now. Are you gonna arrest me?
*[Actually yes. Put your hands behind your back. ]->1e
*[No I'll let the detective over there take the reins]->DONE

===1e=== 
She complies, sobbing. 
* You have the right to remain silent. Anything you say can and will be used against you in the court of law..->DONE


===1f===
I live alone. But really, shouldn't you be looking for whoever killed that man?
*[We are in the middle of an investigation M'am. Please don't tell me how to do my job. What is your address?]
*[I'm still looking at the scene. Do not worry. We will find whoever did this. So where do you live?]

-Lincoln Ave 273. Flat number 21. Right across the street.->2f
===2f===
*[So why were you here?]->2b
*[And have you noticed anything unusual when you entered the scene?]
I do not know what is usually on a crime scene.
->2b
*[So wanna grab a beer when all this is done?]->2d

===2b===
{questions==false: I am a janitor in this building. I do maintenance. I noticed the doors were open and I looked inside. }
*[Did you notice someone leaving the building?]
~questions=true
No I haven't. It was early in the morning.
->2b
*[Did you hear any suspicious sounds?]
~questions=true
Yes I have but not in the morning. I heard some shouting from his apartment last night before I went to bed.
**What time was that?
About 10.00 I think.
(first clue)
*** Why didn't you call us then?
I didn't know this was relevant. Are you saying I'm responsible for his death? My God...
**** It is ok you couldn't have known
->2b
**** Actually yes. You should have called...
->2b

* What do you think happened?
Isn't that your job to find that out?
**I am asking for your opinion.
I honestly have no idea. Someone killed Chei. I do not know who.->2b
** Come on you must have some idea. 
No, really I have no clue.->2b
**{friendly>1} Listen Linda. It is important. Anything you say can help us catch whoever did this.
Well you can look into Leo over there. He had some argument with Chei. And he really is a dangerous man. 
(second clue)
***Why do you think he is dangerous?
I mean look at him. He is all muscles. And that face...->2b

+ [Okay that is enough questions for now.]->2e

===2c===

*[Did you notice someone leaving the building?]
*[Did you hear any suspicious sounds?]
-No I can't say that I have.->2b


===2d===
Are you serious? Are you hitting on me when there is a dead man in the apartment next door?
*[Yeah you are right it was unprofessional of me.]->2f
*[Yeah why not? So about that drink?]
(She stares at you. Daggers in her eyes. She is not going to have a drink with you. You creep...)->DONE

===2e===
*[Okay M'am thank you for your assistance. Please stay in the building until we are finished with the scene in case I have other questions.]->DONE
*[Okay Linda thank you for your assistance. I think you can go. You have waited enough.]->DONE




