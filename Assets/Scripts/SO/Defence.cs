using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defence")]
public class Defence : ScriptableObject
{
    public string defName;
    public string id;
    public Sprite sprite;
    public int accuracy;
    public StatusEffect effect;
    public int form;

    public Defence()
    {
        defName = "N/A";
        effect = null;
        id = "N/A";
        sprite = null;
        accuracy = 100;
    }
    public Defence(StatusEffect _effect, string _id)
    {
        defName = "N/A";
        effect = _effect;
        id = _id;
        sprite = null;
        accuracy = 100;
    }
    public Defence(string _defName, StatusEffect _effect, string _id, Sprite _sprite)
    {
        defName = _defName;
        effect = _effect;
        id = _id;
        sprite = _sprite;
        accuracy = 100;
    }
    public Defence(string _defName, StatusEffect _effect, string _id, Sprite _sprite, int _accuracy)
    {
        defName = _defName;
        effect = _effect;
        id = _id;
        sprite = _sprite;
        accuracy = _accuracy;
    }
}
