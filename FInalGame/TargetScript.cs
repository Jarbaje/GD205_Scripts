using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Gets the rigidbody in the targets and destroys the gameObject when hit by a bullet.
    void OnCollisionEnter(Collision myCollision)
    {
        if(myCollision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    // When Destroy() is called, adds one to the score variable in the ShootScript.
    void OnDestroy()
    {
        // Layer 9 is "Cookie"
        if(gameObject.layer == 9)
        {
            ShootScript.score += 5;
            FlightScript.fuel = 100;
        } else {
            ShootScript.score ++;
        }

    }
}
