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
            if (collider.gameObject.tag == "Enemy") // Tutorial 2
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