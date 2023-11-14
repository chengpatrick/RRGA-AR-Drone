using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotatingNumber : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] public int number;
    [SerializeField] List<GameObject> numbers;

    private void Start()
    {
        numbers[number - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
