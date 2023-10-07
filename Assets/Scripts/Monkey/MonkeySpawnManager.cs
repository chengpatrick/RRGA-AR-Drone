using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawnManager : SingletonMonoBehaviour<MonkeySpawnManager>
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    GameObject monkeyPrefab;

    [SerializeField]
    int poolSize = 20;

    [SerializeField]
    List<GameObject> monkeyPool;

    public Transform PlayerTransform { get { return playerTransform; } }

    private void Start()
    {
        GameObject tempMonkey;

        // Generate object pool for monkeys
        for (int i = 0; i < poolSize; i++)
        {
            tempMonkey  = Instantiate(monkeyPrefab, Vector3.zero, Quaternion.identity);
            tempMonkey.SetActive(false);
            monkeyPool.Add(tempMonkey);
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
}
