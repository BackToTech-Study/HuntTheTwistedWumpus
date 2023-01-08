# The Game
- [ ] The game can only be played with an odd number of players

# The Cave
- [ ] The cave is a collection of rooms
- [ ] The cave will contain 4 rooms with a pit

# The Cave Room
- [ ] Each room will be connected to other rooms acording to the schema

![Cave Map](https://github.com/BackToTech-Study/HuntTheWumpus/blob/main/Resources/CaveMap.png)

- [ ] There are 2 type of rooms
  - [ ] Pit
  - [ ] Regular
- [ ] Regular rooms can hold people
- [ ] Regular rooms can hold 1 bat
- [ ] Regular rooms can hold the Wumpus
- [ ] Regular rooms can hold Magic Bows
- [ ] All room types can hold Pebbles
- [ ] At the start of the game all players will be placed in Room 1
- [ ] At the start of the game in Room 1 there will X magic bows. Where X = floor(number of players / 2) + 1
- [ ] At the start of the game in Room 1 there will Y pebbles. Where Y = floor(number of players / 2) + 1

# The Player
- [ ] The players will take turns making actions
- [ ] The first player will be chosen at random
- [ ] At the start of the game all players will be informed of theyr position in the list
- [ ] At the end of his turn the player will inform the next player in the list that is't his/her turn
- [ ] When a player starts his/her turn the other players will be informed
- [ ] A player can execute one command per turn
- [ ] If the player who's turn it is does not make any action within a predefined duration (1minute), his/her turn ends automatically
- [ ] A player can have either the Pebble or the Magical Bow at one time
- [ ] At the start of his/her round each player with a magical bow receives 1 arrow
- [ ] The player can be alive or dead
- [ ] A dead player can still receive messages but can no longer send commands

# The Wumpus
- [ ] The Wumpus will be placed in a randomly selected room that is not a pit room and has no players or Giants Bats in it

# The Giant Bat
- [ ] The Giant Bats will be placed in 2 different randomly selected rooms that are not pit rooms and have no players in it

# Player Command Types
- [ ] Pick up Magical Bow
  - [ ] If the player picks up a magical bow and already has a pebble, the player will automaticaly drop the pebble in the current room
- [ ] Drop magical bow in the current room
  - [ ] If the player drops the bow he looses the arrow
- [ ] Pickup pebble 
  - [ ] If the player picks up a pebble and already has a magical bow, the player will automaticaly drop the magical bow in the current room
- [ ] Drop pebble in the current room
- [ ] Throw the pebble in an adiacent room if he/she has a pebble 
- [ ] Shoot an arrow in an adiacent room if he/she has a magical bow and an arrow 
- [ ] Hit by an arrow
  - [ ] If a player is hit by an arrow the player will die
- [ ] Die
  - [ ] If a player dies he/she will scream
  - [ ] When the player dies he will drop the pebble or magic bow that he has in his/her posession
- [ ] Walk in an adiacent room 
- [ ] Wisper 
  - [ ] When a player wispers the wispers sound he/she makes will have a propagation distance of 0
- [ ] Speak
  - [ ] When a player speaks the sound he/she makes will have a propagation distance of 0
- [ ] Scream
  - [ ] When a player speaks the sound he/she makes will have an infinte propagation distance


# Room Command Types
- [ ] Pebble dropped in this room
  - [ ] When the pebble is dropped or falls in a room that is not a pit, it will make a "click" sound with the propagation distance 1
  - [ ] When the pebble is dropped or falls in a room that is not a pit, it will make a "wushhh" sound with the propagation distance 1
- [ ] Make / Receive sound
- [ ] Propagate sound
- [ ] Receive arrow
  - [ ] If an arrow enters a room and the room has the Wumpus then the arrow will hit the Wumpus
  - [ ] If an arrow enters a room and the room doesn't have the Wumpus but has one or more players then the arrow will hit, at random, one of the players
  - [ ] If an arrow enters a room and the room doesn't have the Wumpus or other players then the arrow will be lost and make no sound
- [ ] Close 
  - [ ] When the room is closed it will clean all resources
- [ ] Receive player
  - [ ] If the room is a pit then the player will die

# The sound
- [ ] Each sound will have a propagation distance
- [ ] Sounds made or received in the current room will be heard in the current room
- [ ] The sounds with propagation distance greater then 0 will have the propagation distance decreased by 1 then sent to all the rooms connected except the room from which the sound was received

# Wumpus command types
- [ ] Hear pebble sound
  - [ ] The Wumpus will ignore the sound made by the pebbles
- [ ] Hear a sound not made by a pebble
  - [ ] If the Wumpus is not moved by the Giant Bat it will move to an adiacent room that is not a pit and has no players
  - [ ] If there is no adiacent that is not a pit and has no players the Wumpus will stay in that room
- [ ] Hit by an arrow
  - [ ] If an arrow hits the Wumpus, it will make a sound with infinite propagation distance informing all the players that he was killed by the player that fired the arrow.
  - [ ] Then the game room will be closed
- [ ] Meet a player
  - [ ] I a player enters a room with the Wumpus then the player will die

# Giant Bat command types
- [ ] Meet the Wumpus or a player
  - [ ] If the Wumpus or a player walks in the room where the giant bat setteled then 
  - [ ] the Giant Bat will pickup the Wumpus or player and drop it/he/she in a random room that is not a pit and has no players
  - [ ] then the Giant Bat will settle in a random room that is not a pit and has no players or the Wumpus
  - [ ] make a sound with infinte propagation distance

