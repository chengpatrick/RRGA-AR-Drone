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
                SoundManager.Instance.PlaySFXClip("SFX_GetTreasure");
                Debug.Log("Collect State");
            }  
        }
        else if(other.gameObject.tag == "Monster")
        {
            // ui.setCrack();
            SoundManager.Instance.Play2DSFXInRandom("SFX_BeHit", 2);
        }

        if(other.gameObject.tag == "Finish" && hasTreasure)
        {
            SoundManager.Instance.Play2DSFXInRandom("VO_Command_Finish", 2);
            Debug.Log("Win State");
            // ui.setWinText();
        }
    }
}
