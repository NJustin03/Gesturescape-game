using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealText : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("hiddenText"))
        {
            //Transform otherTransform = other.transform;
            foreach(Transform child in other.transform)
                child.gameObject.SetActive(true);
        }
    }
}
