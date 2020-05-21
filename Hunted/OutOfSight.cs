using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfSight : MonoBehaviour
{
    public AudioClip gasp;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   void OnTriggerEnter(Collider col)
    {
        BoxCollider bc = col.gameObject.GetComponent<BoxCollider>();

        // Runs code if the player is within the 'sight' box collider of the enemy
        if (bc != null && bc.gameObject.CompareTag("Enemy"))
        {
            // Make the enemy jump back.
            transform.position += new Vector3(0,1,-1);
            
            // Enemy gasps at the sight of the player.
            audioSource.PlayOneShot(gasp, 1.0F);
            Invoke("GameOver", 0.5f);

            // Display mouse and load next scene.
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
