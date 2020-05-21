using UnityEngine;
using UnityEngine.AI;


public class AIEnemy : MonoBehaviour
{
        public UnityEngine.AI.NavMeshAgent agent;

        public GameObject[] waypoints;
        private int waypointInd;
        public float patrolSpeed = 0.5f;

        // Variable to make only enemy's heart visible when the player enters Zoomed mode.
        // Renderer rend;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            // rend = GetComponent<Renderer>();
            

            waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
            waypointInd = Random.Range(0, waypoints.Length);
        }

        void Update()
        {
            Patrol();
            // Code only works on Primitive shapes. Does not work on 3D models.
            // if(PlayerZoom.isZoomed)
            // {
            //     rend.enabled = false;
            // } else {
            //     rend.enabled = true;
            // }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >=2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd = Random.Range(0, waypoints.Length);
            }
        }
}
