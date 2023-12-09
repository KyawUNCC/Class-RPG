using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int exp;

    public int GetExp()
    {
        return exp;
    }
    public void SetExp(int newExp)
    {
        exp = newExp;
    }
    public void AddExp(int addExp)
    {
        exp += addExp;
    }
}
