using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack")]
public class Attack : ScriptableObject
{
    public string atkName;
    public float damage;
    public string id;
    public Sprite sprite;
    public bool move;
    public StatusEffect effect;
    public int form;

    public Attack()
    {
        atkName = "N/A";
        damage = 0;
        id = "N/A";
        sprite = null;
        move = false;
    }
    public Attack(float _damage, string _id)
    {
        atkName = "N/A";
        damage = _damage;
        id = _id;
        sprite = null;
        move = false;
    }
    public Attack(string _atkName, float _damage, string _id, Sprite _sprite)
    {
        atkName = _atkName;
        damage = _damage;
        id = _id;
        sprite = _sprite;
        move = false;
    }
    public Attack(string _atkName, float _damage, string _id, Sprite _sprite, bool _move)
    {
        atkName = _atkName;
        damage = _damage;
        id = _id;
        sprite = _sprite;
        move = _move;
    }
    public Attack(string _atkName, float _damage, string _id, Sprite _sprite, bool _move, StatusEffect _effect)
    {
        atkName = _atkName;
        damage = _damage;
        id = _id;
        sprite = _sprite;
        move = _move;
        effect = _effect;
    }
}
