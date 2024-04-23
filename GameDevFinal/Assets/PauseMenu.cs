using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;


    public void PauseinGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SmallPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


    public void BigPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
