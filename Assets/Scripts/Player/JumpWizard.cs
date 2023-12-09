using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWizard : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CanJump canJump;
    GameObject highlight;


    [SerializeField] private float jumpHeight = 8;
    [SerializeField] private float floatVelocity = .5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = transform.GetChild(0).GetComponent<CanJump>();
        highlight = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump.GetOnGround())
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            anim.Play("JumpStart");
        }

        if (Input.GetButton("Jump") && !canJump.GetOnGround() && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, floatVelocity);
            highlight.SetActive(true);
        }
        else
        {
            highlight.SetActive(false);
        }

        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    public void Jump()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
