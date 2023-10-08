using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    float[] cdRange;

    float cd;

    public bool isInCD;

    private void StartCountDown()
    {
        SetCD();

        while (cd > 0)
        {
            cd -= Time.deltaTime;
        }

        isInCD = false;
    }

    private void SetCD()
    {
        cd = Random.Range(cdRange[0], cdRange[1]);
        isInCD = true;
    }

    public void SpawnMonkey()
    {
        MonkeySpawnManager.Instance.SpawnMonkey(transform.position);
        //StartCountDown();
    }
}
