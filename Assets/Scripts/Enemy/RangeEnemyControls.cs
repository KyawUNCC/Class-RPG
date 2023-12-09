using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private EnemyStats stats;
    public GameObject dust;
    private EnemyControls ec;

    [SerializeField] GameObject projectile;

    [SerializeField] float attackDelay;
    private float attackTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        stats = GetComponent<EnemyStats>();
        ec = GetComponent<EnemyControls>();

        attackTimer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (ec.seePlayer)
        {
            attackTimer += 1 * Time.deltaTime;
            
            if(attackTimer > attackDelay)
            {
                attackTimer = 0;

                Attack();
            }
        }
        else
        {
            attackTimer = 0;
        }

        if (stats.hp <= 0)
        {
            Instantiate(dust, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void Attack()
    {
        anim.Play("Attack");
    }
    public void Projectile()
    {
        Instantiate(projectile, transform.GetChild(0).transform.position, Quaternion.identity);
    }
}
