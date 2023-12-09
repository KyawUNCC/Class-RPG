using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveAndLoad>().SetScene();
    }
}
