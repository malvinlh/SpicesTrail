using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyAI : MonoBehaviour
{
    public Transform currentTarget;
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private AllyAimWeapon aimWeapon;

    // List to store potential targets
    public List<Transform> potentialTargets = new List<Transform>();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();

        // Choose initial target randomly
        FindNewTarget();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            // Set destination to the current target's position
            agent.SetDestination(currentTarget.position);
            AnimatorDirection();
        }
        else
        {
            // If current target is null, find a new target
            FindNewTarget();

            if (potentialTargets.Count == 0)
            {
                animator.SetFloat("XInput", 0f);
                animator.SetFloat("YInput", 0f);
            }
        }
    }

    // Method to add a target to the potential targets list
    public void AddPotentialTarget(Transform target)
    {
        if (!potentialTargets.Contains(target))
        {
            potentialTargets.Add(target);
        }
    }

    // Method to remove a target from the potential targets list
    public void RemovePotentialTarget(Transform target)
    {
        if (potentialTargets.Contains(target))
        {
            potentialTargets.Remove(target);
        }
    }

    // Find a new target if the current one is null
    void FindNewTarget()
    {
        // If there are potential targets, choose one randomly
        if (potentialTargets.Count > 0)
        {
            int randomIndex = Random.Range(0, potentialTargets.Count);
            currentTarget = potentialTargets[randomIndex];
            aimWeapon.currentTarget = currentTarget;
        }
        else
        {
            currentTarget = null;
        }
    }

    // Method to update animator direction
    void AnimatorDirection()
    {
        if (currentTarget != null)
        {
            Vector3 direction = currentTarget.position - transform.position;
            direction.Normalize();
            animator.SetFloat("XInput", direction.x);
            animator.SetFloat("YInput", direction.y);
        }
    }
}