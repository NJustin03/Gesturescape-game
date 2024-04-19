using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public AN_DoorScript doorScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door"))
        {
            gameObject.SetActive(false);
            doorScript.isOpened = true;
            //other.gameObject.SetActive(false);
        }
    }
}
