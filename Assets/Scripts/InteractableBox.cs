using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableBox : MonoBehaviour
{
    public Transform boxCenter;
    public Vector2 boxSize;
    private bool isDialogueActive1 = false;

    // ----------------------------------------------------

    public DialogueTrigger dialogueTriggerMilo;
    public DialogueTrigger dialogueTriggerKyu;
    public DialogueTrigger dialogueTriggerLisa;

    // ----------------------------------------------------

    // Quest 1
    public GameObject miloDialogueMarkQ1;
    public GameObject kyuDialogueMarkQ1;

    // Quest 2
    public GameObject lisaDialogueMarkQ2;
    public GameObject miloDialogueMarkQ2;

    // ----------------------------------------------------

    // Quest 1
    public bool miloq1 = false;
    public bool q1d1d2DialogueDone = false;
    public bool q1d3DialogueDone = false;

    // Quest 2
    public bool lisaq2 = false;
    public bool q2d1DialogueDone = false;
    public bool q2d2d3DialogueDone = false;

    // ----------------------------------------------------

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = boxCenter == null ? Vector3.zero : boxCenter.position;
        Gizmos.DrawWireCube(position, new Vector3(boxSize.x, boxSize.y, 0f));
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Q1_D1_D2")
        {
            miloDialogueMarkQ1.SetActive(true);
            kyuDialogueMarkQ1.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Q1_D3")
        {
            miloDialogueMarkQ1.SetActive(false);
            kyuDialogueMarkQ1.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "Q2_D1")
        {
            lisaDialogueMarkQ2.SetActive(true);
            miloDialogueMarkQ2.SetActive(false);
        }
    }

    private void Update()
    {
        // Check for mouse hover
        DetectHoveredCollider();
        //DetectColliders();
    }

    public void DetectColliders()
    {
        Vector2 boxCenterPosition = boxCenter == null ? transform.position : boxCenter.position;
        foreach (Collider2D collider in Physics2D.OverlapBoxAll(boxCenterPosition, boxSize, 0f))
        {
            // Q1_D1_D2

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Milo" && Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().name == "Q1_D1_D2")
            {
                miloq1 = true;
                kyuDialogueMarkQ1.SetActive(true);

                if (miloDialogueMarkQ1.activeSelf)
                {
                    dialogueTriggerMilo.TriggerDialogue();
                }
            }

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Kyu" && Input.GetKeyDown(KeyCode.F) && miloq1 && SceneManager.GetActiveScene().name == "Q1_D1_D2")
            {                
                if (kyuDialogueMarkQ1.activeSelf)
                {
                    dialogueTriggerKyu.TriggerDialogue();
                }

                q1d1d2DialogueDone = true;
            }

            // Q1_D3    

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Kyu" && Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().name == "Q1_D3")
            {                
                if (kyuDialogueMarkQ1.activeSelf)
                {
                    dialogueTriggerKyu.TriggerDialogue();
                }

                q1d3DialogueDone = true;
            }

            // Q2_D1

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Lisa" && Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().name == "Q2_D1")
            {
                if (lisaDialogueMarkQ2.activeSelf)
                {
                    dialogueTriggerLisa.TriggerDialogue();
                }

                q2d1DialogueDone = true;
            }

            // Q2_D2_D3

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Lisa" && Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().name == "Q2_D2_D3")
            {
                lisaq2 = true;
                miloDialogueMarkQ2.SetActive(true);

                if (lisaDialogueMarkQ2.activeSelf)
                {
                    dialogueTriggerLisa.TriggerDialogue();
                }

            }

            if (collider.gameObject.tag == "InteractableNPC" && collider.name == "Milo" && Input.GetKeyDown(KeyCode.F) && lisaq2 && SceneManager.GetActiveScene().name == "Q2_D2_D3")
            {
                if (miloDialogueMarkQ2.activeSelf)
                {
                    dialogueTriggerMilo.TriggerDialogue();
                }

                q2d2d3DialogueDone = true;
            }
        }
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
        
        if (SceneManager.GetActiveScene().name == "Q1_D1_D2" || SceneManager.GetActiveScene().name == "Q1_D3" || SceneManager.GetActiveScene().name == "Q2_D1")
        {
            isDialogueActive1 = dialogueTriggerMilo.IsDialogueActive() ||
                                    dialogueTriggerKyu.IsDialogueActive() ||
                                    dialogueTriggerLisa.IsDialogueActive();
            
            if (!isDialogueActive1) 
            {
                dialogueTriggerMilo.interactPanel.SetActive(isHovering);
            }
        }
    }
}