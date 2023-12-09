using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBtn : MonoBehaviour
{
    [SerializeField] int classNum;
    EncounterManager em;

    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("EncounterController").GetComponent<EncounterManager>();
    }
    private void OnMouseUpAsButton()
    {
        em.SwitchClass(classNum);
    }
}
