using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    EnemyAI enemyAI;
    EnemyAimWeapon aimWeapon;
    Animator animator;
    [SerializeField] public GameObject macheteSprite, pistolSprite;
    [SerializeField] private GameObject macheteHitbox;

    public float detectionRangeDistance;
    public float meleeRangeDistance;
    public float shootingRangeDistance;

    bool inMeleeRange = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyAI = GetComponent<EnemyAI>();
        aimWeapon = GetComponent<EnemyAimWeapon>();
    }

    void FixedUpdate()
    {
        // Create a list to store targets to be removed
        List<Transform> targetsToRemove = new List<Transform>();

        // Check if player or ally is within detection range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRangeDistance);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                animator.SetBool("isMoving", true);
                enemyAI.AddPotentialTarget(collider.transform);
            }
        }

        // Update aim targets in EnemyAimWeapon
        aimWeapon.UpdateAimTargets(enemyAI.potentialTargets);

        // Check if any potential targets are out of range and remove them
        foreach (Transform target in enemyAI.potentialTargets)
        {
            // Check if target is null or destroyed
            if (target == null || !target.gameObject.activeSelf)
            {
                targetsToRemove.Add(target);
                continue; // Skip processing this target
            }

            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget > detectionRangeDistance)
            {
                // Add the target to the list to be removed
                targetsToRemove.Add(target);
            }
        }

        // Remove targets that are out of range
        foreach (Transform targetToRemove in targetsToRemove)
        {
            enemyAI.RemovePotentialTarget(targetToRemove);
        }

        // Check if player is within melee range
        inMeleeRange = Physics2D.OverlapCircle(transform.position, meleeRangeDistance, LayerMask.GetMask("Player"));

        // Check if player is within shooting range
        bool inShootingRange = Physics2D.OverlapCircle(transform.position, shootingRangeDistance, LayerMask.GetMask("Player"));

        // Handle weapon and attack based on range
        if (inMeleeRange)
        {
            macheteSprite.SetActive(true);
            pistolSprite.SetActive(false);
            macheteHitbox.SetActive(true);
            aimWeapon.EquipMachete();
            aimWeapon.HandleAttack();
        }
        else if (inShootingRange)
        {
            macheteSprite.SetActive(false);
            pistolSprite.SetActive(true);
            macheteHitbox.SetActive(false);
            aimWeapon.EquipPistol();
            aimWeapon.HandleAttack();
        }
        else
        {
            macheteSprite.SetActive(true);
            pistolSprite.SetActive(false);
            macheteHitbox.SetActive(false);
            aimWeapon.EquipMachete();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRangeDistance);

        // Draw melee range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRangeDistance);

        // Draw shooting range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRangeDistance);
    }
}