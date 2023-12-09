using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSlimeAttack : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        rb.velocity = new Vector2(-10, 5);
    }
}
