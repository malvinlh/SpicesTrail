using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Button closeButton;
    private AudioManager audioManager;
    //public DialogueTrigger dialogueTrigger;
    //public List<GameObject> gameObjectsToToggle = new List<GameObject>();

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        closeButton.onClick.AddListener(DeactivateTutorialPanel);
    }

    public void DeactivateTutorialPanel()
    {
        audioManager.ClickSFXPlay();
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}