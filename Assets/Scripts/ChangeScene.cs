using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

    public List<GameObject> gameObjectsToDestroy;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "WhalerIsland4")
        {
            if (AreGameObjectsDestroyed())
            {
                ChangeSceneManually();
            }
        }
        
        if (changeTime > 0)
        {
            changeTime -= Time.deltaTime;
            if (changeTime <= 0)
            {
                ChangeSceneManually();
            }
        }
    }

    // Check if all game objects in the list are destroyed
    private bool AreGameObjectsDestroyed()
    {
        foreach (GameObject obj in gameObjectsToDestroy)
        {
            if (obj != null)
                return false;
        }
        return true;
    }

    // Function to change the scene
    public void ChangeSceneManually()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneWithSFX()
    {
        audioManager.ClickSFXPlay();
        SceneManager.LoadScene(sceneName);
    }
}