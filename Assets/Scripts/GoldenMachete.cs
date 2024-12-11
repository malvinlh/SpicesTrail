using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenMachete : MonoBehaviour
{
    //public Animator macheteAnimator;
    public Transform boxCenter;
    public Vector2 boxSize;

    private void Awake()
    {
        //macheteAnimator = transform.GetComponent<Animator>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = boxCenter == null ? Vector3.zero : boxCenter.position;
        Gizmos.DrawWireCube(position, new Vector3(boxSize.x, boxSize.y, 0f));
    }

    public void DetectColliders()
    {
        Vector2 boxCenterPosition = boxCenter == null ? transform.position : boxCenter.position;
        // foreach (Collider2D collider in Physics2D.OverlapBoxAll(boxCenterPosition, boxSize, 0f))
        // {
        //     Debug.Log(collider.name);
        // }
    }    
}