INCLUDE globals.ink

VAR clicked = 0
VAR dollars = 1000
VAR change = 20
VAR founddollars = false
VAR foundchange = false
VAR gunFound = false
->1a
===1a===
Dresser is in good shape. Seems new. There are three drawers.
*[Open the top drawer]->1b

*[Open the middle drawer]->1c
*[Open the bottom drawer] ->1e
+[Leave it be]->DONE



===1b===
The drawer is full.
+[Search thoroughly]
~clicked++ 
{clicked:
- 1: There is a white dirty handkerchief in one of the hoodies. Eeek.
- 2: There is a nice cameo t-shirt.
- 3: There is a blouse with a motorcycle club name on it.
- 4: There is a rabbit on one of the t-shirts. It is fluffy.
- 5: Damn there was a spider in here!
- 6: There is a hoodie with a snake on it. A sleeveless t-shirt also has the same snake.
- 7: There are t-shirts and blouses inside. In one of them there is a picture of the victim with the girl from the hallway.(second clue).
- 8: There are t-shirts and blouses inside.
- 9: There are t-shirts and blouses inside.
- 10: There are t-shirts and blouses inside.
- 11: There are t-shirts and blouses inside.
- 12: There are t-shirts and blouses inside.
- 13: You find {dollars} dollars in one of the pockets.
~founddollars=true
- else: There are t-shirts and blouses inside.
}
->1b
+{founddollars==true} [Take the money for yourself.]
~founddollars=false
->1b
+{founddollars==true} [Put the money in the evidence bag.]
~founddollars=false
->1b
+[Leave it]->1a

===1c===
The drawer is full. It contains pants.
+[Search thoroughly]
~clicked++ 
{clicked:
- 1: Blue jeans. Nothing in the pockets.
- 2: Sweatpants - violet. No pockets.
- 3: Green cameo cargo pants. Searched through all the pockets. Nothing.
- 4: Black jeans. Nothing interesting. 
- 5: Blue sweatpants.
- 6: Green jeans.
- 7: Suit pants. Fine material.
- 8: There is a gun in here! A 9mm Beretta. Interesting.(first clue)
~gunFound = true
- 9: Just pants
- 10: Just pants
- 11: Just pants
- 12: Just pants
- 13: You find {change} dollars in change in one of the pockets.
~foundchange=true
- else: Just pants
}
->1c
+{gunFound==true} [Take the gun for yourself.]
~gunFound=false
->1c
+{gunFound==true} [Put the gun in the evidence bag.]
~gunFound=false
->1c
+{foundchange==true} [Take the money for yourself.]
~foundchange=false
->1c
+{foundchange==true} [Put the money in the evidence bag.]
~foundchange=false
->1c

+[Leave it]->1a

===1e===
The drawer is full of underwear and socks.
+[Search thoroughly]->1e
+[Leave it]->1a








