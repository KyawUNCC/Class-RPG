using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoolReset : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void BoolReset(string name)
    {
        anim.SetBool(name, false);
    }
}
