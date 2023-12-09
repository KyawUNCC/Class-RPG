using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private SpriteRenderer sr;
    public Animator anim;
    public int vision = 5;
    public float delay = 0;
    private Transform player;
    public bool seePlayer;
    private Quaternion lookRight;
    private Quaternion lookLeft;
    private bool lookingRight;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        seePlayer = false;
        lookRight = new Quaternion(0, 0, 0, 0);
        lookLeft = new Quaternion(0, 180, 0, 0);
        if (transform.rotation.y == 0)
            lookingRight = true;
        else
            lookingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector3.Distance(transform.position, player.position) < vision)
        {
            seePlayer = true;
            if (transform.position.x - player.position.x < 0)
            {
                if (!lookingRight)
                {
                    StartCoroutine(Turn(1));
                }
                lookingRight = true;
            }
            else
            {
                if (lookingRight)
                {
                    StartCoroutine(Turn(-1));
                }
                lookingRight = false;
            }
        }
        else
        {
            seePlayer = false;
        }
    }
    IEnumerator Turn(int turn)
    {
        if (turn > 0)
        {
            yield return new WaitForSeconds(delay);
            transform.rotation = lookRight;
        }
        else
        {
            yield return new WaitForSeconds(delay);
            transform.rotation = lookLeft;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Encounter>().StartEncounter(this.gameObject);
        }
    }

    public void Hurt(int damage)
    {
        GetComponent<EnemyStats>().hp -= damage;
        anim.SetBool("Hurt", true);
    }
}
