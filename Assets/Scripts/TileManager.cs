using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerGS" || other.gameObject.tag == "PlayerD")
        {
            if (SceneManager.GetActiveScene().name == "SkullIsland2")
            {
                SceneManager.LoadScene("GiantSkeletonDungeon");
            }

            if (SceneManager.GetActiveScene().name == "SkullIsland3")
            {
                SceneManager.LoadScene("DemonDungeon");
            }

            if (SceneManager.GetActiveScene().name == "SkullIsland4")
            {
                SceneManager.LoadScene("RegentsHaven1");
            }
                        
            if (SceneManager.GetActiveScene().name == "GiantSkeletonDungeon")
            {
                SceneManager.LoadScene("SkullIsland3");
            }

            if (SceneManager.GetActiveScene().name == "DemonDungeon")
            {
                SceneManager.LoadScene("SkullIsland4");
            }
        }
    }
}