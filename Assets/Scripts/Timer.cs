using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float min, sec;
    [SerializeField] UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        min = 5;
        sec = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        ui.setTimerText((int)min, (int)sec);
    }

    private void UpdateTime()
    {
        if(sec < 0)
        {
            min--;
            sec = 60;
        }

        sec -= Time.deltaTime;
    }
}
