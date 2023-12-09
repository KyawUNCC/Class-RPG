using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private string nextEncounter;

    private GameObject gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gc.GetComponent<Encounter>().Stage = nextLevel;
            gc.GetComponent<Encounter>().EncounterStage = nextEncounter;
            SceneManager.LoadScene(nextLevel);
        }
    }
}
