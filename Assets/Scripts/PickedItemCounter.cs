using UnityEngine;
using TMPro;

public class PickedItemCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private HPBar enemyHPBar;
    [SerializeField] private EnemySpawner enemySpawner;

    public void UpdateText(int skullCount)
    {
        text.text = skullCount.ToString() + "/4";

        if (skullCount == 4)
        {
            text.text = "Defeat The Giant Skeleton";
            enemySpawner.Activate();
        }
    }
}