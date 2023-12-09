using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump : MonoBehaviour
{
    private bool onGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }

    public bool GetOnGround()
    {
        return onGround;
    }
}
