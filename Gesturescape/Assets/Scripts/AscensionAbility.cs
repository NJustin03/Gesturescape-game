using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public class AscensionAbility : MonoBehaviour
{
    public ActiveStateSelector pose;
    public Rigidbody playerRigidBody;

    // Cooldown duration in seconds
    public float cooldownDuration = 2f;

    // Flag to track whether the pose detection action is on cooldown
    private bool isCooldown = false;

    void Start()
    {
        //Event trigger the bunny pose
        pose.WhenSelected += () =>
        {
            if (!isCooldown)
            {
                // Preform action that causes the rigidbody to be boosted
                playerRigidBody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
                StartCoroutine(StartCooldown());
            }
        };

        pose.WhenUnselected += () => Debug.Log("");
    }

    // Coroutine to handle cooldown
    IEnumerator StartCooldown()
    {
        // Set the flag to indicate that the action is on cooldown
        isCooldown = true;

        // Wait for cooldown duration
        yield return new WaitForSeconds(cooldownDuration);

        // Reset the cooldown flag after cooldown duration
        isCooldown = false;
    }

}
