using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UIManager ui;
    [SerializeField] private GameProgress progress;

    private bool hasTreasure = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Treasure>() != null)
        {
            if(other.gameObject.GetComponent<Treasure>().treasureIndex == progress.TargetTreasure())
            {
                Destroy(other.gameObject);
                progress.CollectTreasure();
                Debug.Log("Collect State");
            }  
        }
        else if(other.gameObject.tag == "Monster")
        {
            // ui.setCrack();
        }

        if(other.gameObject.tag == "Finish" && hasTreasure)
        {
            Debug.Log("Win State");
            // ui.setWinText();
        }
    }
}
