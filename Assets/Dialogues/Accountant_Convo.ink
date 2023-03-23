INCLUDE Globals.ink
VAR questions = false

You enter the accountant's office. He is a young man in his thirties. He has fancy glasses and a very serious face.
+[Approach him.]
{agressive==2: I heard the way you spoke to Mrs. Eve. That was not very nice.}
I suppose you are here about those wanted men we have seen around?
** [Yes I have some questions...]->1d
**{agressive==2}[You got a problem pen pusher?]
~agressive++ 
->1b

===1b===
Not as such no. I can't seem to find the form 45C the client submitted ...
Wait are you offering help or a beat down?
*[The jury is still out on this one.]->1c
*[I just need some answers.]->1d


===1c===
Well let me know if you decide. For now I have work to do. (END)->DONE


===1d===
{agressive==3: Well ask your questions.}
{agressive!=3&&questions==false: Well ask them.}
{agressive!=3&&questions==true: Is that all?}

* [Is this the man you saw? (Show him a photo of Fred Jackson)]
Yes it was.
~questions=true
->1d
*{professional>1&&armed==true}[Did you get the license plates of the car?]
Yes I did. It was 8 AFD 244. The car was a red sedan. I did not get the make or model. 
~licensePlates=true
->1d
*{professional>1&&ladyFriend==true}[Mrs. Eve said something about visiting a lady friend? Was that your impression too?]
No it was not. He had an engineer's helmet with him. That would be strange attire for a date. 
~constructionSite=true
->1d
*[Was he armed?]
No he was not. But the man he was with had a bulge under his jacket on the left hand side. It must have been a pistol. I also saw a rifle on the back seat of their car.
~questions=true
~armed=true 
->1d
*{armed==true}[So he was not alone. What did the other man look like?]
He had a face of a hardened criminal. Looked a bit like an ape in a white suit and fedora.
~notAlone=true
->1d
+[Yes that is all. I've got some bad men to catch.]
(END)->DONE
+[Yes sir, that is all]
(END)->DONE
->DONE