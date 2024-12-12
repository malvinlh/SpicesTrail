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

    //public GameObject macheteSprite;
    private void Awake()
    {
        //macheteSprite.SetActive(false);
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
            if (collider.CompareTag("Player")) // Chicken fight
            {
                macheteAnimator.SetTrigger("Attack");
                Health playerHealth = collider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.PlayerGetHit(meleeDamage, gameObject);
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