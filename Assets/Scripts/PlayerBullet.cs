using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public int bulletDamage;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = UtilityFunctions.GetMouseWorldPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target) < 0.1f)
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "EnemyWI6" || collision.gameObject.tag == "EnemyWI4" || collision.gameObject.tag == "EnemyT2" || collision.gameObject.tag == "EnemyGS" || collision.gameObject.tag == "BossGS" || collision.gameObject.tag == "EnemyD" || collision.gameObject.tag == "EnemyRH")
        {     
            Health enemyHealth = collision.gameObject.GetComponent<Health>();       
            if (enemyHealth != null)
            {
                // Get the HPBar component attached to the enemy's GameObject
                HPBar enemyHPBar = collision.gameObject.GetComponent<HPBar>();
                if (enemyHPBar != null)
                {
                    enemyHealth.GetHit(bulletDamage, gameObject, enemyHPBar); // Pass the enemy HP bar reference
                }
            }
            DestroyBullet();
        }
    }
}