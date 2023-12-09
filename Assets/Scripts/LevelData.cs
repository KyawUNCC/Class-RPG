using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int exp;
    public Player samurai;
    public Player wizard;
    public Player robot;

    public List<Enemy> Enemies;
}
[Serializable]
public class Player
{
    public Vector3 location;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;
    public int spd;

    public Player(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();

        location = player.transform.position;

        maxHp = stats.maxHp;
        hp = stats.hp;
        atk = stats.atk;
        def = stats.def;
        spd = stats.spd;
    }
    public Player(GameObject player, Vector3 _location)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();

        location = _location;

        maxHp = stats.maxHp;
        hp = stats.hp;
        atk = stats.atk;
        def = stats.def;
        spd = stats.spd;
    }
}

[Serializable]
public class Enemy
{
    public string name;
    public Vector3 location;
    public float facing;

    public Enemy(string _name, Vector3 _location)
    {
        name = _name;
        location = _location;
        facing = 0;
    }
    public Enemy(string _name, Vector3 _location, float _facing)
    {
        name = _name;
        location = _location;
        facing = _facing;
    }
}

public class PlayerSkills
{
    public bool samuraiAtk1;
    public bool samuraiAtk2;
    public bool samuraiAtk3;
    public bool samuraiDef1;
    public bool samuraiDef2;
    public bool samuraiDef3;
    public bool wizardAtk1;
    public bool wizardAtk2;
    public bool wizardAtk3;
    public bool wizardDef1;
    public bool wizardDef2;
    public bool wizardDef3;
    public bool robotAtk1;
    public bool robotAtk2;
    public bool robotAtk3;
    public bool robotDef1;
    public bool robotDef2;
    public bool robotDef3;

    public PlayerSkills()
    {
        this.samuraiAtk1 = true;
        this.samuraiAtk2 = true;
        this.samuraiAtk3 = true;
        this.samuraiDef1 = true;
        this.samuraiDef2 = true;
        this.samuraiDef3 = true;
        this.wizardAtk1 = true;
        this.wizardAtk2 = true;
        this.wizardAtk3 = true;
        this.wizardDef1 = true;
        this.wizardDef2 = true;
        this.wizardDef3 = true;
        this.robotAtk1 = true;
        this.robotAtk2 = true;
        this.robotAtk3 = true;
        this.robotDef1 = true;
        this.robotDef2 = true;
        this.robotDef3 = true;
    }
}

