using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckDeath : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    // Update is called once per frame
    void Update()
    {
        if (stats.hp <= 0)
            SceneManager.LoadScene("Lose");
    }
}
