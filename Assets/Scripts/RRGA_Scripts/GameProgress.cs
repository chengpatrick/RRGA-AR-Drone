using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameProgress : MonoBehaviour
{
    // 0 is treasure, 1 is monster
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] UIManager ui;
    
    public int totalCollectables;
    protected int currentCollectables;

    // treasure spawn counter
    private int treasureIndexCounter;

    // Start is called before the first frame update
    void Start()
    {
        currentCollectables = 0;
        treasureIndexCounter = 0;

        // spawn treasure with order counter
        while(treasureIndexCounter < totalCollectables)
        {
            int i = Random.Range(0, spawnPoints.Count);
            GameObject obj = Instantiate(spawnList[0], spawnPoints[i].transform);
            obj.GetComponent<Treasure>().AssignTreasureIndex(treasureIndexCounter);
            spawnPoints.RemoveAt(i);

            treasureIndexCounter++;
        }

        // spawn monster at remaining locations
        while(spawnPoints.Count > 0)
        {
            int i = Random.Range(0, spawnPoints.Count);
            Instantiate(spawnList[1], spawnPoints[i].transform);
            spawnPoints.RemoveAt(i);
        }
    }

    public void CollectTreasure()
    {
        currentCollectables++;
        ui.UpdateTreasureProgressText(currentCollectables);
    }

    public int TargetTreasure()
    {
        return currentCollectables + 1;
    }
}
