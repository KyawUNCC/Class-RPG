using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBtn : MonoBehaviour
{
    [SerializeField] int option;
    EncounterManager em;

    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("EncounterController").GetComponent<EncounterManager>();
    }
    private void OnMouseUpAsButton()
    {
        em.ChooseOption(option);
    }
}
