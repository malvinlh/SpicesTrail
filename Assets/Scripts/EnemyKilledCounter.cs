using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyKilledCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int enemiesKilled = 0;

    private void Start()
    {
        UpdateText();
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateText();

        if (SceneManager.GetActiveScene().name == "Q1_5Bahan" && enemiesKilled >= 5)
        {
            SceneManager.LoadScene("Q1_D3");
        }
    }

    private void UpdateText()
    {
        if (SceneManager.GetActiveScene().name == "Q1_5Bahan")
            text.text = enemiesKilled.ToString() + "/5";        
    }
}