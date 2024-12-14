using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    private DialogueText dialogueTextScript;
    public int currentIndex = 0;
    public InteractableBox interactableBox;
    [SerializeField] private ChangeScene changeScene;

    public void GetScript()
    {
        dialogueTextScript = GetComponentInChildren<DialogueText>();
        LoadNextText();
    }

    public void OnDisable()
    {
        currentIndex = 0;
        dialogueBox.SetActive(false);
    }

    public void LoadNextText()
    {
        DialogueText.DialogueLine nextLine = dialogueTextScript.GetDialogueLine(currentIndex);
        if (nextLine != null)
        {
            speakerNameText.text = nextLine.speakerName;
            dialogueText.text = nextLine.dialogue;
            currentIndex++;
        }
    }
}