using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public RectTransform target;

    private int interpolationFramesCount = 60; // Number of frames to completely interpolate between the 2 positions
    private int elapsedFrames = 0;

    // Update is called once per frame
    void Update()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        Vector3 movement = Vector3.Lerp(gameObject.GetComponent<RectTransform>().localPosition, target.localPosition, interpolationRatio);
        gameObject.GetComponent<RectTransform>().localPosition = movement;

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

        if (gameObject.GetComponent<RectTransform>().localPosition == target.localPosition)
        {
            transform.parent.parent.GetComponent<FPSShooter>().BulletToCrossHair();
            Destroy(gameObject);
        }
    }
}
