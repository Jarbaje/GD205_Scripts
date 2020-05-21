using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyBehavior : MonoBehaviour
{
    Rigidbody rb;
    public Transform predator;
    public float hungerForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        //Prey will run from player if within 20 position units from it.
        if( Vector3.Distance(predator.position, transform.position) < 20)
        {
        Vector3 predatorDirection = Vector3.Normalize(predator.position - transform.position);

        rb.AddForce( -predatorDirection * hungerForce);
        } else {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }

    }
}
