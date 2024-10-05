# Labb2-OOP
## Dungeon crawler
Second assignment of the C# programming course in the .NET development program at IT-Högskolan. The task is to create a console application for a dungeon crawler game using Object-Oriented Programming (OOP).

## Dungeons
The first dungeon is read from the Level1.txt file. When the player finds a dungeon exit object( **>** ), they move on to the next dungeon. All subsequent dungeons after the first are procedually generated.

### Generating the dungeons
To generate the new dungeons, I have chosen to start by creating a 2D array of a specified size (i.e., 20x60) filling it with wall objects( **#** ). I then remove wall objects by applying a random walk algorithm for rooms and another for corridors.

### Random walk algorithm
Starting at an x, y coordinate inside the 2D array, an 'agent' will randomly move one step up, right, down, or left as long as the new x, y coordinate is within the set bounds. If the new x, y position holds a wall object, it will be removed. At the current setting, the agent will take between 70 and 120 steps during each iteration. Every new iteration of the algorithm starts at the x, y position where the previous iteration ended.

### Creating corridors
After each iteration of the previous algorithm, a second algorithm is applied. Similar to the first, the agent is given a random direction. The agent then moves 15 steps in the specified direction, removing all wall objects along the way. After this is completed, one iteration of the algorithm set is finished, and a new one starts from the end position of the last.

### Adding level elements to the dungeon
When the outlining of walls and the floor is completed, level elements are randomly added to the dungeon. One starting position for the player ( **@** ) and one dungeon exit ( **>** ) are included.

To add the level elements, they are given a random x, y position within the 2D array. If the position already contains an object, it will be assigned a new random position until an empty position is found.

A random number of enemies, such as rats ( **r** ) and snakes ( **s** ), are also added to the dungeon in this manner.

