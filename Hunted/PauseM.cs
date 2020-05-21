using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseM : MonoBehaviour
{
 public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    
       public void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            PauseMenuUI.SetActive(false);   //disables the pause menu in game mode.
            Time.timeScale = 1f;            //sets time back to normal.
            GameIsPaused = false;
        }

        void Pause()
        {
            Cursor.lockState = CursorLockMode.None;;
            PauseMenuUI.SetActive(true); //Activates the pause menu in game.
            Time.timeScale = 0f;        // Pause the time.
            GameIsPaused = true;
        }

       public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main Menu");
        }

       public void QuitGame()
        {
            Application.Quit();
        }
}
