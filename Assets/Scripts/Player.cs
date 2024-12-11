using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.01f;
    public ContactFilter2D movementFilter;
    private PlayerAimWeapon aimWeapon;
    private ChangeWeapon changeWeapon;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        aimWeapon = GetComponent<PlayerAimWeapon>();
        changeWeapon = GetComponent<ChangeWeapon>();
    }

    public void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            AnimatorDirection();
            bool success = TryMove(movementInput);

            if (!success)
            {
                // Try to move on the X axis
                success = TryMove(new Vector2(movementInput.x, 0f));

                if (!success)
                {
                    // Try to move on the Y axis
                    success = TryMove(new Vector2(0f, movementInput.y));
                }
            
            }

            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "WhalerIsland2" || SceneManager.GetActiveScene().name != "SkullIsland2")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                changeWeapon.SwitchWeapon("Machete");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                changeWeapon.SwitchWeapon("FlintlockPistol");
            }

            // if (Input.GetKeyDown(KeyCode.Alpha3))
            // {
            //     changeWeapon.SwitchWeapon("GoldenMachete");
            // }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction,  // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
            movementFilter, // Filter that determines where a collision can occur on such as layers to collide with
            castCollisions, // List of collisions to store the found collisions into after the Cast is finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset   //The amount to case equal to the movement plus an offset
        );

        if (count == 0) // no collision
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {       
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void AnimatorDirection()
    {
        Vector3 mousePosition = UtilityFunctions.GetMouseWorldPosition();
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();
        animator.SetFloat("XInput", direction.x);
        animator.SetFloat("YInput", direction.y);
    }
}