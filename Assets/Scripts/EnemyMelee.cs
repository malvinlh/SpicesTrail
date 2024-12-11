using System.Collections;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private Animator macheteAnimator;
    [SerializeField] private Animator enemyAnimator;
    private bool isAttacking = false; // Flag to track if the enemy is currently attacking
    private Coroutine attackCoroutine; // Coroutine reference
    public Transform boxCenter;
    public Vector2 boxSize;
    public float attackDelay; // Delay between attacks
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

        // Check if the player is within range
        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCenter.position, boxSize, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("PlayerT2")) // Tutorial 2
            {
                macheteAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
                }
            }

            if (collider.CompareTag("PlayerWI4")) // Whaler Island 4
            {
                enemyAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
                }
            }

            if (collider.CompareTag("PlayerWI6")) // Whaler Island 6
            {
                enemyAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
                }
            }

            if (collider.CompareTag("PlayerGS")) // Giant Skeleton
            {
                enemyAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
                }
            }

           if (collider.CompareTag("PlayerD")) // Demon
            {
                enemyAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
                }
            }

           if (collider.CompareTag("PlayerRH")) // Regent's Haven
            {
                enemyAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
                }
            }

            if (collider.CompareTag("Ally")) // Whaler Island 4
            {
                enemyAnimator.SetTrigger("Attack");
                Health allyHealth = collider.gameObject.GetComponent<Health>();       
                if (allyHealth != null)
                {
                    HPBar allyHPBar = collider.gameObject.GetComponent<HPBar>();
                    if (allyHPBar != null)
                    {
                        allyHealth.GetHit(meleeDamage, gameObject, allyHPBar);
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
        StartAttackingWithDelay(); // Restart attacking when enabled
    }
}