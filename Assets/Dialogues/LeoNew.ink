INCLUDE globals.ink

VAR aggro = 0
VAR prof = 0
VAR nice = 0
VAR questionsAsked=false
VAR bar = false
VAR lucien = false

So what is it that you want? 
* [Good morning sir. I have a few questions about the events of last night]
~prof++
Yeah ? And I don't feel like answering them copper.->1a
* [Hi I have a few questions, about last night. Can you answer them?]
~nice++
Nah. I don't feel like answering them copper.->1a
* [Straighten up scum !!! You look like a sorry excuse for a human being !] 
~aggro++
Fuck you copper! Wonder how you would look if you have been drinking all night!->2nd

===1a===


* [We can do this here or at the precinct. It is all the same to me. But you will lose a good few hours.]
~prof++
* [Look man, I had a long wait for that bozo over there. Do me a solid and answer the questions?]
~nice++
-
Okay man. I was just kiddinging. What do you want to know.
->3rd
*   [Ok that's enough. I'm taking you in for obstruction.] 
Oh yeah? You and what army?
->army

===2nd===
* [I'm sorry sir. I don't know what came over me.]
~prof++
You really should be careful with a mouth like that.
->angry

*[Look dude I'm sorry ok? Sometimes I feel like something else is controlling me. Making me do all those things...]
~nice++
Yeah I get that. Sometimes i get this feeling too when I'm on a bender. 
->3rd

*[Fuck you too! I'm taking you in for assault on an officer!]
~aggro++
Oh yeah? You and what army?
->army

===3rd===
{questionsAsked==false:So what else you wanna know?}
* [Where were you at 12.00 pm last night? ]
~questionsAsked=true
I was out. Drinking ... heavily ... Man my head hurts.
**[Did you try Alka-Seltzer? I hear it works wonders... Oh and what bar did you go to?]
Tried that but it doesn't work on a hangover like mine. I was at Kristoff's all night. Lucien, the bartender can confirm.
~lucien=true 
~bar=true
->3rd 
**[It is your own fault. Now answer the question. WHERE were you drinking?]
You are really testing me here. A bar. Kristoff's.
~bar=true
->3rd
** [I am sorry you are in pain but this is police business. Where were you drinking?]
A bar ... Kristoff's.
~bar=true
->3rd

* [What is your relation to the victim?]
~questionsAsked=true
Barely knew the guy. Sometime our mail got mixed up and I had to get it from him. Seemed a good enough chap.
** [Anything you can tell me about him?]
Nothing to tell. He kept to himself. I think he used to date that broad over there. She might tell you more.
*** [What was their relationship like? ]
Hard to tell. I think she was being a bit jealous. They argued a lot. (first clue)->3rd
*** [Funny she never mentioned it.]
Yeah I would expect that. They were fighting a lot and she doesn't want to be considered a suspect. She actually hit him once in the hallway. (first clue) -> 3rd
** [Sir this is a murder investigation. I would appreciate you being a little more forthcoming.]
Okay I didn't want to say bad thing about a dead guy but he was a bit of an odd sort. Sometimes strange people came and went.
***[What kind of strange people?]
 The kind that you don't look at too much. Gangsters I think.
 (second clue)
 ->3rd
***[Okay you are just making stuff up.]
Believe what you will man. ->3rd
***[Strange people like what? The mafia? Illuminati? Give me something to work with here.]
 The kind that you don't look at too much. Gangsters I think.
  (second clue)
 ->3rd

*{lucien==true} [What is the bartender's number?]
Hell if I know. We are not friends or nothing like that. But he works nights. You will find him there.->3rd
*{lucien==false&&bar==true} [Can anyone confirm that? Any friends you went out with?]
No, I was alone. But the bartender can confirm. His name is Lucien.
~lucien=true 
->3rd

* [You murdered him didn't you? I know you did.] 
Fuck you man. This conversation is over. You want to accuse me of anything you can do it at the station. I didn't touch the guy.
** [Okay, maybe I was a bit rash. Sorry. ]
Well maybe you should learn to keep that big mouth shut.
->angry
** [Damn this police work is hard. ]
->DONE
**[ I think you did. I'm taking you in. ]
Oh yeah? You and what army?
->army

+ [Okay We are done here. Please do not leave the building until we are done with the crime scene.]
I'm not going anywhere.->DONE

===army===
*[I don't need an army to take you down. Ever heard of tasers?]
"Flexes his muscles." Wanna go? Think you are quick enough?
**Shoot him with a taser.
(He goes down with a bang) ->goneDown
**Kick him in the groin.
(He goes down with a bang) ->goneDown
**Punch him in the face.
(He goes down with a bang) ->goneDown


*[On second thought I think I changed my mind.] 
Yeah. Thought so.(END)->DONE
* {aggro>1} Make my day. Punk. I fucking dare you...->Intimidation
* {aggro>1} You have a choice here. Make a good one...->Intimidation

* [It doesn't have to come to that. Just answer the questions.]
Well I don't feel like it. Wanna grab me for something I didn't do you can go ahead.
->falseArrest
* [Look be cool man and answer the damn questions]
Fine. Whatever. Geez.
->3rd




==goneDown===
(You resorted to violence)
* [You have the right to remain slient. Anything you say can and will be used against you in the court of law..]
* [Ups. Gonna have to explain that now.] 
* [Yeah. I win!!!  ]
* [Yeah. I win!!! (Kick him) ]
-He is not getting up anytime soon.
 ->DONE

===Intimidation===
Okay. Damn you copper. I had an argument with him last night. We fought. It was an accident. 
(third clue)
* You have the right to remain slient. Anything you say can and will be used against you in the court of law..
~confession=true
(you got the confession) ->DONE
* [Yeah. I win bitch!]
~confession=true
You have the right to remain slient. Anything you say can and will be used against you in the court of law..
(you got the confession) ->DONE

===angry===
He is clearly testing you...
* [You do not get to lecture me motherfucker. Start answering questions or I push your face in.]
Oh yeah? You and what army? ->army
* [Sir, this is really uncalled for.]
* [Look man, let us start over.]
- We are done here. Get the fuck out of my face.
->DONE


===falseArrest===
*[On second thought I think I changed my mind.] 
Yeah. Thought so.(END)->DONE
*[I think I just might.]
He stares at you as if looks could kill. 
** [You have the right to remain slient. Anything you say can and will be used against you in the court of law..]
He takes a swing at you!
***[(block the punch and hit him back)]
***[(move out of the way and kick him. Hard.)]
***[(move out of the way and shoot him with a taser.)]
-He goes down.
-> goneDown




