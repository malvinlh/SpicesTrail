using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class Health : MonoBehaviour
{
    public int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    public bool isDead = false;
    public TextMeshProUGUI text;

    private HPBar playerHPBar;
    private HPBar enemyHPBar;

    [SerializeField] private GameOver gameOver;
    [SerializeField] private WinPanel winPanel;
    [SerializeField] private GameObject teleporterSkeletonOff;
    [SerializeField] private GameObject teleporterSkeletonOn;
    [SerializeField] private EnemyKilledCounter enemyKilledCounter;

    private void Start()
    {
        playerHPBar = GetComponent<HPBar>();
        enemyHPBar = GetComponent<HPBar>();
    }

    public void InitializeHealth(int health)
    {
        currentHealth = health;
        maxHealth = health;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender, HPBar enemyHPBar)
    {
        float floatAmount = (float)amount / 100;

        if (isDead)
            return;
        if (sender.layer == gameObject.layer) // jika layer player
            return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            isDead = true;
            OnDeathWithReference?.Invoke(sender);
            if (SceneManager.GetActiveScene().name == "RegentsHaven4")
                winPanel.WonPanel();
            else
                HandleDeathEnemy(); // Call HandleDeathEnemy method on enemy death
        }

        if (enemyHPBar.health.transform.localScale.x > 0f)
            enemyHPBar.SetHP(enemyHPBar.health.transform.localScale.x - floatAmount);
    }

    public void PlayerGetHit(int amount, GameObject sender)
    {
        float floatAmount = (float)amount / 100;

        if (isDead)
            return;
        if (sender.layer == gameObject.layer) // jika layer enemy
            return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            isDead = true;
            OnDeathWithReference?.Invoke(sender);

            if (SceneManager.GetActiveScene().name == "WhalerIsland4" || SceneManager.GetActiveScene().name == "GiantSkeletonDungeon" || SceneManager.GetActiveScene().name == "DemonDungeon" || SceneManager.GetActiveScene().name == "RegentsHaven2" || SceneManager.GetActiveScene().name == "RegentsHaven4")
                gameOver.GameOverPanel();
            else
                HandleDeathPlayer();
        }

        if (playerHPBar.health.transform.localScale.x > 0f)
            playerHPBar.SetHP(playerHPBar.health.transform.localScale.x - floatAmount);
    }

    private void HandleDeathPlayer()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial2")
        {
            SceneManager.LoadScene("Tutorial3");
        }
        if (SceneManager.GetActiveScene().name == "WhalerIsland6")
        {
            SceneManager.LoadScene("WhalerIsland7");
        }

        Destroy(gameObject);    
    }

    private void HandleDeathEnemy()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial2")
        {
            SceneManager.LoadScene("Tutorial3");
        }
        if (SceneManager.GetActiveScene().name == "WhalerIsland6")
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (SceneManager.GetActiveScene().name == "GiantSkeletonDungeon" && gameObject.CompareTag("BossGS"))
        {
            teleporterSkeletonOn.SetActive(true);
            teleporterSkeletonOff.SetActive(false);
            text.text = "Return to your spawn point.";
        }

        if (SceneManager.GetActiveScene().name == "DemonDungeon" && gameObject.CompareTag("EnemyD"))
        {
            enemyKilledCounter.EnemyKilled();
        }

        if (SceneManager.GetActiveScene().name == "RegentsHaven2" && gameObject.CompareTag("EnemyRH"))
        {
            enemyKilledCounter.EnemyKilled();
        }

        Destroy(gameObject);   
    }
}