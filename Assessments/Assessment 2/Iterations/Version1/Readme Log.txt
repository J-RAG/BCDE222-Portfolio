Version: 1 Date 30/08/2023
-Created a Hard Coded Level that is required to implement the Move's Section

MOSCOW CheckList Covered: (CBD- Could be Done)
DONE	1. Must have a game board with correct co-ordinates
	2. Must have movement for Rook
	3. Must have movement for King
	4. Must have movement for Queen
	5. Must have movement for Knight
	6. Must have movement for Bishop
	7. Must be able to detect incorrect movement
	8. Must have the ability to select pieces to move
	9. Must not accept movement to empty squares
DONE	10. Must count total number of moves
DONE	11. Must highlight current selected piece
CBD	12. Must have a reset button ~~ COULD CHANGE BUT SHOULD BE DONE
CBD	13. Must have a undo button
DONE	14. Must have a timer
DONE	15. Must show time taken to beat level
	16. Must acknowledge level completion
DONE	17. Must display level name
	18. Should draw a path
	19. Could show stats after Game is finished
	20. Could highlight the moveable square when hovered over
	21. Wont have any animation of pieces


Notes: 
~Player is able to input a "action" and an in game action will be respond
 dependant on the input given to the program. 

~RunAction(action) method is incomplete: 
 Needs to address the DEFAULT case Scenario as any input, excluding the cases 
 above. We will have to address WHAT is condsidered a VALID input and break 
 it out of the switch and not in the DEFAULT Case.

~Undo() is partially completed:
 we need to address the Move() feature in order continue completing the Undo
 feature for the PlayerHistory Dynamic Array that holds the MoveLog Objects 

~Resest Could be done:
 If we add more Properties to the Game Class we need to keep in mind whether
 these Values are required to be resetted as well. Reset Feature might need to
 Reupdated in the future if this be the case. 

~Have not Implemented the Moves until we have addressed how the 
User will input how to move. We will decide how to take on 
that in the next version.  

~Direction Class Unused:
 Will need to be addressed and what to do with it. This will affect how
 move() function will work. 