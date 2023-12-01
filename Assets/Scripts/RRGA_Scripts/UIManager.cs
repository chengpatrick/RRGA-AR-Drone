using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI treasureProgressTxt;
    [SerializeField] GameObject winTxt;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] RectMask2D ammoMask;

    public void setTimerText(int min, int sec)
    {
        string timerStrBuilder = min.ToString() + ":";

        if(sec < 10)
        {
            timerStrBuilder += "0" + sec.ToString();
        }
        else
        {
            timerStrBuilder += sec.ToString();
        }
        timerTxt.text = timerStrBuilder;
    }

    public void UpdateTreasureProgressText(int count)
    {
        treasureProgressTxt.text = count + "/ 3";
    }

    public void ShowWinText()
    {
        winTxt.SetActive(true);
    }

    public void UpdateAmmoBar(float i)
    {
        ammoMask.padding = new Vector4(ammoMask.padding.x, ammoMask.padding.y, ammoMask.padding.z, i);
    }
}
