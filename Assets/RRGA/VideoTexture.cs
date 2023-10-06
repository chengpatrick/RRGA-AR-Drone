using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTexture : MonoBehaviour
{
    public MeshRenderer Tello;

    public GameObject VideoBackground;
    public Shader VideoBackgroundShader;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TransferMaterial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TransferMaterial()
    {
        yield return new WaitForSeconds(2);
        VideoBackground = GameObject.Find("VideoBackground");
        
        VideoBackgroundShader = VideoBackground.GetComponent<MeshRenderer>().material.shader;
        Tello.material.shader = VideoBackgroundShader;

        VideoBackground.GetComponent<MeshRenderer>().material = Tello.material;
    }
}
