using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect")]
public class StatusEffect : ScriptableObject
{
    public int duration;
    public int amount;
    public string stat;
    public bool isContinuous;
    [SerializeField] public Sprite icon;

    public StatusEffect(StatusEffect effect)
    {
        duration = effect.duration;
        amount = effect.amount;
        stat = effect.stat;
        isContinuous = effect.isContinuous;
    }
    public static StatusEffect CreateEffect(StatusEffect _effect)
    {
        StatusEffect temp = ScriptableObject.CreateInstance<StatusEffect>();
        temp.duration = _effect.duration;
        temp.amount = _effect.amount;
        temp.stat = _effect.stat;
        temp.isContinuous = _effect.isContinuous;

        return temp;
    }
    public StatusEffect(int _duration)
    {
        duration = _duration;
        amount = 0;
        stat = null;
        isContinuous = false;
    }
    public StatusEffect(int _duration, int _amount)
    {
        duration = _duration;
        amount = _amount;
        stat = "hp";
        isContinuous = false;
    }
    public StatusEffect(int _duration, int _amount, string _stat)
    {
        duration = _duration;
        amount = _amount;
        stat = _stat;
        isContinuous = false;
    }
    public StatusEffect(int _duration, int _amount, string _stat, bool _isCountinuous)
    {
        duration = _duration;
        amount = _amount;
        stat = _stat;
        isContinuous = _isCountinuous;
    }

}
