using UnityEngine;

public class SafeZones : MonoBehaviour
{

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
        collider.gameObject.layer = 2;
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
        collider.gameObject.layer = 0;
        }
    }
}
