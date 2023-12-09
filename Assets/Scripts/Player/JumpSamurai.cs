using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSamurai : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CanJump canJump;

    bool canDoubleJump;
    
    [SerializeField] private float jumpHeight = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = transform.GetChild(0).GetComponent<CanJump>();

        canDoubleJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump.GetOnGround())
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            anim.Play("JumpStart");
        }
        if (Input.GetButtonDown("Jump") && !canJump.GetOnGround() && canDoubleJump)
        {
            Jump();
            canDoubleJump = false;
        }
        if (!canDoubleJump && canJump.GetOnGround())
        {
            canDoubleJump = true;
        }
    }
    public void Jump()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
