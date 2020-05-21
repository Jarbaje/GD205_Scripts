using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        /* buildIndex 0 = Main Menu,
                      1 = Level1,
                      2 = GameOver,
                      3 = GameCleared.
        */
            SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
         SceneManager.LoadScene("Main Menu");
    }
}
