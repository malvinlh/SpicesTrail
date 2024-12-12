using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public AudioSource clickSFX;
    public AudioSource MainMenuBGM;

    public void PlayGame()
    {
        MainMenuBGM.Stop();        
        clickSFX.Play();
        SceneManager.LoadScene("Quest1");
    }

    public void QuitGame()
    {
        //Debug.Log("Exit!");
        clickSFX.Play();
        Application.Quit();
    }

    public void PlaySFX()
    {
        clickSFX.Play();
    }
}