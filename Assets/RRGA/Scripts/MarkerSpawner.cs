using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> list;

    private void Awake()
    {
        int num = Random.Range(0, list.Count);
        list[num].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
