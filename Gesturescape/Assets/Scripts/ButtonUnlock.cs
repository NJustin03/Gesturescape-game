using UnityEngine;

public class ButtonUnlock : MonoBehaviour
{
    public AN_DoorScript doorScript;
    private string[] correctSequence = {"B", "A", "C"};
    private int currentIndex = 0;

    void Update()
    {
        // Check if the correct sequence has been entered
        if (currentIndex >= correctSequence.Length)
        {
            doorScript.isOpened = true; // Unlock the door if the correct sequence is entered
            ResetSequence(); // Reset the sequence for the next attempt
        }
    }

    public void ButtonPressed(string buttonName)
    {
        // Check if currentIndex is within the bounds of the array
        if (currentIndex < correctSequence.Length)
        {
            // Check if the pressed button matches the current expected button in the sequence
            if (buttonName == correctSequence[currentIndex])
            {
                currentIndex++; // Move to the next button in the sequence
            }
            else
            {
                ResetSequence(); // Reset the sequence if the wrong button is pressed
            }
        }
    }

    void ResetSequence()
    {
        currentIndex = 0; // Reset the sequence index
    }
}
