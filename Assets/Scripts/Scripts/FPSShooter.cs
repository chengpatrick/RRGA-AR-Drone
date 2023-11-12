using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform LFirePoint, RFirePoint;
    [SerializeField] Transform target;

    private bool left;
    public float projectileSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (left)
        {
            left = false;
            InstantiateProjectile(LFirePoint);
        }
        else
        {
            left = true;
            InstantiateProjectile(RFirePoint);
        }

        Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.tag == "Monster")
            {
                Destroy(hit.transform.gameObject, .3f);
            }
        } 
    }

    void InstantiateProjectile(Transform firePoint)
    {
        GameObject projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity);
        // projectileObj.transform.parent = gameObject.transform;
        // projectile.GetComponent<Rigidbody>().velocity = (target.position - firePoint.position).normalized * projectileSpeed;
        // projectile.GetComponent<Rigidbody>().AddForce((target.position - firePoint.position).normalized * projectileSpeed);
        projectileObj.GetComponent<Projectile>().velocity = (target.position - firePoint.position).normalized * projectileSpeed;
        Debug.Log((target.position - firePoint.position).normalized * projectileSpeed);
    }
}
