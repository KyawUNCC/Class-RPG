using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] GameObject Slime_P;
    [SerializeField] GameObject Bear_P;
    [SerializeField] GameObject Werewolf_P;
    [SerializeField] GameObject Orc_Green_P;
    [SerializeField] GameObject Snake_P;
    [SerializeField] GameObject Orc_Shaman_P;


    public bool testing = false;
    public int currentClass;

    [SerializeField] private string pathName;
    [SerializeField] private bool SaveBeginning;

    void Start()
    {
        if (SaveBeginning)
        {
            pathName = "/Saves/" + SceneManager.GetActiveScene().name + "StartLevelDataFile.json";
            SaveLevel();
        }
    }

    public void SetScene()
    {
        pathName = "/Saves/" + SceneManager.GetActiveScene().name + "LevelDataFile.json";
        if (testing)
        {
            if (File.Exists(Application.persistentDataPath + pathName))
                File.Delete(Application.persistentDataPath + pathName);
        }
        else if (File.Exists(Application.persistentDataPath + pathName))
            LoadLevel();
        else
            LoadLevel("/Saves/" + SceneManager.GetActiveScene().name + "StartLevelDataFile.json");
    }
    public void SaveLevel()
    {
        if (File.Exists(Application.persistentDataPath + pathName))
            File.Delete(Application.persistentDataPath + pathName);
        LevelData levelData = new LevelData();

        SavePlayer(levelData);

        GameObject enemyList = GameObject.FindGameObjectWithTag("Enemy List");
        levelData.Enemies = new List<Enemy>();
        for (int i = 0; i < enemyList.transform.childCount; i++)
        {
            levelData.Enemies.Add(new Enemy(enemyList.transform.GetChild(i).name, enemyList.transform.GetChild(i).position, enemyList.transform.GetChild(i).rotation.eulerAngles.y));
        }

        //Write json file
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.persistentDataPath + pathName, json);
    }

    private void SavePlayer(LevelData levelData)
    {
        SaveClass();

        Transform playerCollection = GameObject.FindGameObjectWithTag("PlayerCollection").transform;
        levelData.exp = playerCollection.GetComponent<LevelManager>().GetExp();

        levelData.samurai = new Player(playerCollection.GetChild(0).gameObject);
        levelData.wizard = new Player(playerCollection.GetChild(1).gameObject);
        levelData.robot = new Player(playerCollection.GetChild(2).gameObject);
    }
    
    public void LoadStartEncounter(Transform playerCollection)
    {
        LoadPlayerSkills();

        //Read json file
        string json = File.ReadAllText(Application.persistentDataPath + pathName);
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);

        LoadPlayer(levelData, playerCollection);
    }
    public void SaveEndEncounter()
    {
        SavePlayerSkills();

        //Read json file
        string oldJson = File.ReadAllText(Application.persistentDataPath + pathName);
        LevelData levelData = JsonUtility.FromJson<LevelData>(oldJson);

        SavePlayer(levelData, true);

        //Write json file
        string newJson = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.persistentDataPath + pathName, newJson);
    }
    public void LoadLevel()
    {
        LoadPlayerSkills();

        //Read json file
        string json = File.ReadAllText(Application.persistentDataPath + pathName);
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);

        //Load Player data
        Transform playerCollection = GameObject.FindGameObjectWithTag("PlayerCollection").transform;
        playerCollection.GetChild(0).transform.position = levelData.samurai.location;
        playerCollection.GetChild(1).transform.position = levelData.wizard.location;
        playerCollection.GetChild(2).transform.position = levelData.robot.location;
        LoadPlayer(levelData, playerCollection);

        //Load Enemy data
        GameObject enemyList = GameObject.FindGameObjectWithTag("Enemy List");

        //Clear EnemyList
        for (int i = 0; i < enemyList.transform.childCount; i++)
        {
            Destroy(enemyList.transform.GetChild(i).gameObject);
        }

        //Create each enemy reading their names to create which enemy
        foreach (Enemy enemy in levelData.Enemies)
        {
            GameObject _enemyObject = Slime_P;

            if(enemy.name.Contains("Slime_P"))
                _enemyObject = Slime_P;
            else if (enemy.name.Contains("Bear_P"))
                _enemyObject = Bear_P;
            else if (enemy.name.Contains("Werewolf_P"))
                _enemyObject = Werewolf_P;
            else if (enemy.name.Contains("Orc_Green_P"))
                _enemyObject = Orc_Green_P;
            else if (enemy.name.Contains("Snake_P"))
                _enemyObject = Snake_P;
            else if (enemy.name.Contains("Orc_Shaman_P"))
                _enemyObject = Orc_Shaman_P;

            Instantiate(_enemyObject, enemy.location, Quaternion.Euler(0, enemy.facing, 0), enemyList.transform);
        }
    }
    public void LoadLevel(string filePath)
    {
        pathName = filePath;
        LoadLevel();
        pathName = "/Saves/" + SceneManager.GetActiveScene().name + "LevelDataFile.json";
    }
    private void SavePlayer(LevelData levelData, bool saveLocation)
    {
        Transform playerCollection = GameObject.FindGameObjectWithTag("PlayerCollection").transform;
        levelData.exp = playerCollection.GetComponent<LevelManager>().GetExp();

        levelData.samurai = new Player(playerCollection.GetChild(0).gameObject, levelData.samurai.location);
        levelData.wizard = new Player(playerCollection.GetChild(1).gameObject, levelData.wizard.location);
        levelData.robot = new Player(playerCollection.GetChild(2).gameObject, levelData.robot.location);

        if (levelData.samurai.hp <= 0)
            levelData.samurai.hp = 1;
        if (levelData.wizard.hp <= 0)
            levelData.wizard.hp = 1;
        if (levelData.robot.hp <= 0)
            levelData.robot.hp = 1;
    }
    private void LoadPlayer(LevelData levelData, Transform playerCollection)
    {
        playerCollection.GetComponent<LevelManager>().SetExp(levelData.exp);

        //Transfer stats for each class

        PlayerStats samuraiStats = playerCollection.GetChild(0).GetComponent<PlayerStats>();
        PlayerStats wizardStats = playerCollection.GetChild(1).GetComponent<PlayerStats>();
        PlayerStats robotStats = playerCollection.GetChild(2).GetComponent<PlayerStats>();

        samuraiStats.maxHp = levelData.samurai.maxHp;
        samuraiStats.hp = levelData.samurai.hp;
        samuraiStats.atk = levelData.samurai.atk;
        samuraiStats.def = levelData.samurai.def;
        samuraiStats.spd = levelData.samurai.spd;

        wizardStats.maxHp = levelData.wizard.maxHp;
        wizardStats.hp = levelData.wizard.hp;
        wizardStats.atk = levelData.wizard.atk;
        wizardStats.def = levelData.wizard.def;
        wizardStats.spd = levelData.wizard.spd;

        robotStats.maxHp = levelData.robot.maxHp;
        robotStats.hp = levelData.robot.hp;
        robotStats.atk = levelData.robot.atk;
        robotStats.def = levelData.robot.def;
        robotStats.spd = levelData.robot.spd;
    }
    private void SaveClass()
    {
        currentClass = GameObject.FindGameObjectWithTag("Player").transform.GetSiblingIndex();
    }

    private void SavePlayerSkills()
    {
        if (File.Exists(Application.persistentDataPath + "/Saves/PlayerSkills.json"))
            File.Delete(Application.persistentDataPath + "/Saves/PlayerSkills.json");

        PlayerSkills skills = new PlayerSkills();
        Transform playerCollection = GameObject.FindGameObjectWithTag("PlayerCollection").transform;

        var samuraiAtk = playerCollection.GetChild(0).gameObject.GetComponent<PlayerAttacks>();
        if (samuraiAtk.attack1 == null)
            skills.samuraiAtk1 = false;
        if (samuraiAtk.attack2 == null)
            skills.samuraiAtk2 = false;
        if (samuraiAtk.attack3 == null)
            skills.samuraiAtk3 = false;
        var samuraiDef = playerCollection.GetChild(0).gameObject.GetComponent<PlayerDefences>();
        if (samuraiDef.defence1 == null)
            skills.samuraiDef1 = false;
        if (samuraiDef.defence2 == null)
            skills.samuraiDef2 = false;
        if (samuraiDef.defence3 == null)
            skills.samuraiDef3 = false;

        var wizardAtk = playerCollection.GetChild(1).gameObject.GetComponent<PlayerAttacks>();
        if (wizardAtk.attack1 == null)
            skills.wizardAtk1 = false;
        if (wizardAtk.attack2 == null)
            skills.wizardAtk2 = false;
        if (wizardAtk.attack3 == null)
            skills.wizardAtk3 = false;
        var wizardDef = playerCollection.GetChild(1).gameObject.GetComponent<PlayerDefences>();
        if (wizardDef.defence1 == null)
            skills.wizardDef1 = false;
        if (wizardDef.defence2 == null)
            skills.wizardDef2 = false;
        if (wizardDef.defence3 == null)
            skills.wizardDef3 = false;

        var robotAtk = playerCollection.GetChild(2).gameObject.GetComponent<PlayerAttacks>();
        if (robotAtk.attack1 == null)
            skills.robotAtk1 = false;
        if (robotAtk.attack2 == null)
            skills.robotAtk2 = false;
        if (robotAtk.attack3 == null)
            skills.robotAtk3 = false;
        var robotDef = playerCollection.GetChild(2).gameObject.GetComponent<PlayerDefences>();
        if (robotDef.defence1 == null)
            skills.robotDef1 = false;
        if (robotDef.defence2 == null)
            skills.robotDef2 = false;
        if (robotDef.defence3 == null)
            skills.robotDef3 = false;


        //Write json file
        string json = JsonUtility.ToJson(skills, true);
        File.WriteAllText(Application.persistentDataPath + "/Saves/PlayerSkills.json", json);
    }
    private void LoadPlayerSkills()
    {
        string pathName = "/Saves/PlayerSkills.json";
        
        //Read json file
        if (!File.Exists(Application.persistentDataPath + pathName))
            pathName = "/Saves/PlayerSkillsStart.json";

        string json = File.ReadAllText(Application.persistentDataPath + pathName);
        PlayerSkills skills = JsonUtility.FromJson<PlayerSkills>(json);

        //Load Player data
        Transform playerCollection = GameObject.FindGameObjectWithTag("PlayerCollection").transform;

        var samuraiAtk = playerCollection.GetChild(0).gameObject.GetComponent<PlayerAttacks>();
        if (skills.samuraiAtk1 == false)
            samuraiAtk.attack1 = null;
        if (skills.samuraiAtk2 == false)
            samuraiAtk.attack2 = null;
        if (skills.samuraiAtk3 == false)
            samuraiAtk.attack3 = null;
        var samuraiDef = playerCollection.GetChild(0).gameObject.GetComponent<PlayerDefences>();
        if (skills.samuraiDef1 == false)
            samuraiDef.defence1 = null;
        if (skills.samuraiDef2 == false)
            samuraiDef.defence2 = null;
        if (skills.samuraiDef3 == false)
            samuraiDef.defence3 = null;

        var wizardAtk = playerCollection.GetChild(1).gameObject.GetComponent<PlayerAttacks>();
        if (skills.wizardAtk1 == false)
            wizardAtk.attack1 = null;
        if (skills.wizardAtk2 == false)
            wizardAtk.attack2 = null;
        if (skills.wizardAtk3 == false)
            wizardAtk.attack3 = null;
        var wizardDef = playerCollection.GetChild(1).gameObject.GetComponent<PlayerDefences>();
        if (skills.wizardDef1 == false)
            wizardDef.defence1 = null;
        if (skills.wizardDef2 == false)
            wizardDef.defence2 = null;
        if (skills.wizardDef3 == false)
            wizardDef.defence3 = null;

        var robotAtk = playerCollection.GetChild(2).gameObject.GetComponent<PlayerAttacks>();
        if (skills.robotAtk1 == false)
            robotAtk.attack1 = null;
        if (skills.robotAtk2 == false)
            robotAtk.attack2 = null;
        if (skills.robotAtk3 == false)
            robotAtk.attack3 = null;
        var robotDef = playerCollection.GetChild(2).gameObject.GetComponent<PlayerDefences>();
        if (skills.robotDef1 == false)
            robotDef.defence1 = null;
        if (skills.robotDef2 == false)
            robotDef.defence2 = null;
        if (skills.robotDef3 == false)
            robotDef.defence3 = null;
    }
}
