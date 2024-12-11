using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public GameObject dialogueBox;
    public DialogueTrigger dialogueTrigger;

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public string dialogue;
    }

    public List<DialogueLine> dialogueLines = new List<DialogueLine>();

    public void AddDialogueLine(string speakerName, string dialogue)
    {
        DialogueLine newLine = new DialogueLine
        {
            speakerName = speakerName,
            dialogue = dialogue
        };
        dialogueLines.Add(newLine);
    }

    public DialogueLine GetDialogueLine(int index)
    {
        if (index >= 0 && index < dialogueLines.Count)
        {
            return dialogueLines[index];
        }
        else
        {
            dialogueBox.SetActive(false);
            dialogueTrigger.EndDialogue();
            return null;
        }
    }
}