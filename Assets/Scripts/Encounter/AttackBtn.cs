using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBtn : MonoBehaviour
{ 
    [SerializeField] public int attackNum = 1;
    GameObject player;
    EncounterManager em;
    Attack attack;

    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("EncounterController").GetComponent<EncounterManager>();

        ResetButton();
    }
    private void OnMouseUpAsButton()
    {
        em.PlayerAction();
        player.GetComponent<EncounterPlayerAttack>().Attack(attack);
    }
    public void ResetButton()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (attackNum == 1)
            attack = player.GetComponent<PlayerAttacks>().attack1;
        else if (attackNum == 2)
            attack = player.GetComponent<PlayerAttacks>().attack2;
        else
            attack = player.GetComponent<PlayerAttacks>().attack3;

        if (attack != null)
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = attack.sprite;
    }
    
}
