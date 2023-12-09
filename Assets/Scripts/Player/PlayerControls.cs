using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerStats stats;
    private CanJump canJump;

    [SerializeField] private int speed = 3;
    private Quaternion lookRight;
    private Quaternion lookLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
        canJump = transform.GetChild(0).GetComponent<CanJump>();

        lookRight = new Quaternion(0, 0, 0, 0);
        lookLeft = new Quaternion(0, 180, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        /*
         * Animations
         */

        //Jumping

        //Up
        if(rb.velocity.y > 0)
        {
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
        }
        //Down
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("Falling", true);
            anim.SetBool("Jumping", false);
        }
        
        //Ground
        else
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);

            if (Input.GetKeyDown("7"))
            {
                anim.Play("Attack");
            }
            else if (rb.velocity.x == 0)
            {
                anim.SetBool("Walking", false);
            }
            else if (rb.velocity.x != 0)
            {
                anim.SetBool("Walking", true);
            }
        }
        if (rb.velocity.x < 0)
            transform.rotation = lookLeft;
        else if(rb.velocity.x > 0)
            transform.rotation = lookRight;
    }
    
    public void Hurt(int damage)
    {
        stats.hp -= damage;
        //Add switch class if died
    }
}
