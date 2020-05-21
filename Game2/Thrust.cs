using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Thrust : MonoBehaviour
{

    // public GameObject player;
    Rigidbody rb;
    // public GameObject victim;
    public string predatorTag, preyTag;
    public static int eatCount, timesEaten;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eatCount = 0;
        timesEaten = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        //Updates the score as the player eats the prey.
        if(eatCount < 5) 
        {
            score.text = "Run for your life...";
        } else {
        score.text = "You are now at the top of the food chain!";
        }
        // rb.AddForce(transform.forward * 5f);
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.CompareTag(preyTag))
        // if (myCollision.gameObject == victim)
        {
            Destroy(myCollision.gameObject);
            eatCount += 1;
            Debug.Log("eatCount = " + eatCount);
            gameObject.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
       
        } else if (myCollision.gameObject.CompareTag(predatorTag) && eatCount < 5)
        {
            Destroy(gameObject);
            timesEaten += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Debug.Log("timesEaten = " + timesEaten);


        }
           else if(myCollision.gameObject.CompareTag(predatorTag) && eatCount >= 5)
        {
            Destroy(myCollision.gameObject);
            eatCount += 1;
            // Debug.Log("eatCount = " + eatCount);
            gameObject.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
        }
    }
}
