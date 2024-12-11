using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public GameObject winPanel;
    public Button homeButton;

    void Awake()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    void Update()
    {
        if (winPanel.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void WonPanel()
    {
        winPanel.SetActive(true);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}