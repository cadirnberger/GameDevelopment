# Debris Dash

## Play the Game
**Unity Play Link**: https://play.unity.com/en/games/2ba0002b-5fd6-40fd-a24d-c9be4c96dea6/debris-dash

## Game Overview
Avoid the debris in space but don't touch the wall either. Try to live as much as you can and get the high score. The debris will get faster, trying to make you lose.

### Controls
- w- forward
- s- backwards
- d- rotate right
- a- roate left
- space- stop
- shift - boost

### How to Play
To aviod the debris move forward, backwards or rotate left or right. you can stop yourself with the space bar incase of something right there or if you are too slow boost with shift.
DO NOT touch the debris or the wall. The debris will get faster as time goes on.

## Base Game Implementation

### Completion Status
- [x] Player movement and controls
- [x] Obstacle spawning system
- [x] Collision detection
- [x] Score system
- [x] Game over state
- [x] High score
- [x] Swap Out Sprites
- [x] Destroy the Borders
- [x] Increase Difficulty Over Time
- [x] Add Sound Effects and Background Music
- [x] Animate the Booster Graphic with Audio

### Known Bugs
- when shift boost is clicked it doesn't have the sound.

### Limitations
- Sounds were free so it was hard getting what I want.

## Extensions Implemented

### 1. Swap Out Sprites (3 points)
**Implementation**: I used free sprite on the and placed them on the game objects.
**Game Impact**: no much just good visuals.
**Technical Details**: the sprits have hit box that already were on the og shapes.
**Known Issues**: None 

### 2. Destroy the Borders (4 points)
**Implementation**: the border disapear when it's game over.
**Game Impact**: just a cool after after affect when the game is over.
**Technical Details**: when the player collides with the debris player dies and the borders disappear.
**Known Issues**: None

### 3.  Increase Difficulty Over Time (5 points)
**Implementation**: for amount of time player is alive the difficulty increases.
**Game Impact**: it made the game hard for the player.
**Technical Details**: it changes the speed of debris.
**Known Issues**: None

### 4. Add Sound Effects and Background Music (5 points)
**Implementation**: the background music plays for ever in the scene and when the player collides with debris it plays a dying sound.
**Game Impact**: it makes the game feel more alive.
**Technical Details**: it add more audio clips.
**Known Issues**: None

### 5. Animate the Booster Graphic with Audio (6 points)
**Implementation**: while the w key is it plays an audio that sounds like a booster and has a fire that comes out.
**Game Impact**: makes the player feel more alive.
**Technical Details**: the booster gets bigger more you click and the shift has it.
**Known Issues**: shift doesn't have the booster audio.


## Credits
- Sci Fi Ambiances, Vincent T
-  leohpaz, RPG Essentials Sound Effects - FREE!
-  InspectorJ Audio, Abstract Spaceships SFX (Free Sample Pack)
-  Crehera, Pixel Art Space Ship Part 1

## Reflection
**Total Points Claimed**: 70 + 23 + 10 = 103
**Challenges**: it was easy
**Learning Outcomes**: how to make a 2d game

## Development Notes
this was a fun game to make
