using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    
    public void PlayGame()
    {
        GameObject.FindGameObjectWithTag("PlayButton");
        SceneManager.LoadScene("Level1");
       
    }

    public void GameLevel()
    {
        GameObject.FindGameObjectWithTag("LevelsButton");
        SceneManager.LoadScene("Levels");
        
    }

    public void LevelOne()
    {
        GameObject.FindGameObjectWithTag("1");
        SceneManager.LoadScene("Level1");
        
    }

    public void LevelTwo()
    {
        GameObject.FindGameObjectWithTag("2");
        SceneManager.LoadScene("Level2");
       
    }

    public void LevelThree()
    {
        GameObject.FindGameObjectWithTag("3");
        SceneManager.LoadScene("Level3");

    }

    public void GoToMenu()
    {
        GameObject.FindGameObjectWithTag("BackButton");
        SceneManager.LoadScene("MainMenu");

    }
    public void GoToMainMenu()
    {
        //GameObject.FindGameObjectWithTag("MenuButton");
        SceneManager.LoadScene("MainMenu");

    }
    public void Quiting()
    {
        Debug.Log("Bye bye");
        Application.Quit();
    }
}
