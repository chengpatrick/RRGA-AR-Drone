using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TrackCamUIManager ui;

    private bool hasTreasure = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            hasTreasure = true;
            Debug.Log("Collect State");
        }

        if(other.gameObject.tag == "Monster")
        {
            ui.setCrack();
        }

        if(other.gameObject.tag == "Finish" && hasTreasure)
        {
            Debug.Log("Win State");
            ui.setWinText();
        }
    }
}
