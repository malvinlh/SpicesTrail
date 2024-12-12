using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableBox : MonoBehaviour
{
    public GameObject dialoguePanel;

    public Transform boxCenter;
    public Vector2 boxSize;
    public DialogueTrigger dialogueTriggerMilo;
    public DialogueTrigger dialogueTriggerKyu;
    public DialogueTrigger dialogueTriggerLisa;

    public DialogueTrigger dialogueTriggerSign;
    public DialogueTrigger dialogueTriggerLake1;
    public DialogueTrigger dialogueTriggerLake2;
    public DialogueTrigger dialogueTriggerStatue1;
    public DialogueTrigger dialogueTriggerStatue2;
    public DialogueTrigger dialogueTriggerSkeleton;
    public DialogueTrigger dialogueTriggerChest;
    public DialogueTrigger dialogueTriggerCrow1;
    public DialogueTrigger dialogueTriggerCrow2;
    public DialogueTrigger dialogueTriggerGhost;

    public bool skeleton = false;
    public bool chest = false;
    public bool statue = false;
    public bool crow = false;
    public bool lake = false;

    public GameObject lake1;
    public GameObject statue1;
    public GameObject crow1;

    [SerializeField]
    private GameObject chestObject;

    public GameObject fishingRod;

    private bool isDialogueActive1 = false;
    private bool isDialogueActive2 = false;

    // Quest 1
    public GameObject miloDialogueMarkQ1;
    public GameObject kyuDialogueMarkQ1;

    // Quest 1
    public bool miloq1 = false;
    public bool kyuq1 = false;
    public bool q1DialogueDone = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = boxCenter == null ? Vector3.zero : boxCenter.position;
        Gizmos.DrawWireCube(position, new Vector3(boxSize.x, boxSize.y, 0f));
    }

    private void Update()
    {
        // Check for mouse hover
        DetectHoveredCollider();
    }

    public void DetectColliders()
    {
        Vector2 boxCenterPosition = boxCenter == null ? transform.position : boxCenter.position;
        foreach (Collider2D collider in Physics2D.OverlapBoxAll(boxCenterPosition, boxSize, 0f))
        {
            dialoguePanel.SetActive(true);

            // Quest 1

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Milo" && Input.GetKeyDown(KeyCode.F))
            {
                miloq1 = true;
                kyuq1 = true;
                kyuDialogueMarkQ1.SetActive(true);
                
                if (miloDialogueMarkQ1.activeSelf)
                {
                    dialogueTriggerMilo.TriggerDialogue();
                }
            }

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Kyu" && Input.GetKeyDown(KeyCode.F) && miloq1)
            {                
                if (kyuDialogueMarkQ1.activeSelf)
                {
                    dialogueTriggerKyu.TriggerDialogue();
                }

                q1DialogueDone = true;
            }

            // Quest 3

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Lisa" && Input.GetKeyDown(KeyCode.F))
            {
                GameObject lisaDialogueMark = GameObject.Find("LisaDialogueMark");
                
                if (lisaDialogueMark.activeSelf)
                {
                    dialogueTriggerLisa.TriggerDialogue();
                }
            }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "Sign" && Input.GetKeyDown(KeyCode.F))
            // {
            //     GameObject signDialogueMark = GameObject.Find("SignDialogueMark");
                
            //     if (signDialogueMark.activeSelf)
            //     {
            //         dialogueTriggerSign.TriggerDialogue();
            //     }
            // }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "Skeleton" && Input.GetKeyDown(KeyCode.F))
            // {
            //     skeleton = true; // udah bicara ke skeleton
            //     dialogueTriggerSkeleton.TriggerDialogue(); // bicara ke skeleton, ga urusin index
            //     fishingRod.SetActive(false);
            // }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "Lake1" && !skeleton && Input.GetKeyDown(KeyCode.F))
            // {
            //     lake = false; // maka false karena dia belum dapet ikan.
            //     dialogueTriggerLake1.TriggerDialogue(); // nampilin indeks 0 aja.
            // }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "Lake2" && skeleton && Input.GetKeyDown(KeyCode.F))
            // {
            //     lake1.SetActive(false);
            //     lake = true; // maka false karena dia belum dapet ikan.
            //     dialogueTriggerLake2.TriggerDialogue(); // nampilin indeks 0 aja.
            // }            

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "CrowOnTopOfStone1" && !lake && Input.GetKeyDown(KeyCode.F))
            // {
            //     crow = false; // false karena belum dapet mata
            //     dialogueTriggerCrow1.TriggerDialogue(); // nampilin indeks 0 aja
            // }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "CrowOnTopOfStone2" && lake && Input.GetKeyDown(KeyCode.F))
            // {
            //     crow1.SetActive(false);
            //     crow = true; // false karena belum dapet mata
            //     dialogueTriggerCrow2.TriggerDialogue(); // nampilin indeks 0 aja
            // }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "Statue1" && !crow && Input.GetKeyDown(KeyCode.F))
            // {
            //     statue = false; // false karena belum tekan tombol
            //     dialogueTriggerStatue1.TriggerDialogue();
            // }

            // if (collider.gameObject.tag == "InteractableObject" && collider.name == "Statue2" && crow && Input.GetKeyDown(KeyCode.F))
            // {
            //     statue1.SetActive(false);
            //     statue = true; // false karena belum tekan tombol
            //     dialogueTriggerStatue2.TriggerDialogue();
                
            //     if (chestObject != null)
            //         chestObject.SetActive(true);
            // }

            // if (chestObject.gameObject.activeSelf && collider.gameObject.tag == "InteractableObject" && collider.name == "Chest" && Input.GetKeyDown(KeyCode.F))
            // {
            //     chest = true;
            //     dialogueTriggerChest.TriggerDialogue();
            // }

            // if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Ghost" && Input.GetKeyDown(KeyCode.F))
            // {
            //     GameObject ghostDialogueMark = GameObject.Find("GhostDialogueMark");
                
            //     if (ghostDialogueMark.activeSelf)
            //     {
            //         dialogueTriggerGhost.TriggerDialogue();
            //     }
            // }
        }

        dialoguePanel.SetActive(false);
    }

    private void DetectHoveredCollider()
    {
        Vector2 boxCenterPosition = boxCenter == null ? transform.position : boxCenter.position;
        bool isHovering = false;

        foreach (Collider2D collider in Physics2D.OverlapBoxAll(boxCenterPosition, boxSize, 0f))
        {
            if (collider.CompareTag("Player"))
            {
                isHovering = false;
            }

            if (collider.CompareTag("InteractableNPC"))
            {
                float distance = Vector2.Distance(collider.bounds.center, boxCenterPosition);

                if (distance <= Mathf.Max(boxSize.x, boxSize.y))
                {
                    isHovering = true;
                    break;
                }
            }
            
            if (collider.CompareTag("InteractableObject"))
            {
                float distance = Vector2.Distance(collider.bounds.center, boxCenterPosition);

                if (distance <= Mathf.Max(boxSize.x, boxSize.y))
                {
                    isHovering = true;
                    break;
                }
            }
        }

        // Check if any dialogue trigger is active
        
        if (SceneManager.GetActiveScene().name == "WhalerIsland2")
        {
            isDialogueActive1 = dialogueTriggerMilo.IsDialogueActive() ||
                                    dialogueTriggerSign.IsDialogueActive() ||
                                    dialogueTriggerLake1.IsDialogueActive() ||
                                    dialogueTriggerLake2.IsDialogueActive() ||
                                    dialogueTriggerStatue1.IsDialogueActive() ||
                                    dialogueTriggerStatue2.IsDialogueActive() ||
                                    dialogueTriggerSkeleton.IsDialogueActive() ||
                                    dialogueTriggerChest.IsDialogueActive() ||
                                    dialogueTriggerCrow1.IsDialogueActive() ||
                                    dialogueTriggerCrow2.IsDialogueActive();
            
            if (!isDialogueActive1) 
            {
                dialogueTriggerMilo.interactPanel.SetActive(isHovering);
            }
        }

        if (SceneManager.GetActiveScene().name == "SkullIsland2" || SceneManager.GetActiveScene().name == "SkullIsland3" || SceneManager.GetActiveScene().name == "SkullIsland4")
        {
            isDialogueActive2 = dialogueTriggerGhost.IsDialogueActive();
            if (!isDialogueActive2)
            {
                dialogueTriggerGhost.interactPanel.SetActive(isHovering);
            }
        }
    }
}