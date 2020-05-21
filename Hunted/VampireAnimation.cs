using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireAnimation : MonoBehaviour
{

    public Animator myAnim;

    /**
    MoveState Values: -2 = BackRun,
                      -1 = BackWalk,
                      0 = Idle,
                      1 = Walk,
                      2 = Flying,
                      3 = Attack,
                      4 = Left Strafe Walk,
                      5 = Right Strafe Walk.
    **/
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the position of the empty object containing the 3D avatar so that it follows the child elements.
        // emptyObject.position = model3D.position;
        // Character is idle when no key is pressed.
        myAnim.SetInteger("MoveState", 0);

        // Forward movement.
        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
            {
                myAnim.SetInteger("MoveState", 2);
            } else {
                myAnim.SetInteger("MoveState", 1);
            }
        }

        // Backwards movement.
        if (Input.GetKey(KeyCode.S))
        {
            myAnim.SetInteger("MoveState", -1);

            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
            {
            myAnim.SetInteger("MoveState", -2);
            }
        }

        // Left movement
        if(Input.GetKey(KeyCode.A))
        {
            myAnim.SetInteger("MoveState", 4);
        }

        // Right movement
        if(Input.GetKey(KeyCode.D))
        {
            myAnim.SetInteger("MoveState", 5);
        }

        // Player attack animation
        if(Input.GetMouseButtonDown(0))
        {
            myAnim.SetInteger("MoveState", 3);
        }
    }
}
