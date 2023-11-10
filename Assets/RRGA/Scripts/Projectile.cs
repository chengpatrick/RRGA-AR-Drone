using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileLifespam;
    public Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, projectileLifespam);
        GetComponent<Rigidbody>().AddForce(velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
