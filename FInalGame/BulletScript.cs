using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Destroy bullets after 3 seconds.
    void Update()
    {
        Invoke("RemoveBullet", 3.0f);
    }

    void RemoveBullet()
    {
        Destroy(gameObject);
    }
}
