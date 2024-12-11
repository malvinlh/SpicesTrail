using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject skeletonBoss;
    public TextMeshProUGUI text;

    void Awake()
    {
        skeletonBoss.SetActive(false);
    }

    public void Activate()
    {
        skeletonBoss.SetActive(true);
    }
}
