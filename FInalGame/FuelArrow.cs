using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelArrow : MonoBehaviour
{
    public static float minAngle = 130;
    public static float maxAngle = 406;

    static FuelArrow thisSpeedo;

    void Start()
    {
        thisSpeedo = this;
    }

    public static void ShowSpeed(float speed, float min, float max)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        thisSpeedo.transform.eulerAngles = new Vector3(0, 0, ang);
    }
}
