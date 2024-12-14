using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject interactPanel;
    public GameObject dialogueBox;
    public PlayerInput playerInput;
    public PlayerAimWeapon aimWeapon;

    public GameObject q1itemsAcquired;

    public InteractableBox interactableBox;

    public void Awake()
    {
        interactPanel.SetActive(false);
        dialogueBox.SetActive(false);
    }

    public void TriggerDialogue()
    {
        dialogueBox.SetActive(true);
        interactPanel.SetActive(false);
        dialogueBox.GetComponent<DialogueBox>().GetScript();

        // Disable player input
        playerInput.DeactivateInput();
        if (aimWeapon != null)
        {
            aimWeapon.ToggleInputHandling(false);
        }
    }

    public void EndDialogue()
    {
        playerInput.ActivateInput();
        aimWeapon.ToggleInputHandling(true);

        if(interactableBox.q1d1d2DialogueDone == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Q1_5Bahan");
        }

        if(interactableBox.q1d3DialogueDone == true)
        {
            q1itemsAcquired.SetActive(true);
        }

        if(interactableBox.q2d1DialogueDone == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Q2_ChickenFight");
        }

        if(interactableBox.q2d2d3DialogueDone == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cooking");
        }
    }

    public bool IsDialogueActive()
    {
        bool active = dialogueBox.activeSelf;
        return active;
    }

    public void LoadNextQ2Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Q2_D1");
    }
}