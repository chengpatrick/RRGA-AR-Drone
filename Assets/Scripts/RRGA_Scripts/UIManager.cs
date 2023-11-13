using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI treasureProgressTxt;
    [SerializeField] GameObject winTxt;


    public void UpdateTreasureProgressText(int count)
    {
        treasureProgressTxt.text = count + "/ 3";
    }

    public void ShowWinText()
    {
        winTxt.SetActive(true);
    }
}
