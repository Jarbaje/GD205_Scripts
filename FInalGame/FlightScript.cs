using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlightScript : MonoBehaviour
{
    Rigidbody rb;
    GameObject[] groundedLeg, flyingLeg;

    public GameObject tail, burnerTail;

    // Control the slider handle (to imitate a light) to let player know flight is available
    public Slider offSlid, onSlid;

    // Variables used to swap the sliders in-game from red to green.
    bool flightLightOn = false;
    public RectTransform offHandle, onHandle;

    // Variables to control the speep, acceleration rate, take off speed and how much fuel the player has.
    // All variables are assigned in the inspector.
    public float speed,
                 maxSpeed,
                 acceleration,
                 takeOffSpeed;
                //  fuel;
    public static float fuel;
    
    //  Used to prevent the rigidbody from going too fast.
    int maxVelocity;

    // Variables used to check if the plane is on the ground or flying.
    // groundDistance is also used to 'retract' legs when taking off.
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;
    public AudioSource startEngine, jetFlying, powerDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        groundedLeg = GameObject.FindGameObjectsWithTag("Grounded");
        flyingLeg = GameObject.FindGameObjectsWithTag("Flying"); 
        maxVelocity = 600;
        
        // Set fuel to 100. This will deplete over time while the player accelerates.
        fuel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // Lose condition
        if(fuel <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOver");
        }

        // Win condition
        if(ShootScript.score == 30)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameCleared");
        }

        // Play sound when accelerating
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(isGrounded)
            {
                powerDown.Stop();
                jetFlying.Stop();
                startEngine.Play();
            }
        }

        // Stop sound when key is released.
        if (Input.GetKeyUp(KeyCode.W))
        {
            if(isGrounded)
            {
                startEngine.Stop();
                powerDown.Play();
            }
            if(!isGrounded)
            {
                startEngine.Stop();
            }
        }
    
        // play flying sound
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGrounded)
            {
                startEngine.Stop();
                powerDown.Stop();
                jetFlying.Play();;
            }
        }

        // Play power down clip.
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded)
        {
            if(!powerDown.isPlaying)
            {
                powerDown.Play();
            }
        }

        // If jet is not moving stop all sound.
        if(rb.velocity.magnitude < 5)
        {
            powerDown.Stop();
            startEngine.Stop();
            jetFlying.Stop();
        }

        // If jet is grounded stop flying sound.
        if(isGrounded)
        {
            jetFlying.Stop();
        }
    }
    void FixedUpdate()
    {   
        // raise tail
        tail.SetActive(true);
        burnerTail.SetActive(false);

        // Set the rb max velocity to 600
        // Velocity on the Z axis.
        if (rb.velocity.z > maxVelocity)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxVelocity);
        }

        if (rb.velocity.z < -maxVelocity)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxVelocity);
        }

        // Velocity on the X axis.
        if (rb.velocity.x > maxVelocity)
        {
            rb.velocity = new Vector3(maxVelocity, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < -maxVelocity)
        {
            rb.velocity = new Vector3(-maxVelocity, rb.velocity.y, rb.velocity.z);
        }  


        // Change the color of the flight light when velocity is adequate.
        if(rb.velocity.magnitude >= takeOffSpeed && flightLightOn == false)
        {
            offSlid.handleRect.gameObject.SetActive(false);
            offSlid.handleRect = onHandle;
            onSlid.handleRect.gameObject.SetActive(true);
            flightLightOn = true;
        }

        if(rb.velocity.magnitude < takeOffSpeed && flightLightOn == true)
        {
            onSlid.handleRect.gameObject.SetActive(false);
            onSlid.handleRect = offHandle;
            offSlid.handleRect.gameObject.SetActive(true);
            flightLightOn = false;
        }

        // Decrease speed when player is not accelerating.
        if( speed > 0 && !Input.GetKey(KeyCode.W))
        {
            speed -= 0.3f;
        }

        // isGrounded is true when the groundCheck gameObject is within the groundDistance from the ground layer.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // Vector3 variables for movement along the x, y, and z axis.
        Vector3 moveForward = transform.forward;
        Vector3 moveRight = transform.right;
        Vector3 look = transform.up;
        Vector3 altitude = transform.up;

        // used for rotation speed.
        Vector3 eulerAngleVelocity = new Vector3(0,100,0);

        // Accelerate and move forward.
        if(Input.GetKey(KeyCode.W))
        {
            // Depletes fuel while accelerating.
            fuel -= 0.01f;
            rb.AddForce(moveForward * speed);

            // raise tail
            tail.SetActive(false);
            burnerTail.SetActive(true);

            if(speed < maxSpeed)
            {
                speed += acceleration;
            } else {
                speed = maxSpeed;
            }
        }

        // Decelerate and fully stop.
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-moveForward * acceleration * 25f);
            if(rb.velocity.z < 0 && rb.velocity.z > -10)
            {
                speed = 0;
            }
            if(speed > 0)
            {
                speed -= (acceleration * 0.5f);
            } else {
                rb.velocity = Vector3.Normalize(Vector3.zero);
                speed = 0;
            }
        }

        // Increase altitude.
        if(Input.GetKey(KeyCode.Space))
        {
            if(rb.velocity.magnitude >= takeOffSpeed)
            {
                rb.position += altitude;
            }
        }

        // Decrease altitude.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(!isGrounded)
            {
                rb.position -= altitude;
            }
        }

        // Rotate Left.
        if (Input.GetKey(KeyCode.A))
        {
            // rb.AddForce(-moveRight * speed);
            Quaternion deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime); 
            rb.MoveRotation(rb.rotation * deltaRotation);          
        }

        //Rotate Right.
        if (Input.GetKey(KeyCode.D))
        {
            // rb.AddForce(moveRight * speed);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime); 
            rb.MoveRotation(rb.rotation * deltaRotation);           
        }

        // If velocity falls below the takeOffSpeed gravity kicks in.
        if( rb.velocity.magnitude < takeOffSpeed)
        {
            rb.useGravity = true;
            if(rb.drag < 0.5f)
            {
               rb.drag += 0.0005f;
            }
        } else {
            rb.useGravity = false;
            rb.drag = 0;
        }

        // Change the legs positions between grounded and flying.
        for (int i = 0; i < groundedLeg.Length; i++)
        {
            if(groundCheck.position.y < 20)
            {
                groundedLeg[i].SetActive(true);
                flyingLeg[i].SetActive(false);
            } else {
                groundedLeg[i].SetActive(false);
                flyingLeg[i].SetActive(true);
            }
        }

        // Controls the speedometer using the SpeedometerArrow script.
        SpeedometerArrow.ShowSpeed(rb.velocity.magnitude, 0, 600);
        // Controls the fuel.
        FuelArrow.ShowSpeed(fuel, 0, 100);
    }
}
