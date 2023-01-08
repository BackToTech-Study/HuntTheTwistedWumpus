# HuntTheTwistedWumpus
Hunt the Wumpus multiplayer implementation

## Requirements

### The cave map
- [ ] Is a collection of cave rooms numbered as in the following diagram

![Cave Map](https://github.com/BackToTech-Study/HuntTheWumpus/blob/main/Resources/CaveMap.png)

- [ ] There are 2 type of rooms
  - [ ] Pits / Trap rooms
  - [ ] Normal Rooms
- [ ] There is no light in the cave so the players must use only sound to navigate

- [ ] Each map will contain 4 pit rooms

### Actors
- [ ] Wumpus
  - [ ] Each map will contain 1 Wumpus

- [ ] Giant bats
  - [ ] Each game will contain 2 Giant bats
  
- [ ] Players
  - [ ] Each game can accommodate maximum 5 players
  
## Items 
- [ ] Pebble / Stone  
- [ ] Magical Bow 
- [ ] A player can wield either the Pebble or the Magical Bow at one time
- [ ] Arrow
  - [ ] At the start of his/her round each player with a magical bow receives 1 arrow
  
## Actions
- [ ] The players will take turns executing actions
- [ ] Each player can execute one action per turn
- [ ] The player turn will automatically timeout in 1 minute
- [ ] Each player can do the following actions
  - [ ] Pickup magical bow
    - [ ] If the player picks up a magical bow and already has a pebble, the player will automatically drop the pebble in the current room  
  - [ ] Drop magical bow in the current room
    - [ ] If the player drops the bow he looses the arrow
  - [ ] Pickup pebble
    - [ ] If the player picks up a pebble and already has a magical bow, the player will automatically drop the magical bow in the current room
  - [ ] Drop pebble in the current room 
  - [ ] Throw the pebble in an adjacent room if he/she has a pebble
    - [ ] Once a pebble lands in another room it will stay there until it is picked up by another player
  - [ ] Shoot an arrow in an adjacent room if he/she has a magical bow and an arrow
    - [ ] If the arrow reaches a room where the Wumpus is present, the arrow will kill the Wumpus
      - [ ] The player that kills the Wumpus is the winner of the game
      - [ ] All the players will be notified that the Wumpus was killed   
    - [ ] If the arrow reaches a room where there is one or more players, one of the players (random selection) in that room will be killed
      - [ ] When the player dies he/she will scream 
  - [ ] Walk in an adjacent room  
    - [ ] If a player walks in a room that is a pit, the player will die.
      - [ ] The falling player will scream 
    - [ ] (**1**)If a player walks in a room where the Wumpus sleeps, the Wumpus will eat the player   
      - [ ] The dying player will scream 
    - [ ] If a player walks in a room with a Giant Bat, 
      - [ ] (**2**)
   - [ ] Wisper
      - [ ] When a player whispers the whispers will only be heard by the other players in that room
   - [ ] Speak  
      - [ ] When a player speaks the words will only be heard by the other players and/or the Wumpus in that room or the adjacent rooms
   - [ ] Scream
      - [ ] When a player screams the scream will be heard by all the other players and the Wumpus

## Pebble sounds
- [ ] When the pebble is dropped or falls in a room that is not a pit, it will make a "click" sound
- [ ] When the pebble is dropped or falls in a room that is not a pit, it will make a "wushhh" sound
- [ ] The sound made by the pebble will be heard by the people in that room and the adjacent rooms
- [ ] The sound made by the pebble will be ignored by the Wumpus

## The Wumpus actions
- [ ] If the Wumpus hears a sound it will move to an adjacent room that is not a pit and has no players
- [ ] If the Wumpus moves to a room with a Giant Bat, 
  - [ ] (**2**)
- [ ] (**1**)

## Giant Bat actions
- [ ] (**2**)If the Wumpus or a player walks in the room where the giant bat settled then
  - [ ] the Giant Bat will pickup the Wumpus or player and drop it/he/she in a random room that is not a pit and has no players
  - [ ] then the Giant Bat will settle in a random room that is not a pit and has no players or the Wumpus
  - [ ] all the players will hear the sound of the wings made by the Giant Bat when it is flying
  - [ ] the Wumpus will also hear the sound made by the Giant Bat and will move if it's not already carried by the Giant Bat

## Init
- [ ] The map will be initialized with 4 randomly selected pit rooms
- [ ] At the start of the game all players will be placed in Room 1
- [ ] Room 1 will contain 3 magic bows and 2 pebbles
- [ ] The Giant Bats will be placed in 2 different randomly selected rooms that are not pit rooms and have no players in it
- [ ] The Wumpus will be placed in a randomly selected room that is not a pit room and has no players or Giants Bats in it
 
## References
- [ ] https://en.wikipedia.org/wiki/Hunt_the_Wumpus
