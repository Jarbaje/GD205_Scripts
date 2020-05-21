using UnityEngine;

public class SafeZones : MonoBehaviour
{
    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreLayerCollision(12, 13, true);
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreLayerCollision(12, 13, false);
        }
    }
}
