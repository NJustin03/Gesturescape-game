using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    [SerializeField]
    private Vector3 originalPosition;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the player back to the original position
            other.transform.position = originalPosition;
        }
    }
}
