using System.Collections;
using UnityEngine;
using Oculus.Interaction;

public class ForwardMovementAbility : MonoBehaviour
{
    public ActiveStateSelector pose;
    public Rigidbody playerRigidBody;
    public Transform cameraTransform; // Reference to the camera's transform

    // Movement speed
    public float movementSpeed = 5f;

    // Flag to track whether the pose detection action is active
    private bool isPoseActive = false;

    void Start()
    {
        // Event trigger for the paper pose
        pose.WhenSelected += () => StartMovement();
        pose.WhenUnselected += () => StopMovement();
    }

    // Method to start movement
    void StartMovement()
    {
        isPoseActive = true;
        StartCoroutine(MovePlayer());
    }

    // Method to stop movement
    void StopMovement()
    {
        isPoseActive = false;
    }

    // Coroutine to handle movement
    IEnumerator MovePlayer()
    {
        while (isPoseActive)
        {
            // Calculate movement direction relative to the camera
            Vector3 movementDirection = cameraTransform.forward;
            movementDirection.y = 0; // We don't want vertical movement

            // Move the player forward
            Vector3 movement = movementDirection.normalized * movementSpeed * Time.deltaTime;
            playerRigidBody.MovePosition(playerRigidBody.position + movement);

            yield return null;
        }
    }
}
