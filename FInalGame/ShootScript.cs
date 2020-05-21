using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{  
    GameObject bulletPrefab;
    bool allowFire;

    // score is modified from the TargetScript every time a target is destroyed.
    public static int score;

    // Add text gameObject in the inspector to display the current score.
    public Text scoreText;

    // Used to play a sound when machine gun is fired.
    public AudioClip shootingClip;
    AudioSource audioSource;

    // Variables for fire rate
    public float fireRate = 0.5f;
    float nextFire = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display score.
        scoreText.text = "Score : " + score;

        // Shoot with left mouse click.
        // nextFire starts at zero to allow first shot to happen immediately.
        if(Input.GetMouseButton(0) && Time.time > nextFire)
        {
            // Determines the fire rate after the first shot is fired.
            nextFire = Time.time + fireRate;

            // Create a ray from the main camera to the mouse position.
            Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // variables for instantiating bullets while shooting.
            // bulletPos determines where the bullets spawn (in front of the elephant's trunk).
            // laserDir stores the direction of the ray for convenience.
            Vector3 bulletPos = transform.position + transform.up * 6  + transform.right * -0.25f;
            Vector3 laserDir = laser.direction;

            // Instantiate bullet from the bulletPrefab at the bulletPos position with the rotation of the parent.
            GameObject projectile = Instantiate(bulletPrefab, bulletPos, Quaternion.identity) as GameObject;

            // Get the Rigidbody of the bullet and add force in the direction of the ray with a force in float.
            projectile.GetComponent<Rigidbody>().AddForceAtPosition(laserDir * 50000, bulletPos);

            // Play shooting sound.
            audioSource.PlayOneShot(shootingClip);
        }
    }
}
