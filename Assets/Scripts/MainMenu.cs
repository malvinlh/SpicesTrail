using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] private AudioManager audioManager;

    public void PlayGame()
    {
        audioManager.MainMenuBGMStop();
        audioManager.SeaWaveSFXStop();
        audioManager.ClickSFXPlay();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial1");
    }

    public void QuitGame()
    {
        //Debug.Log("Exit!");
        audioManager.ClickSFXPlay();
        Application.Quit();
    }
}