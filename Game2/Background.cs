using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{

    // These colors will be used in tangent with the camera to change the background color.
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.Skybox;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            //Changes the background color.
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(color1, color2, t);
    }
}
