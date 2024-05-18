# Car Drifting Game 
## Overview
This Unity project simulates a car drifting game with features including drifting, nitro boosts, coin collection, and competitor cars. The player drives a green car, collects coins, avoids collisions, and competes with red cars. The game also implements a scoring system that rewards staying on the road and collecting coins while penalizing collisions and off-road driving.

## Requirements
Unity 2020.3 or later
Basic understanding of C# and Unity scripting
Scene Creation
Road Creation
Create Road:
In the Unity Editor, create a new Plane object to represent the road.
Position and scale the plane to fit the desired length and width of the road.
### Car Creation

Create Player Car:

Create a green cube to represent the player’s car. Alternatively, import a car prefab from the Unity Asset Store.
Attach a Rigidbody component to the car for physics simulation.

Create Competitor Cars:

Create red cubes to represent competitor cars or import red car prefabs.
Attach a Rigidbody component to each competitor car.

### Additional Objects

Create Roadside Boxes:

Create boxes to be instantiated on the roadsides.
Position these boxes randomly but ensure they are off the road.

Create Coin Prefabs:

Design a coin prefab to be collected by the player.
Position coins along the road in strategic locations.
Behavior Simulation

### Competitor Car Behavior

Instantiation:

Instantiate a fixed number of red cars at random positions on the road.
Ensure red cars stay within the bounds of the road.

### Coin Behavior

Coin Simulation:

Coins should have a simple animation or rotation for visual appeal.
Destroy the coin when collected by the player and update the score.

### Scoring System

Score Management:

Decrease the player score if:

The player deviates from the road.
The player collides with any object except coins.

### Drifting Simulation

Drifting Mechanics:

Use the Rigidbody component’s velocity and angularVelocity to simulate drifting.
Adjust friction and steering to enhance the drifting experience.

### Nitro Mechanism

Nitro Boost:

Allow the player to use a nitro boost after reaching a certain score.
Increase the car's speed temporarily during nitro.
Reset the nitro score if the player collides with another object.


Ensure all dynamics (movement, collisions) are handled by Unity's physics engine.
Use appropriate physics materials for different surfaces.

### Camera Behavior

Camera Following:

Set up a camera to follow the player’s car.

Ensure the camera always looks at the main player.

How to Run the Project

Clone or download the repository.

Open the project in Unity.

Load the main scene (Samplescene.unity).

Play the game by pressing the Play button in the Unity Editor.

### Controls

Steering: Use the arrow keys or A/D to steer the car.

Acceleration: Use the up arrow or W to accelerate.

Brake/Reverse: Use the down arrow or S to brake or reverse.

Nitro Boost: Press N to activate the nitro boost (if available).

### Future Improvements

Enhance graphics and models for a more realistic experience.

Implement AI behavior for competitor cars.

Add more levels and challenges.

Include sound effects and background music.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Acknowledgments
Unity Asset Store for car prefabs and additional assets.
Unity Documentation for guidance on using Rigidbody and other components.
Contact
For any questions or suggestions, please contact me at balakichaimae@gmail.com.
