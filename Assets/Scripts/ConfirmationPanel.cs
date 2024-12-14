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
        if (SceneManager.GetActiveScene().name == "Q2_ChickenFight")
        {
            SceneManager.LoadScene("Q2_ChickenFight");
        }
    }

    public void DeclineButton()
    {
        confirmationPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}