using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    public float timeLimit = 2;
    private float timer;
    public int jumpHeight = 5;
    public int jumpDistance = 2;
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
            if (timer >= timeLimit)
            {
                anim.SetBool("Jump", true);
                timer = 0;
            }
        }
        if (timer < timeLimit)
            timer += Time.deltaTime;

        if (stats.hp <= 0)
        {
            Instantiate(dust, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void Jump()
    {
        if(transform.rotation.y == 0)
            rb.velocity = new Vector2(jumpDistance, jumpHeight);
        else
            rb.velocity = new Vector2(-jumpDistance, jumpHeight);
    }
    public void EndJump()
    {
        anim.SetBool("Jump", false);
    }
}
