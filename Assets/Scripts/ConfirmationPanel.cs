using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmationPanel : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Button acceptButton;
    public Button declineButton;

    void Awake()
    {
        confirmationPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (confirmationPanel.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void ConfirmPanel()
    {
        confirmationPanel.SetActive(true);
    }

    public void AcceptButton()
    {
        if (SceneManager.GetActiveScene().name == "GiantSkeletonDungeon" || SceneManager.GetActiveScene().name == "DemonDungeon")
            SceneManager.LoadScene("SkullIsland2");
        
        if (SceneManager.GetActiveScene().name == "SkullIsland2")
        {
            SceneManager.LoadScene("GiantSkeletonDungeon");
        }

        if (SceneManager.GetActiveScene().name == "SkullIsland3")
        {
            SceneManager.LoadScene("DemonDungeon");
        }
    }

    public void DeclineButton()
    {
        confirmationPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}