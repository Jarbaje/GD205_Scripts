using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null & bc.gameObject.CompareTag("Enemy"))
                {
                    Destroy(bc.gameObject);
                }
            }
        }
    
    }
}
