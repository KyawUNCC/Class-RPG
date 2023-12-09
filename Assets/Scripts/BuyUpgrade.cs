using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private int num;
    [SerializeField] private int cost;

    LevelManager playerLevel;
    TMPro.TextMeshProUGUI text;

    PlayerSkills skills;

    private void Start()
    {
        playerLevel = GameObject.FindGameObjectWithTag("PlayerCollection").GetComponent<LevelManager>();
        text = transform.parent.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();

        string pathName = "/Saves/PlayerSkills.json";

        if (!File.Exists(Application.persistentDataPath + pathName))
            pathName = "/Saves/PlayerSkillsStart.json";

        //Read json file
        string read = File.ReadAllText(Application.persistentDataPath + pathName);
        skills = JsonUtility.FromJson<PlayerSkills>(read);

        if (GetSkill())
            cost = 0;

        text.text = "" + cost;
    }


    private void OnMouseUpAsButton()
    {
        int exp = playerLevel.GetExp();

        if(cost <= exp)
        {
            //Unlock Upgrade
            exp -= cost;
            playerLevel.SetExp(exp);

            switch (num)
            {
                case 0:
                    skills.samuraiAtk1 = true;
                    break;
                case 1:
                    skills.samuraiAtk2 = true;
                    break;
                case 2:
                    skills.samuraiAtk3 = true;
                    break;
                case 3:
                    skills.samuraiDef1 = true;
                    break;
                case 4:
                    skills.samuraiDef2 = true;
                    break;
                case 5:
                    skills.samuraiDef3 = true;
                    break;
                case 6:
                    skills.wizardAtk1 = true;
                    break;
                case 7:
                    skills.wizardAtk2 = true;
                    break;
                case 8:
                    skills.wizardAtk3 = true;
                    break;
                case 9:
                    skills.wizardDef1 = true;
                    break;
                case 10:
                    skills.wizardDef2 = true;
                    break;
                case 11:
                    skills.wizardDef3 = true;
                    break;
                case 12:
                    skills.robotAtk1 = true;
                    break;
                case 13:
                    skills.robotAtk2 = true;
                    break;
                case 14:
                    skills.robotAtk3 = true;
                    break;
                case 15:
                    skills.robotDef1 = true;
                    break;
                case 16:
                    skills.robotDef2 = true;
                    break;
                case 17:
                    skills.robotDef3 = true;
                    break;
            }

            cost = 0;
            text.text = "" + cost;

            //Write json file
            string write = JsonUtility.ToJson(skills, true);
            File.WriteAllText(Application.persistentDataPath + "/Saves/PlayerSkills.json", write);
        }
    }

    public int GetCost()
    {
        return cost;
    }

    private bool GetSkill()
    {
        switch (num)
        {
            case 0:
                return skills.samuraiAtk1;
            case 1:
                return skills.samuraiAtk2;
            case 2:
                return skills.samuraiAtk3;
            case 3:
                return skills.samuraiDef1;
            case 4:
                return skills.samuraiDef2;
            case 5:
                return skills.samuraiDef3;
            case 6:
                return skills.wizardAtk1;
            case 7:
                return skills.wizardAtk2;
            case 8:
                return skills.wizardAtk3;
            case 9:
                return skills.wizardDef1;
            case 10:
                return skills.wizardDef2;
            case 11:
                return skills.wizardDef3;
            case 12:
                return skills.robotAtk1;
            case 13:
                return skills.robotAtk2;
            case 14:
                return skills.robotAtk3;
            case 15:
                return skills.robotDef1;
            case 16:
                return skills.robotDef2;
            case 17:
                return skills.robotDef3;
            default:
                return false;
        }
    }
}
