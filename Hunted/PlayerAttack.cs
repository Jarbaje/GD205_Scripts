using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    // Attack code has been moved to EnemyAI script for optimization purposes.

    GameObject[] enemies;

    // Variable to keep track of the score. If score is squal to 3 (subject to change) game is cleared.
    int score;

    // Game difficulty
    public static bool isHard;

     //Play audio when destroyed
         public AudioClip scream;
        AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetMouseButtonDown(0)){
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemy.Length; i++)
            {
                if(Vector3.Distance(enemy[i].transform.position, gameObject.transform.position) < 10)
                {
                    if(isHard == false)
                    {
                        Timer.gameTimer += 10;
                    }
                    score += 1;
                    Destroy(enemy[i]);
                    audioSource.PlayOneShot(scream, 1.0F);
                }
            }

            if(score==enemies.Length)
            {
                Cursor.lockState = CursorLockMode.None;
                // Unlock the mouse cursor.
                // PlayerLook.hideCursor = false;
                /* buildIndex 0 = Main Menu,
                            1 = Gameplay,
                            2 = GameOver,
                            3 = GameCleared.
                */
                // Adds two to the current buildIndex to get to the winning screent.
                SceneManager.LoadScene("GameCleared");
            }
        }
    }
}
