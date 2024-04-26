using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject pauseForGame;


    public void PauseinGame()
    {
        pauseMenu.SetActive(true);
        pauseForGame.SetActive(false);
        Time.timeScale = 0;



    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseForGame.SetActive(true);
        Time.timeScale = 1;
    }

 }
