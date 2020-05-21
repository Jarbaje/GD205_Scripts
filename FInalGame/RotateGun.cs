using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Quaternion newRot;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
        newRot = Quaternion.LookRotation(mousePos);

        float rotSpeed = Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotSpeed);
    }
}
