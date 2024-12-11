using UnityEngine;
using System.Collections.Generic;

public class AllyMovement : MonoBehaviour
{
    AllyAI allyAI;
    AllyAimWeapon aimWeapon;
    Animator animator;
    [SerializeField] public GameObject macheteSprite;
    [SerializeField] private GameObject macheteHitbox;

    public float detectionRangeDistance;
    public float meleeRangeDistance;

    bool inMeleeRange = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        allyAI = GetComponent<AllyAI>();
        aimWeapon = GetComponent<AllyAimWeapon>();
    }

    void Update()
    {
        List<Transform> targetsToRemove = new List<Transform>();

        // Check if enemy is within detection range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRangeDistance);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("EnemyWI4"))
            {
                animator.SetBool("isMoving", true);
                allyAI.AddPotentialTarget(collider.transform);
            }
        }

        aimWeapon.UpdateAimTargets(allyAI.potentialTargets);

        // Check if any potential targets are out of range and remove them
        foreach (Transform target in allyAI.potentialTargets)
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
            allyAI.RemovePotentialTarget(targetToRemove);
        }

        inMeleeRange = Physics2D.OverlapCircle(transform.position, meleeRangeDistance, LayerMask.GetMask("Enemy"));

        if (inMeleeRange)
        {
            macheteSprite.SetActive(true);
            macheteHitbox.SetActive(true);
            aimWeapon.EquipMachete();
            aimWeapon.HandleAttack();
        }
        else
        {
            macheteSprite.SetActive(true);
            macheteHitbox.SetActive(false);
            aimWeapon.EquipMachete();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRangeDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRangeDistance);
    }
}