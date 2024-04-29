using System.Collections;
using UnityEngine;
using Oculus.Interaction;

public class FireSpell : MonoBehaviour
{
    public ActiveStateSelector openPalmPose;
    public GameObject fireSpell;

    private bool isToggled = false;

    void Start()
    {
        openPalmPose.WhenSelected += () => ToggleObject();
    }

    void ToggleObject()
    {
        isToggled = !isToggled;
        fireSpell.SetActive(isToggled);
    }
}
