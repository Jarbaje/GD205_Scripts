using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatGuyMove : MonoBehaviour
{
    Animator myAnim;

    /**
    MovesState values:  0 = Idle,
                        1 = Walk,
                        -1 = Jump,
                        2 = Run,
                        3 = Roll,
                        5 = Left strafe,
                        6 = Right strafe,
                        7 = Left turn,
                        8 = Right turn.
    **/
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Character is idle when no key is pressed.
        myAnim.SetInteger("MoveState", 0);

        // Character moves forward as long as the W is pressed.
        // Runs when LeftShift is pressed and Rolls and R is pressed while running.
        if (Input.GetKey(KeyCode.W))
        {
            myAnim.SetInteger("MoveState", 1);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                myAnim.SetInteger("MoveState", 2);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    myAnim.SetInteger("MoveState", 4);
                }
            }
            // Character walks Left.
            if (Input.GetKey(KeyCode.A))
            {
                myAnim.SetInteger("MoveState", 5);
            }

            // Character walks right.
            if (Input.GetKey(KeyCode.D))
            {
                myAnim.SetInteger("MoveState", 6);
            }
        }


        // Character turn Left.
        if (Input.GetKeyDown(KeyCode.A))
        {
            myAnim.SetInteger("MoveState", 7);
        }

        // Character turns right.
        if (Input.GetKeyDown(KeyCode.D))
        {
            myAnim.SetInteger("MoveState", 8);
        }

         // Character jumps when the Space bar is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetInteger("MoveState", -1);
        }
    }
}
