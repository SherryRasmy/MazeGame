## How to play

To Win this maze game, you have to predict your steps to the treasure room without passing by the traps rooms and with the minimum number of steps. <br>
You have 3 Health Points , so use them well :).
## How to run

This maze Game is Implemented Dynamically so the player can change the maze size.<br>
As the Implementation made by third party, so now its working by Dummy Integration.<br>
You can change the maze size by only changing it in the dummy Integration.<br>
The maze game now sattled to be **3x3** size.<br>
So please use size **3** to work for now.<br>
### Philosophy 
![Maze](https://github.com/SherryRasmy/MazeGame/blob/master/Images/maze.png) <br>
The Game consists of states:<br>
1-**Start State :** where we ask the player where he wants to play or now.<br>
2-**Game Description State :** where we explain the rules to the player.<br>
3-**New Game State :** where the user can select the maze size and the application build the maze and the game begins.<br>
4-**In Progress State :** where the player navigate throw the maze until he wins or lose the game.<br>
5-**Start State :** then we repeat the start state and ask the player tp play new game.<br>

### External Libraries used

-**Colorful.Console :** to build colorful Console text. <br>
-**Alba.CsConsoleFormat :** to build the maze.<br>
-**SimpleInjector :** in dependency Injection.<br>

