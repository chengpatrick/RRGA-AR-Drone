using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrackEvents : MonoBehaviour
{
    public void EnableChildObjects()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
