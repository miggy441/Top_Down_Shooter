using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public InputHandler inputHandler;
    public GameObject mainMenu; 
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance().OnGameOverAction += gameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        mainMenu.SetActive(false);
    }

    private void pauseGame()
    {
        pauseMenu.SetActive(true);
        GameManager.GetInstance().pauseGame();
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        GameManager.GetInstance().resumeGame();

    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void retry()
    {
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameManager.GetInstance().retry();
    }

    // public void backToStart()
    // {
    //     pauseMenu.SetActive(false);
    //     GameManager.GetInstance().pauseGame();
    //     mainMenu.SetActive(true);
    // }

    public void quitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        inputHandler.OnPauseAction += pauseGame;
    }

    private void OnDisable()
    {
        inputHandler.OnPauseAction -= pauseGame;
    }

    
}
