using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int bulletDamage;
    private EnemyAI enemyAI;
    private Vector2 targetPosition; // Define targetPosition as a class-level variable

    void Awake()
    {
        enemyAI = GameObject.Find("EnemyRanged").GetComponent<EnemyAI>();
        if (enemyAI.currentTarget != null)
        {
            targetPosition = new Vector2(enemyAI.currentTarget.position.x, enemyAI.currentTarget.position.y);
        }
    }

    private void Update()
    {
        // Update the bullet's position only if there's a target
        if (enemyAI.currentTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the bullet has reached the target position
            if ((Vector2)transform.position == targetPosition)
            {
                DestroyBullet();
            }
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if (collision.gameObject.CompareTag("PlayerT2")) // Tutorial 2
        {            
            if (playerHealth != null)
            {
                playerHealth.PlayerGetHit(bulletDamage, gameObject); // Health berkurang 20
            }
            DestroyBullet();
        }
    }
}