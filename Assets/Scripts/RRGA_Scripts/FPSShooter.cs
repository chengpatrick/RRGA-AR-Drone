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

    // Design Related
    float mFireRate = .5f;
    float mFireRange = 50f;
    float mHitForce = 100f;
    float mNextFire;

    // Line Renderer
    LineRenderer mLineRenderer;
    bool mLaserLineEnabled;

    // Start is called before the first frame update
    void Start()
    {
        left = true;
        mLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            Fire();
            SoundManager.Instance.PlaySFXClipInVary("SFX_LaserShot", 0.9f, 1.2f);
        }
    }

    void Fire()
    {
        StartCoroutine(LaserFx());

        // Set Line Renderer as Laser
        if (left)
        {
            left = false;
            mLineRenderer.SetPosition(0, LFirePoint.position);
            //InstantiateProjectile(LFirePoint);
        }
        else
        {
            left = true;
            mLineRenderer.SetPosition(0, RFirePoint.position);
            //InstantiateProjectile(RFirePoint);
        }

        mLineRenderer.SetPosition(1, target.position);

        // Physics Check
        Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.tag == "Monster")
            {
                SoundManager.Instance.PlaySFXClip("SFX_LaserHit");
                Destroy(hit.transform.gameObject, .3f);
            }
        } 
    }

    IEnumerator LaserFx()
    {
        mLineRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        mLineRenderer.enabled = false;
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
