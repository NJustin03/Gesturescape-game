using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("key"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
