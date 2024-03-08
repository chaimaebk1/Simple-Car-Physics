using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Reference to the player car's transform
    public float distance = 8f; // Distance from the player car
    public float height = 10f; // Height above the player car
    public float damping = 5f; // Damping factor for smooth camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

            // Smoothly move the camera to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

            // Make the camera look at the player car
            transform.LookAt(target.position);
        }
    }
}
