using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateSaveFolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.dataPath + "/SavesTest"))
            File.Create(Application.dataPath + "/SavesTest");
    }
}
