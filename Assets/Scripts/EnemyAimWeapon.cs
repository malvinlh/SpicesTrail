using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimWeapon : MonoBehaviour
{
    public List<Transform> aimTargets = new List<Transform>(); // Change to a list of Transform
    private Transform aimTransform;
    public SpriteRenderer characterRenderer, weaponRenderer;

    private EnemyMovement enemyMovement;
    private EnemyMelee enemyMelee;
    private EnemyShoot enemyShoot;

    public Transform currentTarget;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        if (gameObject.CompareTag("Enemy"))
        {
            aimTransform = transform.Find("EnemyAim");
        }

        enemyMelee = GetComponentInChildren<EnemyMelee>();
        enemyShoot = GetComponentInChildren<EnemyShoot>();
    }

    private void FixedUpdate()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        if (currentTarget != null && currentTarget.gameObject != null)
        {
            Vector3 aimDirection = (currentTarget.position - aimTransform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);

            Vector3 localScale = Vector3.one;
            if (angle > 90 || angle < -90)
            {
                localScale.y = -1f;
            }
            else
            {
                localScale.y = +1f;
            }

            aimTransform.localScale = localScale;

            if (aimTransform.eulerAngles.z > 0 && aimTransform.eulerAngles.z < 180)
            {
                weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
            }
            else
            {
                weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
            }
        }
        else
        {
            // Handle the case where currentTarget is null or destroyed
            // For example, you might want to reset the aiming or do nothing
        }
    }

    public void HandleAttack()
    {
        if (currentTarget != null && currentTarget.gameObject != null)
        {
            // Loop through all aim targets
            foreach (Transform target in aimTargets)
            {
                if (target == null || target.gameObject == null)
                {
                    // Target is destroyed, skip processing
                    continue;
                }

                // Check if target is within range and perform attack
                if (enemyMovement.macheteSprite.activeSelf && Vector2.Distance(transform.position, target.position) <= enemyMovement.meleeRangeDistance)
                {
                    enemyMelee.StartAttackingWithDelay();
                }

                if (enemyMovement.pistolSprite.activeSelf && Vector2.Distance(transform.position, target.position) <= enemyMovement.shootingRangeDistance)
                {
                    enemyShoot.StartShootCoroutine();
                }
            }
        }
        else
        {
            // Handle the case where currentTarget is null or destroyed
            // For example, you might want to reset the aiming or do nothing
        }
    }

    public void EquipMachete()
    {
        enemyMelee = GetComponentInChildren<EnemyMelee>();
    }

    public void EquipPistol()
    {
        enemyShoot = GetComponentInChildren<EnemyShoot>();
    }

    // Method to update the aimTargets list
    public void UpdateAimTargets(List<Transform> newTargets)
    {
        aimTargets.Clear();
        aimTargets.AddRange(newTargets);
    }
}