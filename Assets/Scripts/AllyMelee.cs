using System.Collections;
using UnityEngine;

public class AllyMelee : MonoBehaviour
{
    private Animator macheteAnimator;
    private bool isAttacking = false; // Flag to track if the enemy is currently attacking
    private Coroutine attackCoroutine;
    public Transform boxCenter;
    public Vector2 boxSize;
    public float attackDelay;
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

    public void StartAttackingWithDelay()
    {
        if (!isAttacking) // Only start attacking if not already attacking
        {
            attackCoroutine = StartCoroutine(AttackWithDelay());
        }
    }

    IEnumerator AttackWithDelay()
    {
        isAttacking = true; // Set the attacking flag to true

        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCenter.position, boxSize, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "EnemyWI4") //|| collider.gameObject.tag == "EnemyWI6") // Whaler Island 4
            {     
                macheteAnimator.SetTrigger("Attack");
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

        yield return new WaitForSeconds(attackDelay);
        isAttacking = false; // Reset the attacking flag
    }

    private void OnDisable()
    {
        if (attackCoroutine != null) // If coroutine is running
        {
            StopCoroutine(attackCoroutine); // Stop the coroutine
            attackCoroutine = null; // Reset the coroutine reference
            isAttacking = false; // Reset the attacking flag
        }
    }

    private void OnEnable()
    {
        StartAttackingWithDelay();
    }
}