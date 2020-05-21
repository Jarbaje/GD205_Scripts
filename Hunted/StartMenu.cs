using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject mainMenu, instructions;

    public static float mouseSet;
    private float mouseSpeed;

    void Update()
    {
        mouseSet = mouseSpeed;
    }
    // public void PlaytGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application closed!");
    }

    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        instructions.SetActive(true);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        instructions.SetActive(false);
    }

    public void PlayHard()
    {
        PlayerAttack.isHard = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayNormal()
    {
        PlayerAttack.isHard = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

        public void OnValueChanged(float val)
    {
        mouseSpeed = val;        
    }
}
