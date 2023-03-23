INCLUDE Globals.ink
Okay man Let us do a recap.
*Yeah, let's.

{DispatchConstructionSite==true: We are going to the construction site}
{DispatchLadyFriend==true: We are going to visit Claire Reeves at 238 North Street.}
{DispatchArmed==true: We are supposed to wait for backup.}
{DispatchArmed==false&&DispatchConstructionSite==true: We will try to get the guy}
{DispatchArmed==false&&DispatchLadyFriend==true: We will find him with his pants down.}
{DispatchLicensePlates==true: He might not be alone }
{DispatchLicensePlates==true&&DispatchLadyFriend==true: And I do not mean just Claire}
{DispatchConstructionSite==false&&DispatchLadyFriend==false: I guess we can go back to base.}
** {DispatchConstructionSite==false&&DispatchLadyFriend==false} [That is a bit anticlimactic ain't it?]
** {DispatchArmed==true}[Bugger backup. If we wait he might get away.]
**  {DispatchArmed==true}[Yes, we should wait for backup to arrive. We will just sit and wait.]
** {DispatchLadyFriend==true} [Let's go to North Street]
** {DispatchConstructionSite==true} [Let's go to the construction site.]
-Okay. Let's hit the road (You go to the location)
*[Go](End)
->END