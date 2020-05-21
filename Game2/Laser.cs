using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    //Used to adjust the explosive power of the ray in Unity.
    public float boomForce = 10f;

    // These colors will be used in tangent with the camera to change the background color.
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;

    public Camera cam;
    public Transform enemy;


    public AudioClip scream;
    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    //     // Creates a ray from the main camera to the mousePosition
    //     Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
       
    //    //This creates a visible ray in the Scene window in Unity that can used to help debug the position and direction of the ray.
    //     Debug.DrawRay(laser.origin, laser.direction * boomForce, Color.red);       
        
    //     //This is similar to onCollision(); it stores the information related to a raycast hitting an object.
    //     RaycastHit hit = new RaycastHit();

    //     // For Physics.Raycast();
    //     // When the ray 'laser' hits an object that is within the distance specified in floats (in this case 10K)
    //     // The information stored in the RaycastHit 'hit' is pulled.
    //     if (Physics.Raycast(laser, out hit, 10000f) && Input.GetMouseButton(0)) {
    //         Debug.Log("you hit something lol");

    //         // if the object stored in 'hit' has a rigidbody execute the code.
    //         if (hit.rigidbody) {
    //             Vector3 randomDirection = Random.insideUnitSphere;
    //             hit.rigidbody.AddForce(randomDirection * boomForce);
    //         }
    //     }
    
       
       
        // // Creates a ray from the gameObject that has the script
        // Ray laser = new Ray (transform.position, transform.forward);
        // Debug.DrawRay(laser.origin, laser.direction * boomForce, Color.red);
        // RaycastHit hit = new RaycastHit();

        // if (Physics.Raycast(laser, out hit, 5f) && Input.GetMouseButton(0)) {

        //     // if the object stored in 'hit' has a rigidbody execute the code.
        //     if (hit.rigidbody) {
        //         Vector3 randomDirection = Random.insideUnitSphere;
        //         hit.rigidbody.AddForce(randomDirection * boomForce);
        //     }
        // }

        
        // Creates a Ray from the gameObject that has the script
        // Ray will be used to create an awareness system to react when an object gets close to the gameObject with the script.
        Ray laser = new Ray (enemy.position, enemy.forward);
        Debug.DrawRay(laser.origin, laser.direction * boomForce, Color.red);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(laser, out hit, 5f)) {

            // if the object stored in 'hit' has a rigidbody execute the code.
            if (hit.rigidbody) {

                enemy.position += new Vector3 (0,3,0);
                Vector3 randomDirection = Random.insideUnitSphere;
                hit.rigidbody.AddForce(randomDirection * boomForce);

                //Changes the background color.
                float t = Mathf.PingPong(Time.time, duration) / duration;
                cam.backgroundColor = Color.Lerp(color1, color2, t);

                //Play a screaming sound.
                audioSource.PlayOneShot(scream, 0.7F);
            }
        }
    
    }
}
