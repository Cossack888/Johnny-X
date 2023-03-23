INCLUDE Globals.ink

{hitTeller1==true: You again? I didn't tell anyone. I swear. | Yes?}
+{hitTeller1==false}[You approach the teller]
Yes?->1a
+{hitTeller1==true}[I'll know if you do.]->DONE

===1a===
I have nothing more to add. Either come back with a warrant or do not come back at all->DONE