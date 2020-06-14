using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject Menu;
    public GameObject Resume;

    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                Menu.SetActive(true);
                Resume.SetActive(true);
                
            }
            else
            {
                pauseMenu.SetActive(false);
                Menu.SetActive(false);
                Resume.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }
    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Menu.SetActive(false);
        Resume.SetActive(false);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
    }

}
