using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Animator anim;
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
