using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemyControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    public float moveSpeed = 4;
    private EnemyStats stats;
    public GameObject dust;
    private EnemyControls ec;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        stats = GetComponent<EnemyStats>();
        ec = GetComponent<EnemyControls>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ec.seePlayer)
        {
            anim.SetBool("Walking", true);
            if (transform.rotation.y == 0)
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            anim.SetBool("Walking", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (stats.hp <= 0)
        {
            Instantiate(dust, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
