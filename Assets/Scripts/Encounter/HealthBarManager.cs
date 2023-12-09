using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] Image healthBar;
    Text text;

    [SerializeField] bool isPlayer;

    private void Start()
    {
        float startHp;
        float maxHp;
        if (isPlayer)
        {
            healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").transform.GetChild(2).GetComponent<Image>();
            maxHp = GetComponent<PlayerStats>().maxHp;
            startHp = GetComponent<PlayerStats>().hp;
        }
        else
        {
            healthBar = GameObject.FindGameObjectWithTag("EnemyHealthBar").transform.GetChild(2).GetComponent<Image>();
            maxHp = GetComponent<EnemyStats>().maxHp;
            startHp = GetComponent<EnemyStats>().hp;
        }

        text = healthBar.transform.parent.GetChild(3).GetComponent<Text>();

        UpdateHealthBar(startHp, maxHp);
    }
    public void UpdateHealthBar(float _newHealth, float _maxHealth)
    {
        healthBar.fillAmount = _newHealth / _maxHealth;
        text.text = "HP: " + _newHealth + " / " + _maxHealth;
    }
}
