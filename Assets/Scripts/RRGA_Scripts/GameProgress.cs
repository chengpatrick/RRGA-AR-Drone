using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameProgress : MonoBehaviour
{
    // 0 is treasure, 1 is monster
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] GameObject rotatingNumber;
    [SerializeField] UIManager ui;
    
    public int totalCollectables;
    protected int currentCollectables;

    // treasure spawn counter
    private int treasureIndexCounter;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play2DSFXInRandom("VO_Command_MissionStart", 2);
        currentCollectables = 0;
        treasureIndexCounter = 0;

        // spawn treasure with order counter
        while(treasureIndexCounter < totalCollectables)
        {
            int i = Random.Range(0, spawnPoints.Count);
            GameObject obj = Instantiate(spawnList[0], spawnPoints[i].transform);
            GameObject rn = Instantiate(rotatingNumber, spawnPoints[i].transform);

            obj.transform.position = new Vector3(0, 5f, 0);
            
            obj.GetComponent<Treasure>().AssignTreasureIndex(treasureIndexCounter);

            rn.GetComponent<RotatingNumber>().number = treasureIndexCounter + 1;
            rn.transform.parent = obj.transform;

            obj.transform.Rotate(new Vector3(-90, 180, 0), Space.Self);

            spawnPoints.RemoveAt(i);

            treasureIndexCounter++;
        }

        // spawn monster at remaining locations
        while(spawnPoints.Count > 0)
        {
            int i = Random.Range(0, spawnPoints.Count);
            GameObject enemy = Instantiate(spawnList[1], spawnPoints[i].transform);
            enemy.transform.Rotate(new Vector3(-90, 180, 0), Space.Self);
            spawnPoints.RemoveAt(i);
        }
    }

    public void CollectTreasure()
    {
        currentCollectables++;
        ui.UpdateTreasureProgressText(currentCollectables);

        if (currentCollectables == totalCollectables)
            ui.ShowWinText();
    }

    public int TargetTreasure()
    {
        return currentCollectables;
    }
}
