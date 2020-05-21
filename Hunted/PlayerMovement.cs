using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the player controller in Unity
    public CharacterController controller;
    

    // public variables to manipulate movement speed, gravity force and jump height in Unity.
    float speed = 12f;

    public int running;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // Public variables used to check is the player is grounded.
    // If grounded, no gravity is applied. If not grounded, gravity is applied.
    // Add an empty object to the player in Unity. 
    // Position it at the bottom of the player object and add that reference to groundCheck in Unity.
    // groundDistance is used to calculate the size  of the sphere that collides with the ground to check if isGrounded.
    // In Unity create a new layer for the objects where the player can stand on (like the ground) and select it under groundMask.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    // isGrounded checks if the player is standing on a surface (with the layermask equal to groundMask).
    // If false, velocity kicks in to pull the player towards the ground.
    Vector3 velocity;
    bool isGrounded;

    public AudioClip heartBeat;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Reset player position when falling of the stage.
        if(transform.position.y < -15)
        {
            PlayerLook.hideCursor = false;
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
        {
            speed = running;
        } else {
            speed = 12;
        }

        // Physics.CheckSphere looks for a collision and takes three arguments.
        // groundCheck is the empty object created in unity to get a position.
        // groundDistance is the size of the sphere.
        // And groundMask filters to check for collision against the layered objects only.
        isGrounded = Physics.CheckSphere (groundCheck.position, groundDistance, groundMask);

        // The value of velocity.y decreases as the gravity force increases.
        // If the player is grounded and the velocity is less than 0 (player is falling),
        // Set the velocity to -2 (this is to ensure that the player is forced to the ground instead of slightly floating over it).
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        // Used to get the horizontal and vertical axis in Unity's Input system (built-in).
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // controller.Move() accesses the controller component in Unity.
        // Here it is used to control movement on the x-axis using the built-in Input keys WASD.
        // Vector3 'move' gives us local direction, speed can be modified in Unity, and Time.deltaTime allows for movement
        // independent from Update()'s framerate.
        Vector3 move = transform.right * x +transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        // "Jump" is also built into the controller component in Unity like WASD. It's attached to the Space bar.
        // If the Spacebar is pressed and the player is grounded, the player jumps.
        // jumpHeight can be modified in Unity.
        // if(Input.GetButtonDown("Jump") && isGrounded)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        // }

        // Here controller.Move() is used to add movement in the y-axis using the 'velocity'and 'gravity' variables we created.
        // velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Play heartbeat when player enters the enemy awareness zone.
    // If player is running enemy turns towards the player.
    void OnTriggerEnter(Collider col)
    {
        CapsuleCollider cc = col.gameObject.GetComponent<CapsuleCollider>();

        // Play heartbeat when player enters the enemy awareness zone.
        if(cc != null && cc.gameObject.CompareTag("Awareness"))
        {
            audioSource.Play();
        }
    }

    // Enemy turns to player if player runs while inside the enemy awareness zone.
    void OnTriggerStay(Collider col)
    {
        CapsuleCollider cc = col.gameObject.GetComponent<CapsuleCollider>();

        // Changes the background music to more intense.
        // If player is running enemy turns towards the player.
        // Enemies have an empty gameObject attached with a trigger for awarness tagged "Awareness"
        if(cc != null && cc.gameObject.CompareTag("Awareness"))
        {
            Transform parent = cc.gameObject.transform.parent;
            if(Input.GetKey(KeyCode.Space))
            {
                parent.LookAt(transform.position);
            }
        }
    }

    // Stop playing the heartbeat once the player leaves the enemy awareness zone.
    void OnTriggerExit(Collider col)
    {
        CapsuleCollider cc = col.gameObject.GetComponent<CapsuleCollider>();

        if(cc != null && cc.gameObject.CompareTag("Awareness"))
        {
            audioSource.Stop();
            
        }
    }
}
