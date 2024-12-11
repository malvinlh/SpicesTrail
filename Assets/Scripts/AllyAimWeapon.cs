using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAimWeapon : MonoBehaviour
{
    public List<Transform> aimTargets = new List<Transform>();
    private Transform aimTransform;
    public SpriteRenderer characterRenderer, weaponRenderer;

    private AllyMovement allyMovement;
    private AllyMelee allyMelee;

    public Transform currentTarget;

    private void Awake()
    {
        allyMovement = GetComponent<AllyMovement>();
        if (gameObject.CompareTag("Ally"))
        {
            aimTransform = transform.Find("AllyAim");
        }

        allyMelee = GetComponentInChildren<AllyMelee>();
    }

    private void Update()
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
                if (allyMovement.macheteSprite.activeSelf && Vector2.Distance(transform.position, target.position) <= allyMovement.meleeRangeDistance)
                {
                    allyMelee.StartAttackingWithDelay();
                }
            }
        }
    }
    
    public void EquipMachete()
    {
        allyMelee = GetComponentInChildren<AllyMelee>();
    }

    // Method to update the aimTargets list
    public void UpdateAimTargets(List<Transform> newTargets)
    {
        aimTargets.Clear();
        aimTargets.AddRange(newTargets);
    }
}