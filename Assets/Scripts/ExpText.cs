using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpText : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text;
    LevelManager exp;

    // Start is called before the first frame update
    void Start()
    {
        exp = GameObject.FindGameObjectWithTag("PlayerCollection").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Exp: " + exp.GetExp();
    }
}
