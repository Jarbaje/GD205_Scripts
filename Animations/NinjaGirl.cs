using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaGirl : MonoBehaviour
{
     Animator myAnim;


     /** 
     MoveState values:  0 = Idle, 
                        1 = Taunt, 
                        -1 = Dying, 
                        2 = Standing Up, 
                        3 = Punch Combo, 
                        4 = Roundhouse Kick.
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

        // Character taunts.
        if (Input.GetKeyDown(KeyCode.I))
        {
            myAnim.SetInteger("MoveState", 1);
        }

        // Character falls to the floor.
        if (Input.GetKeyDown(KeyCode.U))
        {
            myAnim.SetInteger("MoveState", -1);
        }

        // Character gets up.
        if (Input.GetKey(KeyCode.J))
        {
            myAnim.SetInteger("MoveState", 2);
        }

        // Character throws a punching combo
        if (Input.GetKeyDown(KeyCode.L))
        {
            myAnim.SetInteger("MoveState", 3);
        }

        // Character throws a roundhouse kick
        if (Input.GetKeyDown(KeyCode.K))
        {
            myAnim.SetInteger("MoveState", 4);
        }
    }
}
