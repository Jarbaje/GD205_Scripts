using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2Behavior : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        prefab = Resources.Load("Target1") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.x > -4)
        {
            rb.AddForce( -transform.forward * speed);
        } 
    }

    void OnCollisionEnter (Collision myCollision)
    {
        Destroy(gameObject);
        GameObject target = Instantiate(prefab) as GameObject;
        target.transform.position = new Vector3 (4f, 0.49f, -0.5f);
    }
}
