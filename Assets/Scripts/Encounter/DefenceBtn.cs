using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceBtn : MonoBehaviour
{
    [SerializeField] public int defenceNum = 1;
    GameObject player;
    EncounterManager em;
    Defence defence;

    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("EncounterController").GetComponent<EncounterManager>();

        ResetButton();
    }
    private void OnMouseUpAsButton()
    {
        em.PlayerAction();
        player.GetComponent<EncounterPlayerAttack>().Defence(defence);
    }
    public void ResetButton()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (defenceNum == 1)
            defence = player.GetComponent<PlayerDefences>().defence1;
        else if (defenceNum == 2)
            defence = player.GetComponent<PlayerDefences>().defence2;
        else
            defence = player.GetComponent<PlayerDefences>().defence3;

        if (defence != null)
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = defence.sprite;
    }
}
