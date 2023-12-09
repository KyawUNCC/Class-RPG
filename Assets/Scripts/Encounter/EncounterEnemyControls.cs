using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterEnemyControls : MonoBehaviour
{
    EncounterManager em;
    Animator anim;
    Rigidbody2D rb;
    EnemyStats stats;
    HealthBarManager hbm;
    public StatusManager sm;

    [SerializeField] private bool move;
    private bool forward;
    public List<StatusEffect> effects;

    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.FindGameObjectWithTag("EncounterController").GetComponent<EncounterManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
        hbm = GetComponent<HealthBarManager>();
        sm = GetComponent<StatusManager>();

        forward = true;
        effects = new List<StatusEffect>();
    }

    public void ChooseAction()
    {
        //Make Multiple actions later
        Attack();
    }

    public void Attack()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        if (move)
        {
            forward = false;
            Move();
        }
        else
            anim.SetBool("Attack", true);
    }
    public void Damage()
    {
        em.player.GetComponent<EncounterPlayerAttack>().Hurt((stats.atk + sm.GetStat("atk")));
        anim.SetBool("Attack", false);
    }
    public void Move()
    {
        int sign = -1;
        if (forward)
            sign = 1;
        rb.velocity = new Vector2(sign * 8, 0);
        anim.SetBool("Walking", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!forward)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.velocity = new Vector2(0, 0);
                anim.SetBool("Walking", false);
                anim.SetBool("Attack", true);
                forward = true;
            }
        }
        else if (forward)
        {
            if (collision.gameObject.tag == "EnemyBlock")
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("Walking", false);
                CheckLoss();
            }
        }
    }
    public void CheckLoss()
    {
        em.CheckLoss();
    }
    public void Hurt(float damage)
    {
        int _def = (stats.def + sm.GetStat("def"));

        if (_def > 0)
            damage -= _def;
        stats.hp -= (int) damage;
        anim.SetBool("Hurt", true);
        if (stats.hp <= 0)
        {
            anim.SetBool("Dead", true);
        }
        hbm.UpdateHealthBar(stats.hp, stats.maxHp);
    }
    public void AnimationEnd()
    {
        anim.SetBool("Hurt", false);
    }
}
