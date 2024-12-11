using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintlockPistol : MonoBehaviour
{
    private Animator flintAnimator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    private void Awake()
    {
        flintAnimator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (bulletPrefab != null)
        {
            flintAnimator.SetTrigger("Shoot");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }    
}