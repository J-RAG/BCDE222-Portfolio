Version: 2 Date 06/09/2023
Added Move Functionality and it partially Works.

MOSCOW CheckList Covered: (CBD- Could be Done)
DONE>>>>>>	1. Must have a game board with correct co-ordinates
WORKS?	2. Must have movement for Rook
	3. Must have movement for King
	4. Must have movement for Queen
WORKS?	5. Must have movement for Knight
WORKS?	6. Must have movement for Bishop
DONE	7. Must be able to detect incorrect movement
DONE	8. Must have the ability to select pieces to move
DONE	9. Must not accept movement to empty squares
>>>	10. Must count total number of moves
>>>	11. Must highlight current selected piece
CBD >>>	12. Must have a reset button ~~ COULD CHANGE BUT SHOULD BE DONE>>>
FIXING	13. Must have a undo button
>>>	14. Must have a timer
>>>	15. Must show time taken to beat level
CBD	16. Must acknowledge level completion
>>>	17. Must display level name
	18. Should draw a path
	19. Could show stats after Game is finished
	20. Could highlight the moveable square when hovered over
	21. Wont have any animation of pieces


Notes: 
Input movements responds to coresponding piece and updates the board's state on doing so.
Move runs a set of methods that run movement validity and shows the availble moves the player
is allowed to do.

3 Validity Conditions:
    >Move is inbounds
    >Move is available for that "Part" (chess piece)
    >Move does not land on an Empty Space (Part.Empty/Part.PlayerOnEmpty)

List<object>History: 
	Made to store player movement log (MoveLog Object)
		MoveLog:
			(Board, PlayerCoordinates)
			Board:Can store the board's State so we can view where the player is (outsideof scope)
			PlayerCoordinates: Object Coord (int row, int col) -> postion of player on the board
Problem:
	The board does not update properly with the MoveLog object
	-MoveLog PrevMove(Board), (x, y) and CurrMove(Board, (x, y))
		- Object Referencing was updating both Log values when the move is made
		- I was able to fix the Coord by explicitly updating the values itself (inside of Scope)
		- But the object char[,] Board value has an issue due to Object referencing aswell (outside Scope)
	
The Fix:
	There is no need to further build the Board and make 
	it apart of the MoveLog as this is outside of the 
	Assignment's Scope. 	

	I will rebuild the ChessMaze soln to address the issue.
	Level builder is outside the scope and I will only need
	it to make the move() functionality work I should be
	able to cut down majority of the code within the Game 
	Class file with this.

	This Version of ChessMaze is more of a visual concept 
	on how to see it on the Console view side of things.
	By adding test cases I should be able to work with the 
	Game <<MODEL>> more effectively than testing it 
	with console coded output.
	
Things TODO Next:
> Create a New ChessMaze Soln and add any 
  Necessary Code from the Previous Versions

> Add Test Files to Test each Feature. 
	>Test at least 2 Scenarios for each function.
