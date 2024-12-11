using UnityEngine;
using UnityEngine.Tilemaps;

public class PickItem : MonoBehaviour
{
    private static int totalSkullCount = 0; // Static variable to keep track of total collected skulls

    [SerializeField] private GameObject skull;
    [SerializeField] private PickedItemCounter pickedItemCounter; // Reference to the TextUpdater script

    private GameObject skullAltar1;
    private GameObject skullAltar2;
    private GameObject skullAltar3;
    private GameObject skullAltar4;

    void Awake()
    {
        pickedItemCounter = FindObjectOfType<PickedItemCounter>(); // Find the TextUpdater script in the scene

        skullAltar1 = GameObject.Find("Skull1");
        skullAltar2 = GameObject.Find("Skull2");
        skullAltar3 = GameObject.Find("Skull3");
        skullAltar4 = GameObject.Find("Skull4");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerGS"))
        {
            if (gameObject.CompareTag("PickableObject"))
            {
                if (totalSkullCount < 4) // Check if the total skull count is less than the number of skull altars
                {
                    ActivateSkullAltarComponents(totalSkullCount);
                }

                    skull.SetActive(false);
                    totalSkullCount++; // Increment the total skull count
                    pickedItemCounter.UpdateText(totalSkullCount); // Update the text using TextUpdater
            }
        }
    }

    private void ActivateSkullAltarComponents(int index)
    {
        switch (index)
        {
            case 0:
                ActivateSkullAltar(skullAltar1);
                break;
            case 1:
                ActivateSkullAltar(skullAltar2);
                break;
            case 2:
                ActivateSkullAltar(skullAltar3);
                break;
            case 3:
                ActivateSkullAltar(skullAltar4);
                break;
            default:
                break;
        }
    }

    private void ActivateSkullAltar(GameObject skullAltar)
    {
        var renderer = skullAltar.GetComponent<TilemapRenderer>();
        if (renderer != null)
            renderer.enabled = true;

        var collider2D = skullAltar.GetComponent<Collider2D>();
        if (collider2D != null)
            collider2D.enabled = true;
    }
}