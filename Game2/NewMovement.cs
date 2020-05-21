using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 m_EulerAngleVelocity;


    // Start is called before the first frame update
    void Start()
    {

        m_EulerAngleVelocity = new Vector3 (0,100,0);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            // Move Right
            if (Input.GetKey(KeyCode.D))
            {
            rb.AddForce(transform.right * 10f);
            }        
            
            // Move Left
            if (Input.GetKey(KeyCode.A))
            {
            rb.AddForce(-transform.right * 10f);
            }

            // Move Forward
            if (Input.GetKey(KeyCode.W))
            {
            rb.AddForce(transform.forward * 10f);
            }        
            
            // Move Backwards
            if (Input.GetKey(KeyCode.S))
            {
            rb.AddForce(-transform.forward * 10f);
            }
         }

         if (gameObject.tag == "Enemy")
         {
            //  rb.rotation = Quaternion.identity;
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
         }
    }
}
