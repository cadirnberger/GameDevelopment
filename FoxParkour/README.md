# Fox Parkour

## Play the Game
**Unity Play Link**:
https://play.unity.com/en/games/e270c8c5-6b31-4785-9f48-14b5668aed1c/fox-parkour 
## Game Description:
Player's objective is to collect all of the cherries and reach the end. They have to jump across platform to get the cherries and to get to the end of the level. To win the game isn't just to get to the end, but to colect the all of the cherries. If you do get to the end not having all off them, the player won't win. it have fun little animation to it so the player feel like the player is moving. It has music in the background and when you collect the cherries it plays sound also when winning it stop the background music and plays a toon. W is to jump . A is to go left. S is to crouch. D is to go right.
## Technical Implementation:
### Levels: 
It only has one level right now. It has 4 cherries, 5 "single" platforms in total (2 platform with ladder and 3 without), 2 "ground" platforms and a border, a house to win, and the player. the platform help the player move around and get up to the objectives. The level gets a little bit hard over time when the player plays it because the jumps are harder each jump. It not too complex for the player.
### Sprites: 
The sprites are the charries and the fox, which is the player. When you press W, the player jumps. When you press A, the player goes left, When you press S, the player crouches. When you press D, the player goes left. It intracts with the ladder and cherries. The player hits the ladder they arent affected by gravity, able to move up and down, but when gets off in goes back to normal. All of these have their own animations, even when falling. The cherries, when walked over, dissapears, adds a point to the collection, plays a sound and produces particles.
### Prefabs: 
The platforms, player, cherries and ladder all have prefabs. The platfroms depends on how my level is laid out so it need to be a prefab, so I am able to add more platfrom or eddit how I want this platform to be like. The cherries are prefab because I might want the player to have to jump through more hoops.  player is also a prefab because when I add more levels ladder is a prefab becouse if I want to put on different thing.
### Colliders:
The collider that are not triggers are player, platforms and the boarder, while the triggers are ladder and cherries. The border keep the player in, so it has the collider. To hold the player on the platform, the platfroms needs the collider. Player needs to interact with everything, so it has collider.
Rigidbodies: 
### Triggers: 
The triggers are ladder and cherries. ladder need a trigger because then the player can climb up it. the cherries needs it so they can be collected and disapear.
### UI Text: 
There is a collection tracker for the cherries. Each time the cherry is collect it adds one to the tracker. once the you collected all of the cherries and reach the end, It shows You win text.
### Sprite Movement: 
When you press W, the player jumps. When you press A, the player goes left, When you press S, the player crouches. When you press D, the player goes left. when on the ladder w goes up and s goes down.
### Particle System:
The cherries have a eating particle effects. when the cherries are collected it plays. it plays for 0.35 lifetime. It has circle shape to the emmitions to it. it has a green and red gradiant to the color.
### GameObject Management:
The player animation has gameobject managment changing the sprite state when running, climbing falling, jumping, and idle. The cherry destroys after interacted. The ui  is change every time player collects the cherries.
## Future Development Plan:
How would you extend the game with additional levels?
What new game objects or mechanics would you add?
How would you expand the story or theme?
I want to add levels and make them more complicated and harder. right now it still a little to easy, so more level means I can make it harder. I also want to add enemies so it can make the level harder. A death animation can come with enemy, so I want to make one. making more complex story to it is some that i want to do. This means some npcs and dialogue for them. I also want to make a better ui and a pause/play menue. 
## Development Reflection:
What was the most challenging aspect of this project?
What did you learn about Unity or game development?
What would you do differently next time?
I learned more about ways to animate sprites and different ways to build a level. I learned different ways to move the character. The most challanging was the ladder because something to do with the asset. The other challanging thing is setting up the level because i didn't know what I wanted to do with it. 

