using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    List<StatusEffect> effects;

    int hp;
    int atk;
    int def;
    int spd;

    [SerializeField] Transform statIcon;

    // Start is called before the first frame update
    void Start()
    {
        effects = new List<StatusEffect>();

        hp = 0;
        atk = 0;
        def = 0;
        spd = 0;
    }

    public int GetStat(string stat)
    {
        return stat switch
        {
            "hp" => hp,
            "atk" => atk,
            "def" => def,
            "spd" => spd,
            _ => hp,
        };
    }

    public void StartEffect(StatusEffect effect)
    {
        effects.Add(effect);
        UpdateStat(effect, 1);
        //Instantiate(statIcon);
    }
    public void CheckEffects()
    {
        if (effects != null && effects.Count > 0)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                Debug.Log("Status: " + effects[i].stat + " Duration: " + effects[i].duration);
                effects[i].duration--;
                if (effects[i].isContinuous)
                {
                    UpdateStat(effects[i], 1);
                }
                if (effects[i].duration <= 0)
                {
                    if (!effects[i].isContinuous)
                    {
                        UpdateStat(effects[i], -1);
                    }
                    effects.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    private void UpdateStat(StatusEffect effect, int sign)
    {
        int amount = effect.amount * sign;

        switch (effect.stat)
        {
            case "hp":
                Transform current;
                if (transform.GetChild(0).gameObject.activeSelf)
                    current = transform.GetChild(0);
                else if (transform.GetChild(1).gameObject.activeSelf)
                    current = transform.GetChild(1);
                else
                    current = transform.GetChild(2);

                PlayerStats stats = current.GetComponent<PlayerStats>();
                current.GetComponent<PlayerStats>().hp += amount;
                current.GetComponent<HealthBarManager>().UpdateHealthBar(stats.hp, stats.maxHp);

                break;
            case "atk":
                atk += amount;
                break;
            case "def":
                def += amount;
                break;
            case "spd":
                spd += amount;
                break;
        }
    }
}
