using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private bool isNew;
    public void LoadScene()
    {
        if(isNew)
        {
            if (File.Exists(Application.dataPath + "/Saves/ForestLevelDataFile.json"))
                File.Delete(Application.dataPath + "/Saves/ForestLevelDataFile.json");
            if (File.Exists(Application.dataPath + "/Saves/DesertLevelDataFile.json"))
                File.Delete(Application.dataPath + "/Saves/DesertLevelDataFile.json");
            if (File.Exists(Application.dataPath + "/Saves/PlayerSkills.json"))
                File.Delete(Application.dataPath + "/Saves/PlayerSkills.json");

            SceneManager.LoadScene("Forest");
        }
        else
        {
            if (File.Exists(Application.dataPath + "/Saves/DesertLevelDataFile.json"))
                SceneManager.LoadScene("Desert");
            else
                SceneManager.LoadScene("Forest");
        }
    }
}
