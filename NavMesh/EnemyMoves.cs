using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoves : MonoBehaviour
{
    //Patrolling
    public Transform[] points;
    private int destPoints = 0;
    bool playerSighted = false;

    public GameObject player;
    NavMeshAgent enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        enemy.autoBraking = false;

        GotoNextPoint();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerSighted)
        {
        enemy.SetDestination(player.transform.position);
        }

        //Choose the next destination point
        //when the agent gets closed to the current one.
        if (!enemy.pathPending && enemy.remainingDistance < 0.5f && playerSighted == false)
        {
            GotoNextPoint();
        }
    }

    // void OnTriggerEnter(Collider collider)
    // {

    // }

    void OnTriggerStay (Collider collider)
    {
        if ( collider.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            playerSighted = true;
            // player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void OnTriggerExit ( Collider collider)
    {
         if ( collider.gameObject.tag == "Player")
        {
            playerSighted = false;
            // player = GameObject.FindGameObjectWithTag("Player");
        }
    }

     void GotoNextPoint()
    {
        //Returns if no points have been set up.
        if (points.Length ==  0)
        {
            return;
        }

        //Set the agent to go to the current selected destination
        enemy.destination = points[destPoints].position;

        //Choose the next point in the array as the destination,
        //cycling to the start if necessary.
        destPoints = (destPoints + 1) % points.Length;
    }
}
