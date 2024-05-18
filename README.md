The objective: Create a scalable car game that simulates drifting, nitro, and enemies.
Refer to rigidBody documentation that includes the velocity and angularVelocity...
https://docs.unity3d.com/ScriptReference/Rigidbody.html

Challenge1: Scene creation:
1. Create a road using a plane.
2. Create a car using a green cube (you can import a car prefab from unity asset store)
3. Create boxes that can be instantiated in the roadsides.
4. Create the coin prefabs.
5. Create a red car that acts as a competitor.
Challenge 2: Behavior simulation:
1. The red cars should be instantiated in random position (only a fixed number of red cars
should be in the scene).
2. Simulate the coin behavior.
3. Decrease the player score if:
a. It deviates from the road.
b. Any collision with other game object except coins.
4. Simulate the drifting for the green car.
5. Simulate the nitro:
a. After reaching a certain score the car can use the nitro mechanism.
b. If the core collides with another game object, the nitro score is reset.
6. Simulate all dynamics in the scene.
7. Simulate the camera behavior.
a. The camera looks always to the main player.
