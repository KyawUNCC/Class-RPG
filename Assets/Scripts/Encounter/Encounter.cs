using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounter : MonoBehaviour
{
    [SerializeField] public string Stage;
    [SerializeField] public string EncounterStage;
    private Transform playerCollection;

    public GameObject pb;
    public GameObject eb;
    public GameObject player;
    public GameObject enemy;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerCollection"))
            playerCollection = GameObject.FindGameObjectWithTag("PlayerCollection").transform;
    }
    public void StartEncounter(GameObject _enemy)
    {
        enemy = _enemy;
        eb = enemy.GetComponent<EncounterForm>().encounterForm;

        var enemyS = enemy.GetComponent<EnemyStats>();
        var ebS = eb.GetComponent<EnemyStats>();

        ebS.maxHp = enemyS.maxHp;
        ebS.hp = enemyS.hp;
        ebS.exp = enemyS.exp;
        ebS.atk = enemyS.atk;
        ebS.spd = enemyS.spd;

        Destroy(_enemy);
        //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(LoadEncounter());
    }
    private IEnumerator LoadEncounter()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<SaveAndLoad>().SaveLevel();
        SceneManager.LoadScene(EncounterStage);
    }
    public void EndEncounter()
    {
        SceneManager.LoadScene(Stage);
    }
    
}
