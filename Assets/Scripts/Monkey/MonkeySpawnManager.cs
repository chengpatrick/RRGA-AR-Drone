using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawnManager : SingletonMonoBehaviour<MonkeySpawnManager>
{
    public bool testInDroneSimulator;

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    GameObject monkeyPrefab;

    [SerializeField]
    int poolSize = 20;

    [SerializeField]
    List<GameObject> monkeyPool;

    [SerializeField]
    List<SpawnPoint> spawnPoints;

    int sp_idx;

    [SerializeField]
    float[] cdRange;

    float cd;

    public Transform PlayerTransform { get { return playerTransform; } }

    private void Start()
    {
        cd = Random.Range(cdRange[0], cdRange[1]);
        GameObject tempMonkey;

        // Generate object pool for monkeys
        for (int i = 0; i < poolSize; i++)
        {
            tempMonkey  = Instantiate(monkeyPrefab, Vector3.zero, Quaternion.identity);
            tempMonkey.SetActive(false);
            monkeyPool.Add(tempMonkey);
        }
    }

    private void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else
        {
            SelectSpawnPoint();
            cd = Random.Range(cdRange[0], cdRange[1]);
        }
    }

    public void SpawnMonkey(Vector3 position)
    {
        GameObject spawnedMonkey = GetMonkeyFromPool();

        if (spawnedMonkey != null)
        {
            spawnedMonkey.SetActive(true);

            // set monkey position
            spawnedMonkey.transform.position = position;
        }
    }

    private void SelectSpawnPoint()
    {
        sp_idx = Random.Range(0, spawnPoints.Count - 1);

/*        while (spawnPoints[sp_idx].isInCD)
        {
            sp_idx = Random.Range(0, spawnPoints.Count - 1);
        }*/

        spawnPoints[sp_idx].SpawnMonkey();
    }

    private GameObject GetMonkeyFromPool()
    {
        foreach(GameObject monkey in monkeyPool)
        {
            if (!monkey.activeInHierarchy)
            {
                return monkey;
            }
        }
        return null;
    }

    [ContextMenu("Set Up Spawn Point")]
    private void SetUpSpawnPoint()
    {
        spawnPoints.Clear();

        foreach (GameObject sp in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnPoints.Add(sp.GetComponent<SpawnPoint>());
        }
    }
}
