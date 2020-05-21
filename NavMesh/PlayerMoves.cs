using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoves : MonoBehaviour
{
    public float boomForce = 10f;
    NavMeshAgent player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(laser.origin, laser.direction * boomForce, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(laser, out hit) && Input.GetMouseButtonDown(0))
        {
            player.SetDestination(hit.point);
        }

    }
}
