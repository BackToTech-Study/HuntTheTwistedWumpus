# The Game
- [ ] The cave can only be initiated with an odd number of players

# The Cave
- [ ] The cave is a collection of rooms
- [ ] The cave will contain 4 rooms with a pit
- [ ] The cave is alive and can make sounds

# Turn System
- [ ] The players will take turns executing commands
- [ ] The first player will be chosen at random
- [ ] At the start of the game the cave will whisper to each player the position he/she occupies in the list
- [ ] When the turn changes the cave will whisper to each player, the position of the player who's turn is starting
- [ ] If a player attempts to execute a command when it's not his or her turn, the player is gets the reply that it's not his/her turn and the command was ignored
- [ ] A player's turn ends after executing one command
- [ ] If the player who's turn it is does not make any action within a predefined duration (1minute), his/her turn ends automatically

# The Cave Room
- [ ] Each room will be connected to other rooms according to the schema

![Cave Map](https://github.com/BackToTech-Study/HuntTheWumpus/blob/main/Resources/CaveMap.png)

- [ ] There are 2 type of rooms
  - [ ] Pit
  - [ ] Regular
- [ ] Regular rooms can hold players
- [ ] Regular rooms can hold 1 bat
- [ ] Regular rooms can hold the Wumpus
- [ ] Regular rooms can hold Magic Bows
- [ ] All room types can hold Pebbles
- [ ] At the start of the game all players will be placed in Room 1
- [ ] At the start of the game in Room 1 there will X magic bows. Where X = floor(number of players / 2)
- [ ] At the start of the game in Room 1 there will Y pebbles. Where Y = roof(number of players / 2)

# The Player
- [ ] A player has a connection to a client application
- [ ] The communication between the cave and the client application is not bound to a specific protocol
- [ ] A player can have either the Pebble or the Magical Bow at one time
- [ ] At the start of his/her round each player with a magical bow receives 1 arrow
- [ ] The player can be alive or dead
- [ ] A dead player can still receive messages but can no longer send commands
- [ ] At the start of the game the client application will receive a list of commands that the player can make
- [ ] The player can receive commands from the client application

# The Wumpus
- [ ] The Wumpus will be placed in a randomly selected room that is not a pit room and has no players or Giants Bats in it

# The Giant Bat
- [ ] The Giant Bats will be placed in 2 different randomly selected rooms that are not pit rooms and have no players in it

# Cave Command Types
- [ ] Wisper to a player
  - [ ] When the cave whispers to a player the generated sound will have a propagation distance of 0
  
# Player Command Types
- [ ] Pick up Magical Bow
  - [ ] If the player picks up a magical bow and already has a pebble, the player will automatically drop the pebble in the current room
- [ ] Drop magical bow in the current room
  - [ ] If the player drops the bow he/she looses the arrow
- [ ] Pickup pebble 
  - [ ] If the player picks up a pebble and already has a magical bow, the player will automatically drop the magical bow in the current room
- [ ] Drop pebble in the current room
- [ ] Throw the pebble in an adjacent room if he/she has a pebble 
- [ ] Shoot an arrow in an adjacent room if he/she has a magical bow and an arrow 
- [ ] Hit by an arrow
  - [ ] If a player is hit by an arrow the player will die
- [ ] Die
  - [ ] If a player dies he/she will scream
  - [ ] When the player dies he will drop the pebble or magic bow that he has in his/her possession
- [ ] Walk in an adjacent room 
- [ ] Wisper 
  - [ ] When a player wipers the wipers sound he/she makes will have a propagation distance of 1
- [ ] Speak
  - [ ] When a player speaks the sound he/she makes will have a propagation distance of 2
- [ ] Scream
  - [ ] When a player speaks the sound he/she makes will have an infinite propagation distance
- [ ] Hear a sound
  - [ ] All sounds heard by a player will be sent to the client application and stored until the cave is destroyed
  - [ ] If a player is temporarily disconnected he / she will receive the list of previously heard sounds when reconnection
- [ ] End turn
  - [ ] The player can trigger a turn change by executing the end turn command

# Room Command Types
- [ ] Pebble dropped in this room
  - [ ] When the pebble is dropped or falls in a room that is not a pit, it will make a "click" sound with the propagation distance 2
  - [ ] When the pebble is dropped or falls in a room that is not a pit, it will make a "wushhh" sound with the propagation distance 2
- [ ] Receive / make sound
  - [ ] If a room receives a sound with the propagation distance of 0, it will ignore that sound
  - [ ] When the room will receive a sound it will decrease the sound propagation distance by 1 then play the sound
  - [ ] Then the room will propagate the sound, with the updated propagation distance, to it's connected rooms except the room that send / made the sound
- [ ] Propagate sound
- [ ] Receive arrow
  - [ ] If an arrow enters a room and the room has the Wumpus then the arrow will hit the Wumpus
  - [ ] If an arrow enters a room and the room doesn't have the Wumpus but has one or more players then the arrow will hit, at random, one of the players
  - [ ] If an arrow enters a room and the room doesn't have the Wumpus or other players then the arrow will be lost and make no sound
- [ ] Close 
  - [ ] When the room is closed it will clean all resources
- [ ] Receive player
  - [ ] If the room is a pit then the player will die
  - [ ] If the room is not a pit it will make a sound with the propagation distance of 1 indicating the name of the player that joined
  - [ ] If the room is not a pit it will wisper to the player the current room number and the numbers of the connected rooms
- [ ] Wisper to a player
  - [ ] When the room wisper to a player the generated sound will have a propagation distance of 0

# The sound
- [ ] Each sound will have a propagation distance
- [ ] Sounds with a propagation distance of 0 will only be heard by the player for which the sound was generated
- [ ] Sounds with a propagation distance greater then 0 will be sent to the current room

# Wumpus command types
- [ ] Hear pebble sound
  - [ ] The Wumpus will ignore the sound made by the pebbles
- [ ] Hear a sound not made by a pebble
  - [ ] If the Wumpus is not moved by the Giant Bat it will move to an adjacent room that is not a pit and has no players
  - [ ] If there is no adjacent that is not a pit and has no players the Wumpus will stay in that room
- [ ] Hit by an arrow
  - [ ] If an arrow hits the Wumpus, it will make a sound with infinite propagation distance informing all the players that he was killed by the player that fired the arrow.
  - [ ] Then the game room will be closed
- [ ] Meet a player
  - [ ] I a player enters a room with the Wumpus then the player will die

# Giant Bat command types
- [ ] Meet the Wumpus or a player
  - [ ] If the Wumpus or a player walks in the room where the giant bat settled then 
  - [ ] the Giant Bat will pickup the Wumpus or player and drop it/he/she in a random room that is not a pit and has no players
  - [ ] then the Giant Bat will settle in a random room that is not a pit and has no players or the Wumpus
  - [ ] make a sound with infinite propagation distance

# Cave reconstruction
  - [ ] All commands executed in the cave will be stored in a persistent manned
  - [ ] If the game crashes before the game ends the state of the cave will be recreated using the stored commands
