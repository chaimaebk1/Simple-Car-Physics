using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float playerAcceleration = 12f; // Base acceleration for the player car
    public float driftForce = 50f; // Force applied during drifting
    public float maxSpeed = 50f; // Maximum speed of the car
    public float enemyAccelerationVariation = 10f; // Variation in acceleration for the enemy car
    public float driftForceMultiplier = 2f; // Multiplier for drift force
    public float speedIncreaseAmount = 12f; // Amount to increase speed by
    public float speedIncreaseDuration = 0f; // Duration of speed increase
    public float speedDecreaseAmount = 6f; // Amount to decrease speed by
    public float minSpeed = 5f; // Minimum speed allowed

    private Rigidbody rb;
    private int score = 0;
    private bool isSpeedIncreased = false;

    void Start()
    {
        Debug.Log("Start method called for: " + gameObject.name);
        rb = GetComponent<Rigidbody>();

        // Check if the car is tagged as "Player"
        if (gameObject.CompareTag("Player"))
        {
            // Set initial velocity to move the player car forward
            rb.velocity = transform.forward * playerAcceleration;
        }
        // Check if the car is tagged as "Enemy"
        else if (gameObject.CompareTag("Enemy"))
        {
            // Set initial velocity for the enemy car
            SetInitialEnemyVelocity();
        }
    }

    void Update()
    {
        // Check if the car is tagged as "Player"
        if (gameObject.CompareTag("Player"))
        {
            // Get horizontal input axis
            float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate drift force
            Vector3 driftForceVector = transform.right * horizontalInput * driftForce * Time.deltaTime;

            // Apply force based on input direction
            if (horizontalInput > 0) // Move right
            {
                // Apply force to the left in the front and to the right in the back of the car
                Vector3 frontForce = -transform.right * playerAcceleration;
                Vector3 backForce = transform.right * playerAcceleration;
                rb.AddForce(frontForce + backForce);
            }
            else if (horizontalInput < 0) // Move left
            {
                // Apply force to the right in the front and to the left in the back of the car
                Vector3 frontForce = transform.right * playerAcceleration;
                Vector3 backForce = -transform.right * playerAcceleration;
                rb.AddForce(frontForce + backForce);
            }

            // Apply drift force only if the player car is moving
            if (Mathf.Abs(horizontalInput) > 0.1f)
            {
                // Apply drift force to the sides of the car
                rb.AddForce(driftForceVector * driftForceMultiplier, ForceMode.Impulse);
            }

            // Limit car speed
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    // Method to set initial velocity for the enemy car
    void SetInitialEnemyVelocity()
    {
        // Calculate initial velocity for the enemy car based on acceleration variation
        float enemyAcceleration = playerAcceleration + Random.Range(0f, enemyAccelerationVariation);

        // Set initial velocity to move the enemy car forward
        rb.velocity = transform.forward * enemyAcceleration;
    }

    // Method to handle collisions
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a Coin tagged object
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Increase score
            score++;

            // Make the car faster temporarily
            if (!isSpeedIncreased)
            {
                StartCoroutine(IncreaseSpeedTemporarily());
            }

            Debug.Log("Score: " + score);
        }
        // Check if the collision is with a Box tagged object
        else if (collision.gameObject.CompareTag("Box"))
        {
            // Decrease speed
            playerAcceleration -= speedDecreaseAmount;

            // Clamp speed to a minimum value
            playerAcceleration = Mathf.Max(playerAcceleration, minSpeed);

            // Decrease score
            score--;

            Debug.Log("Speed decreased to: " + playerAcceleration);
            Debug.Log("Score: " + score);
        }
    }

    IEnumerator IncreaseSpeedTemporarily()
    {
        isSpeedIncreased = true;

        // Save current velocity
        Vector3 currentVelocity = rb.velocity;

        // Increase speed
        playerAcceleration += speedIncreaseAmount;

        // Apply new velocity
        rb.velocity = currentVelocity.normalized * playerAcceleration;

        // Wait for specified duration
        yield return new WaitForSeconds(speedIncreaseDuration);

        // Return to normal speed
        playerAcceleration -= speedIncreaseAmount;
        isSpeedIncreased = false;
    }
}
