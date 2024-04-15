using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class GlaciusAbility : MonoBehaviour
{
    public ActiveStateSelector pose;
    public PlatformSettings platformSpeed;

    // Cooldown duration in seconds
    public float cooldownDuration = 10f;

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
                platformSpeed.speed = 5f;
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
        platformSpeed.speed = 50f;
        isCooldown = false;
    }
}
