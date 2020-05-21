 // using System.Diagnostics;
using System;
// using System.Numerics;
using System.Xml.Schema;
using System.Threading;
// using System.IO.Enumeration;
// using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    bool isGrounded;
    public Rigidbody myRigidbody, aniBody;
    float m_Speed, jumpForce;
    Vector3 jump;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        myRigidbody = GetComponent<Rigidbody>();
        aniBody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 15.0f;
        jumpForce = 2.0f;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        if (gameObject.tag == "Player") 
        {
             myRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
             myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            if (Input.GetKey(KeyCode.W))
            {
                //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
                myRigidbody.velocity = transform.forward * m_Speed;
                myRigidbody.constraints = RigidbodyConstraints.None;
            }

            if (Input.GetKey(KeyCode.S))
            {
                //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
                myRigidbody.velocity = -transform.forward * m_Speed;
                myRigidbody.constraints = RigidbodyConstraints.None;

            }

            if (Input.GetKey(KeyCode.D))
            {
                //Rotate the sprite about the Y axis in the positive direction
                // transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed *2, Space.World);
                myRigidbody.velocity = transform.right * m_Speed;
                myRigidbody.constraints = RigidbodyConstraints.None;
            }

            if (Input.GetKey(KeyCode.A))
            {
                //Rotate the sprite about the Y axis in the negative direction
                // transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * m_Speed *2, Space.World);
                myRigidbody.velocity = -transform.right * m_Speed;
                myRigidbody.constraints = RigidbodyConstraints.None;
            }

            //When the Space bar is pressed the player will shift between grounded and flying
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                gameObject.transform.position += new Vector3 (0f, 3f, 0f);
                isGrounded = false;
            } else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
            {
                gameObject.transform.localScale = new Vector3(2f,2f,2f);
                gameObject.transform.position += new Vector3 (0f, -3f, 0f);
                isGrounded = true;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
            }

        }

        //Animal1 movement
        if (gameObject.name == "Animal1")
        {
            aniBody.AddForce(transform.forward * 0.10f);
            aniBody.transform.Rotate(new Vector3(0, -5, 0) * Time.deltaTime * 1.0f, Space.World);
        }

        //Animal2 movement
        if (gameObject.name == "Animal2")
        {
            aniBody.AddForce( -transform.right * 0.10f);
            aniBody.transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime * 1.0f, Space.World);
        }

        //Animal3 movement
        if (gameObject.name == "Animal3")
        {
            aniBody.AddForce(transform.forward * 0.5f);
           if (gameObject.name == "Animal3" && gameObject.transform.position.y < 3)
           {
               aniBody.AddForce(jump * jumpForce, ForceMode.Impulse);
           } 
        }
    }
}
