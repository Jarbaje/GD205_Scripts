using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedometerArrow : MonoBehaviour
{
    // The minium and maximum rotation of the arrow copied from the inspector
    // At minAngle speedometer is at 0.
    // At macAngle speedometer is at 600.
    public static float minAngle = 108f;
    public static float maxAngle = -220;

    // Creates a reference to this script that can be called from another script.
    static SpeedometerArrow thisSpeedo;

    void Start()
    {
        thisSpeedo = this;
    }

    // Parameters will be filled on the other script.
    public static void ShowSpeed(float speed, float min, float max)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        thisSpeedo.transform.eulerAngles = new Vector3(0, 0, ang);
    }
}
