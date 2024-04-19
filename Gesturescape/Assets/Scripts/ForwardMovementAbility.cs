using System.Collections;
using UnityEngine;
using Oculus.Interaction;

public class ForwardMovementAbility : MonoBehaviour
{
    public ActiveStateSelector paperPose;
    public ActiveStateSelector rockPose;
    public Rigidbody playerRigidBody;
    public Transform cameraTransform; // Reference to the camera's transform

    // Movement speed
    public float movementSpeed = 5f;
    
    private bool isPaper = false;

    void Start()
    {
        // Event trigger for the paper pose
        paperPose.WhenSelected += () => StartMovement();

        // Event trigger for the rock pose
        rockPose.WhenSelected += () => StopMovement();
    }

    // Method to start movement
    void StartMovement()
    {
        isPaper = true;
        StartCoroutine(MovePlayer());
    }

    // Method to stop movement
    void StopMovement()
    {
        isPaper = false;
        StopCoroutine(MovePlayer());
    }

    // Coroutine to handle movement
    IEnumerator MovePlayer()
    {
        while (isPaper)
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
