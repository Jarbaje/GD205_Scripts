using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float boomForce;
    public GameObject prefab0, prefab1, prefab2;

    bool plusOne;

    // Start is called before the first frame update
    void Start()
    {
        plusOne = false;
        prefab0 = Resources.Load("Projectile") as GameObject;
        prefab1 = Resources.Load("Target") as GameObject;
        prefab2 = Resources.Load("Target1") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Ray laser = new Ray (transform.position, Input.mousePosition);
        Debug.DrawRay(laser.origin, laser.direction * boomForce, Color.red);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(laser, out hit, 100f) && Input.GetMouseButtonDown(0)) {

            //This updates the bulletsLeft variable in the Bullets script.
            Bullets.bulletsLeft -= 1;

            Vector3 laserDir = laser.direction;
            GameObject projectile = Instantiate(prefab0, transform.position + Camera.main.transform.forward * 2, Quaternion.LookRotation(laser.direction)) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForceAtPosition(laserDir * boomForce, hit.point);
        }

        if (plusOne)
        {
            Score.scoreValue +=1;
            plusOne = false;
        }
    }

    void onCollisionEnter (Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Target")
        {
            Destroy(myCollision.gameObject);
            plusOne = true;
            Debug.Log("plusOne is working");
            GameObject target = Instantiate(prefab1) as GameObject;
            target.transform.position = new Vector3 (-4f, 1.24f, -0.5f);
        }

        if (myCollision.gameObject.tag == "Target1")
        {
            Destroy(myCollision.gameObject);
            plusOne = true;
            Debug.Log("plusOne is working");
            GameObject target = Instantiate(prefab2) as GameObject;
            target.transform.position = new Vector3 (4f, 0.49f, -0.5f);
        }
    }
}
