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
        Debug.Log(enemiesKilled);
        UpdateText();

        if (SceneManager.GetActiveScene().name == "Quest2" && enemiesKilled >= 5)
        {
            SceneManager.LoadScene("Quest3");
        }
    }

    private void UpdateText()
    {
        if (SceneManager.GetActiveScene().name == "Quest2")
            text.text = enemiesKilled.ToString() + "/5";
        
        Debug.Log("UpdateText");
    }
}