using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenuUI;
    bool GameIsPause = false;

    void Update()
    {
        // Pause and resume game with the Esc key.
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                Resume();
            } else {
                Pause();
            }
        }
    }

    // Load GamePlay scene.
    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    // Load Main Menu.
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Stop time and pause game.
    public void Pause()
    {  
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPause = true;

    }
    // Start time and resume gameplay.
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPause = false;
    }
}
