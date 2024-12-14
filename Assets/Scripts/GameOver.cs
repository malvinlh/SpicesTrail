using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject confirmationPanel;
    public Button homeButton;
    public Button restartButton;
    public Button acceptButton;
    public Button declineButton;

    private AudioManager audioManager;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        confirmationPanel.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
        Time.timeScale = 1f; // Resume the game
    }

    void Update()
    {
        if (gameOverPanel.activeSelf || confirmationPanel.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
        confirmationPanel.SetActive(false);
    }

    public void ConfirmationPanel()
    {
        confirmationPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        audioManager.ClickSFXPlay();
        ConfirmationPanel();
    }

    public void RestartButton()
    {
        audioManager.ClickSFXPlay();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    // public void AcceptButton()
    // {
    //     audioManager.ClickSFXPlay();
    //     SceneManager.LoadScene("MainMenu");
    // }

    // public void DeclineButton()
    // {
    //     audioManager.ClickSFXPlay();
    //     gameOverPanel.SetActive(true);
    //     confirmationPanel.SetActive(false);
    // }
}