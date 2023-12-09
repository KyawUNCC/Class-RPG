using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackP : MonoBehaviour
{
    PlayerStats ps;
    LevelManager level;
    Encounter encounter;

    void Start()
    {
        ps = GetComponentInParent<PlayerStats>();
        level = transform.parent.GetComponentInParent<LevelManager>();
        encounter = GameObject.FindGameObjectWithTag("GameController").GetComponent<Encounter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats es = collision.GetComponent<EnemyStats>();

            es.hp -= (ps.atk - es.def);
            if (es.hp > 0)
                encounter.StartEncounter(collision.gameObject);
            else
                level.AddExp(es.exp);
        }
    }
}
