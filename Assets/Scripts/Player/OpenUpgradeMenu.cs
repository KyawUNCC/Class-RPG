using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!upgradeMenu.activeSelf)
            {
                upgradeMenu.SetActive(true);
            }
            else
            {
                upgradeMenu.SetActive(false);
            }
        }
    }
}
