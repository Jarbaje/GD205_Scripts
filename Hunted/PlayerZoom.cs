using System.Collections;
using UnityEngine;

public class PlayerZoom : MonoBehaviour
{
    // variables for zooming in and out
    public int zoom = 20;
    public int normal = 60;
    public int smooth = 5;
    public static bool isZoomed = false;

    // reference to show/hide red panel while zooming in and out
    public GameObject hunterVision;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isZoomed = true;
        } else {
            isZoomed = false;
        }

        if (isZoomed)
        {
            hunterVision.SetActive(true);
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
       
        } else {
            hunterVision.SetActive(false);
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
        
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, 10000f))
        {
            if((hit.collider.gameObject.tag == "Ground" && isZoomed) || (hit.collider.gameObject.tag == "Enemy" && isZoomed))
            {
                hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
            } else {
                if(hit.collider.gameObject.GetComponent<Renderer>() != null)
                {
                    hit.collider.gameObject.GetComponent<Renderer>().enabled = true;
                }
            }
        }
    }
}
