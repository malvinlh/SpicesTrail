using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timeBetweenShots;
    public GameObject muzzleFlash;
    [SerializeField] private Animator enemyAnimator;
    private bool isShooting = false; // Flag to track if the enemy is currently shooting
    private Coroutine shootCoroutine; // Coroutine reference

    void Awake()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(false);
        }
    }

    public void StartShootCoroutine()
    {
        if (!isShooting) // Only start shooting if not already shooting
        {
            shootCoroutine = StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator ShootCoroutine()
    {
        isShooting = true; // Set the shooting flag to true

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShots);

            Shoot();

            // Show muzzle flash
            if (muzzleFlash != null)
            {
                muzzleFlash.SetActive(true);
            }

            // Play shoot animation
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Shoot");
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDisable()
    {
        if (shootCoroutine != null) // If coroutine is running
        {
            StopCoroutine(shootCoroutine); // Stop the coroutine
            shootCoroutine = null; // Reset the coroutine reference
            isShooting = false; // Reset the shooting flag
        }
    }

    private void OnEnable()
    {
        StartShootCoroutine(); // Restart shooting when enabled
    }
}