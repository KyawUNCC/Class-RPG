using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPlayerAttack : MonoBehaviour
{
    EncounterManager em;
    Animator anim;
    Attack theAttack;
    Defence theDefence;
    Rigidbody2D rb;
    PlayerStats stats;
    HealthBarManager hbm;
    StatusManager sm;

    private int currentForm;
    private bool forward;
    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.FindGameObjectWithTag("EncounterController").GetComponent<EncounterManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        hbm = GetComponent<HealthBarManager>();
        sm = transform.parent.GetComponent<StatusManager>();
        forward = false;
        walking = false;
    }

    public void Attack(Attack _attack)
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        theAttack = _attack;
        CheckForm(theAttack.form);

        if (theAttack.move)
        {
            forward = true;
            Move();
        }
        else
            anim.Play(theAttack.id);
    }
    public void Damage()
    {
        em.enemy.GetComponent<EncounterEnemyControls>().Hurt((stats.atk + sm.GetStat("atk")) * theAttack.damage);
        if (theAttack.effect != null)
            em.enemy.GetComponent<EncounterEnemyControls>().sm.StartEffect(StatusEffect.CreateEffect(theAttack.effect));
    }
    public void Move()
    {
        walking = true;
        int sign = -1;
        if (forward)
            sign = 1;
        rb.velocity = new Vector2(sign * 8, 0);
        anim.SetBool("Walking", true);
    }
    public void Defence(Defence _defence)
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        theDefence = _defence;
        CheckForm(theDefence.form);

        sm.StartEffect(StatusEffect.CreateEffect(theDefence.effect));
        anim.Play(theDefence.id);
    }
    public void ChangeClass()
    {

    }
    private void CheckForm(int newForm)
    {
        if (currentForm != newForm)
            ChangeForm(newForm);
    }
    public void ChangeForm(int newForm)
    {
        anim.SetInteger("Form", newForm);
        currentForm = newForm;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (forward)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                rb.velocity = new Vector2(0, 0);
                anim.SetBool("Walking", false);
                anim.Play(theAttack.id);
                forward = false;
            }
        }
        else if (!forward)
        {
            if (collision.gameObject.tag == "PlayerBlock" && walking)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("Walking", false);
                walking = false;
                CheckWin();
            }
        }
    }
    public void CheckWin()
    {
        em.CheckWin();
    }
    public void Hurt(int damage)
    {
        int _def = (stats.def + sm.GetStat("def"));

        if (_def > 0)
            damage -= _def;

        if (damage > 0)
        {
            stats.hp -= damage;
            anim.Play("Hurt");
            if (stats.hp <= 0)
            {
                anim.Play("Dead");
            }
        }
        hbm.UpdateHealthBar(stats.hp, stats.maxHp);
    }
    
}
