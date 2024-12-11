using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machete : MonoBehaviour
{
    private Animator macheteAnimator;
    public Transform boxCenter;
    public Vector2 boxSize;
    public int meleeDamage;

    private void Awake()
    {
        macheteAnimator = GetComponent<Animator>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = boxCenter == null ? Vector3.zero : boxCenter.position;
        Gizmos.DrawWireCube(position, new Vector3(boxSize.x, boxSize.y, 0f));
    }

    public void DetectColliders()
    {
        macheteAnimator.SetTrigger("Attack");
        Vector2 boxCenterPosition = boxCenter == null ? transform.position : boxCenter.position;
        foreach (Collider2D collider in Physics2D.OverlapBoxAll(boxCenterPosition, boxSize, 0f))
        {
            if (collider.gameObject.tag == "EnemyT2") // Tutorial 2
            {     
                Health enemyHealth = collider.gameObject.GetComponent<Health>();       
                if (enemyHealth != null)
                {
                    HPBar enemyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (enemyHPBar != null)
                    {
                        enemyHealth.GetHit(meleeDamage, gameObject, enemyHPBar);
                    }
                }
            }

            if (collider.gameObject.tag == "EnemyWI4") // Whaler Island 4
            {     
                Health enemyHealth = collider.gameObject.GetComponent<Health>();       
                if (enemyHealth != null)
                {
                    HPBar enemyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (enemyHPBar != null)
                    {
                        enemyHealth.GetHit(meleeDamage, gameObject, enemyHPBar);
                    }
                }
            }

            if (collider.gameObject.tag == "EnemyWI6") // Whaler Island 6
            {     
                Health enemyHealth = collider.gameObject.GetComponent<Health>();       
                if (enemyHealth != null)
                {
                    HPBar enemyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (enemyHPBar != null)
                    {
                        enemyHealth.GetHit(meleeDamage, gameObject, enemyHPBar);
                    }
                }
            }

            if (collider.gameObject.tag == "EnemyGS" || collider.gameObject.tag == "BossGS") // Giant Skeleton
            {     
                Health enemyHealth = collider.gameObject.GetComponent<Health>();       
                if (enemyHealth != null)
                {
                    HPBar enemyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (enemyHPBar != null)
                    {
                        enemyHealth.GetHit(meleeDamage, gameObject, enemyHPBar);
                    }
                }
            }

            if (collider.gameObject.tag == "EnemyD") // Demon
            {     
                Health enemyHealth = collider.gameObject.GetComponent<Health>();       
                if (enemyHealth != null)
                {
                    HPBar enemyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (enemyHPBar != null)
                    {
                        enemyHealth.GetHit(meleeDamage, gameObject, enemyHPBar);
                    }
                }
            }

            if (collider.gameObject.tag == "EnemyRH") // Whaler Island 6
            {     
                Health enemyHealth = collider.gameObject.GetComponent<Health>();       
                if (enemyHealth != null)
                {
                    HPBar enemyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (enemyHPBar != null)
                    {
                        enemyHealth.GetHit(meleeDamage, gameObject, enemyHPBar);
                    }
                }
            }
        }
    }
}