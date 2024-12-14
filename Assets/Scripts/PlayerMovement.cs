using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    // public AudioSource walkAudio;

    private Vector2 playerMovement;
    private Rigidbody2D rigididbody;
    private Animator animator;

    private PlayerAimWeapon aimWeapon;
    private ChangeWeapon changeWeapon;

    public bool isInputEnabled = true; // Control flag for input

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";

    void Awake()
    {
        rigididbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        aimWeapon = GetComponent<PlayerAimWeapon>();
        changeWeapon = GetComponent<ChangeWeapon>();
    }

    void FixedUpdate()
    {
        // // Check if the game is paused
        // if (PauseMenu.IsPaused)
        // {
        //     if (walkAudio.isPlaying)
        //     {
        //         walkAudio.Stop(); // Ensure the audio stops when paused
        //     }
        //     rigididbody.velocity = Vector2.zero; // Stop the player's movement
        //     return; // Exit Update early to prevent any further processing
        // }

        if (isInputEnabled)
        {
            playerMovement.Set(InputManager.playerMovement.x, InputManager.playerMovement.y);
            rigididbody.velocity = playerMovement * moveSpeed;

            animator.SetFloat(horizontal, playerMovement.x);
            animator.SetFloat(vertical, playerMovement.y);

            if (playerMovement != Vector2.zero)
            {
                animator.SetFloat(lastHorizontal, playerMovement.x);
                animator.SetFloat(lastVertical, playerMovement.y);

                // if (!walkAudio.isPlaying)
                // {
                //     walkAudio.Play();
                // }
            }
            else
            {
                // if (walkAudio.isPlaying)
                // {
                //     walkAudio.Stop();
                // }
            }
        }
        else
        {
            // Stop movement if input is disabled
            rigididbody.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        // kasih if yg dia ga bole pake senjata
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Q1_D1_D2" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Q1_D3")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                changeWeapon.SwitchWeapon("Machete");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                changeWeapon.SwitchWeapon("FlintlockPistol");
            }
        }
    }

}