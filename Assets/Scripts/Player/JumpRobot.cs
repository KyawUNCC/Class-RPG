using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRobot : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    GameObject highlight;


    [SerializeField] private float teleportSpeed = .1f;
    [SerializeField] private float teleportMaxDistance = 6;
    [SerializeField] private float teleportRechargeTime;
    float teleportDistance;
    float teleportRecharge;

    bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        highlight = transform.GetChild(2).gameObject;

        teleportDistance = 0;
        teleportRecharge = teleportRechargeTime;

        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && teleportRecharge > teleportRechargeTime)
        {
            jumping = true;
            anim.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            highlight.SetActive(true);
            highlight.transform.position = transform.position;
        }
        if (Input.GetButton("Jump") && jumping)
        {
            teleportDistance += teleportSpeed * Time.deltaTime;
            highlight.transform.position += teleportSpeed * Time.deltaTime * transform.right;

            if (teleportDistance > teleportMaxDistance)
            {
                highlight.transform.position = transform.position;
                teleportDistance = 0;
            }
        }
        if (Input.GetButtonUp("Jump") && jumping)
        {
            transform.position = highlight.transform.position;
            anim.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            teleportDistance = 0;
            highlight.SetActive(false);
            teleportRecharge = 0;
            jumping = false;
        }
        if (teleportRecharge <= teleportRechargeTime)
        {
            teleportRecharge += 1 * Time.deltaTime;
        }
    }
    public void Jump()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
