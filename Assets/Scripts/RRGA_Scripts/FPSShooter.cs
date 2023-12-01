using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class FPSShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform LFirePoint, RFirePoint;
    [SerializeField] Transform target;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Vector2 crossHairXRange = new Vector2(-100f, 100f);
    [SerializeField] Vector2 crossHairYRange = new Vector2(-100f, 100f);
    [SerializeField] float crossHairSpeed = 1f;
    [SerializeField] float crossHairTotargetMapping = 1.6f / 100f;

    private bool left;
    public float projectileSpeed = 30f;

    // Design Related
    float mFireRange = 500f;


    // Line Renderer
    LineRenderer mLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        left = true;
        mLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Fire();
            SoundManager.Instance.PlaySFXClipInVary("SFX_LaserShot", 0.9f, 1.2f);
        }
        // Debug.Log("Shooter: Crosshair: " + crosshair.localPosition);

        if (Input.GetAxis("Thrustmaster Throttle Flip X") != 0)
        {
            // Debug.Log("Shooter: Thrustmaster Throttle Flip X: " + Input.GetAxis("Thrustmaster Throttle Flip X"));
            Vector3 newLocalX = crosshair.localPosition + new Vector3(Input.GetAxis("Thrustmaster Throttle Flip X") * crossHairSpeed, 0, 0);
            crosshair.localPosition = new Vector3(Mathf.Clamp(newLocalX.x, crossHairXRange.x, crossHairXRange.y), crosshair.localPosition.y, crosshair.localPosition.z);
            Vector3 targetPos = new Vector3(crosshair.localPosition.x * crossHairTotargetMapping, crosshair.localPosition.y * crossHairTotargetMapping, target.localPosition.z);
            target.localPosition = targetPos;
        }

        if (Input.GetAxis("Thrustmaster Throttle Flip") != 0)
        {
            // Debug.Log("Shooter: Thrustmaster Throttle Flip: " + Input.GetAxis("Thrustmaster Throttle Flip"));
            Vector3 newLocalY = crosshair.localPosition + new Vector3(0, Input.GetAxis("Thrustmaster Throttle Flip") * crossHairSpeed, 0);
            crosshair.localPosition = new Vector3(crosshair.localPosition.x, Mathf.Clamp(newLocalY.y, crossHairYRange.x, crossHairYRange.y), crosshair.localPosition.z);
            Vector3 targetPos = new Vector3(crosshair.localPosition.x * crossHairTotargetMapping, crosshair.localPosition.y * crossHairTotargetMapping, target.localPosition.z);
            target.localPosition = targetPos;
        }
        //Debug.Log("Shooter: Crosshair: " + crosshair.localPosition);

    }

    private void FixedUpdate()
    {
    }


    void Fire()
    {
        if (left)
        {
            left = false;
            mLineRenderer.SetPosition(0, RFirePoint.position);
        }
        else
        {
            left = true;
            mLineRenderer.SetPosition(0, LFirePoint.position);
        }


        /*
        Vector3 wordPos = cam.ScreenToWorldPoint(crosshair.position);
        Ray ray = new Ray(wordPos, Vector3.up);
        */
        Ray ray = Camera.main.ScreenPointToRay(crosshair.position);
        Debug.DrawRay(cam.transform.position, ray.direction*2000f, new Color(1, 1, 1), 10f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,5000f))
        {
            Debug.Log("Hit something");
            mLineRenderer.SetPosition(1, target.position);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Monster")
                {
                    Debug.Log("Shooter: Hit");
                    SoundManager.Instance.PlaySFXClip("SFX_LaserHit");
                    Destroy(hit.transform.gameObject, .3f);
                }
            }

        }


        StartCoroutine(LaserFx());
    }

    IEnumerator LaserFx()
    {
        mLineRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        mLineRenderer.enabled = false;
    }

    /*
        void InstantiateProjectile(Transform firePoint)
        {
            GameObject projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity);
            // projectileObj.transform.parent = gameObject.transform;
            // projectile.GetComponent<Rigidbody>().velocity = (target.position - firePoint.position).normalized * projectileSpeed;
            // projectile.GetComponent<Rigidbody>().AddForce((target.position - firePoint.position).normalized * projectileSpeed);
            projectileObj.GetComponent<Projectile>().velocity = (target.position - firePoint.position).normalized * projectileSpeed;
            Debug.Log((target.position - firePoint.position).normalized * projectileSpeed);
        }
    */
}
