INCLUDE globals.ink

VAR firstdrawer = 0
VAR seconddrawer = 0
VAR thirddrawer = 0
VAR fourthdrawer = 0
VAR taken = false


You stand in front of Leo's dresser. Do you dare open it?
*[No, you shouldn't be here anyway]
You step away. ->DONE
*[Yes, this is why you are here]->1a

===1a===

Where are we searching?
* [Top drawer.]->1b
* [Second drawer]->1c
* [Third drawer]->1e
* [Fourth drawer]->1f
+ [Leave the drawers alone]->DONE
===1b===
{firstdrawer==0:The drawer is full of T-shirts.}
+[Search thoroughly]
~firstdrawer++ 
{firstdrawer:
- 1: A T-shirt with a smiling cat.
- 2: A T-shirt with a fist and the words PAIN.
- 3: A T-shirt with no sleeves.
- 4: A T-shirt with an anime character. You don't know the name.
- 5: A T-shirt with a gym name. "Ricko's muscle factory"
- 6: A plain white T-shirt.

- else: There are t-shirts inside, nothing out of the ordinary.
}
->1b
+[Leave it]->1a

===1c===
{seconddrawer==0:The drawer is full. It contains pants.}
+[Search thoroughly]
~seconddrawer++ 
{seconddrawer:
- 1: Black suit pants.
- 2: Sweatpants.
- 3: Short pants.
- 4: Short pants. 
- 5: Green sweatpants.
- 6: Blue jeans.
- 7: Suit pants.
- 8: You have found a statue of a falcon. It has blood on it!
(first clue)
~statueFound=true

- 9: Just pants
- 10: Just pants
- 11: Just pants
- 12: Just pants

- else: Just pants
}
->1c
*{statueFound==true&&taken==false} [Take the statue.]
~taken=true
->1c
*{statueFound==true&&taken==false} [Put the statue in the evidence bag.]
~taken=true
->1c

+[Leave it]->1a

===1e===
The drawer is full of underwear and socks.
+[Search thoroughly]->1e
+[Leave it]->1a

===1f=== 
{fourthdrawer==0:There is training equipment in here.}
+[Search thoroughly]
~fourthdrawer++ 
{fourthdrawer:
- 1: Joga mat.
- 2: Sweatpants.
- 3: A tonfa.
- 4: Kettle bell.
- 5: Blue sweatpants.
- 6: Jump rope.
- 7: Dumbbells.
- 8: Battle rope.

- else: Nothing interesting.
}->1f
+[Leave it]->1a




