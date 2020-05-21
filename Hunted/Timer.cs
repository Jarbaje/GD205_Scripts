using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text gameTimerText;

    // Time can be modified in Unity. Value must be added in seconds (5 minutes = 300 seconds);
    public static float gameTimer;
    // Set time in Unity.
    public float timer;

    void Start()
    {
        // Start the game with only one minute then add 10 seconds with every kill.
        gameTimer = timer;
    }

    void Update()
    {
        gameTimer -= Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;

        
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        gameTimerText.text = timerString;

        // When timer runs out load GameOver scene. 
        // gameTimer < 1 runs the code as soon as the timer hits 0.
        if (gameTimer < 1)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOver");
        }

    }
}
