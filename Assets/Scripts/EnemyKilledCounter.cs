using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyKilledCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TilemapRandomSpawner enemySpawner;
    [SerializeField] private GameObject teleporterDemonOn;
    [SerializeField] private GameObject teleporterDemonOff;

    private int enemiesKilled = 0;

    private void Start()
    {
        UpdateText();
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateText();

        if (SceneManager.GetActiveScene().name == "DemonDungeon" && enemiesKilled >= 3)
        {
            text.text = "Return to your spawn point.";
            teleporterDemonOn.SetActive(true);
            teleporterDemonOff.SetActive(false);
        }
        
        if (SceneManager.GetActiveScene().name == "RegentsHaven2" && enemiesKilled >= 50)
        {
            SceneManager.LoadScene("RegentsHaven3");
        }
    }

    private void UpdateText()
    {
        if (SceneManager.GetActiveScene().name == "DemonDungeon")
            text.text = enemiesKilled.ToString() + "/3";
        else if (SceneManager.GetActiveScene().name == "RegentsHaven2")
            text.text = enemiesKilled.ToString() + "/50";
    }
}