using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class GlaciusAbility : MonoBehaviour
{
    public ActiveStateSelector pose;
    public PlatformSettings platformSpeed;
    public MovingWallSettings movingWallSpeed;
    public FallingPlatformSettings fallingPlatformSpeed;
    public AudioSource spellSound;
    public AudioSource countdownSound;
    private float startTimed = 50f;

    // Cooldown duration in seconds
    public float cooldownDuration = 10f;

    // Flag to track whether the pose detection action is on cooldown
    private bool isCooldown = false;

    void Start()
    {
        //Event trigger the clock pose
        pose.WhenSelected += StartCooldown;
        pose.WhenUnselected += () => Debug.Log("");
    }

    // Start the cooldown for all platforms
    void StartCooldown()
    {
        if (!isCooldown)
        {
            // Preform action that causes the platforms to slow down.
            platformSpeed.speed = 5f;
            movingWallSpeed.speed = 1f;
            fallingPlatformSpeed.speed = 10f;
            spellSound.Play();
            countdownSound.time = startTimed;
            countdownSound.Play();
            StartCoroutine(ResetSpeedAfterCooldown());
        }
    }

    // Coroutine to reset speed after cooldown
    IEnumerator ResetSpeedAfterCooldown()
    {
        // Set the flag to indicate that the action is on cooldown
        isCooldown = true;

        // Wait for cooldown duration
        yield return new WaitForSeconds(cooldownDuration);

        // Reset the cooldown flag after cooldown duration
        platformSpeed.speed = 50f;
        movingWallSpeed.speed = 5f;
        fallingPlatformSpeed.speed = 45f;
        isCooldown = false;
    }
}
