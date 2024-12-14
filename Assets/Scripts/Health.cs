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
            // bikin lanjut scene aja
            if (SceneManager.GetActiveScene().name == "Q2_ChickenFight")
                UnityEngine.SceneManagement.SceneManager.LoadScene("Q2_D2_D3");
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

            if (SceneManager.GetActiveScene().name == "Q2_ChickenFight")
                gameOver.GameOverPanel();
        }

        if (playerHPBar.health.transform.localScale.x > 0f)
            playerHPBar.SetHP(playerHPBar.health.transform.localScale.x - floatAmount);
    }

    // private void HandleDeathPlayer()
    // {
    //     if (SceneManager.GetActiveScene().name == "Q2_ChickenFight")
    //     {
    //         SceneManager.LoadScene("GameOver");
    //     }
    //     {
    //         SceneManager.LoadScene("Tutorial3");
    //     }
    //     if (SceneManager.GetActiveScene().name == "WhalerIsland6")
    //     {
    //         SceneManager.LoadScene("WhalerIsland7");
    //     }

    //     Destroy(gameObject);    
    // }

    private void HandleDeathEnemy()
    {
        if (SceneManager.GetActiveScene().name == "Q1_5Bahan")
        {
            string[] enemyNames = { "Sawi", "KembangTuri", "KacangPanjang", "Tauge", "Timun" };
            foreach (string enemyName in enemyNames)
            {
                GameObject enemy = GameObject.Find(enemyName);
                if (enemy == gameObject)
                {
                    enemyKilledCounter.EnemyKilled();
                    break;
                }
            }
        }

        Destroy(gameObject);   
    }
}