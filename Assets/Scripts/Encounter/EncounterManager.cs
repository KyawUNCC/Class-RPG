using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    private GameObject gc;
    [SerializeField] public bool testing;

    [SerializeField] GameObject enemyLoc;
    [SerializeField] private Transform playerCollection;
    [SerializeField] private GameObject playerUI;

    public GameObject player;
    public GameObject enemy;

    StatusManager playerSM;
    StatusManager enemySM;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
        gc.GetComponent<SaveAndLoad>().LoadStartEncounter(playerCollection);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = playerCollection.GetChild(gc.GetComponent<SaveAndLoad>().currentClass).gameObject;
        playerCollection.GetChild(gc.GetComponent<SaveAndLoad>().currentClass).gameObject.SetActive(true);
        enemy = Instantiate(gc.GetComponent<Encounter>().eb, enemyLoc.transform.position, Quaternion.identity);
        playerSM = player.transform.parent.GetComponent<StatusManager>();
        enemySM = enemy.GetComponent<StatusManager>();
        Choose();
    }
    public void Choose()
    {
        playerSM.CheckEffects();
        playerUI.SetActive(true);
        ChooseOption(0);
    }
    public void Choose(bool option)
    {
        playerUI.SetActive(true);
        ChooseOption(0);
    }
    /// <summary>
    /// Picks which list of buttons should be displayed
    /// </summary>
    /// <param name="choice"></param>
    public void ChooseOption(int choice)
    {
        for(int i = 0; i < playerUI.transform.childCount; i++)
        {
            playerUI.transform.GetChild(i).gameObject.SetActive(false);
        }
        if(choice > -1 && choice < playerUI.transform.childCount)
            playerUI.transform.GetChild(choice).gameObject.SetActive(true);
    }
    public void PlayerAction()
    {
        playerUI.SetActive(false);
    }
    public void EnemyAction()
    {
        enemySM.CheckEffects();
        enemy.GetComponent<EncounterEnemyControls>().ChooseAction();
    }
    /// <summary>
    /// See if player wins encounter, if not go to enemy's turn
    /// </summary>
    public void CheckWin()
    {
        if (enemy.GetComponent<EnemyStats>().hp <= 0)
        {
            Win();
        }
        else
            EnemyAction();
    }
    /// <summary>
    /// See if player loses encounter, if not go to player's turn
    /// </summary>
    public void CheckLoss()
    {
        if (player.GetComponent<PlayerStats>().hp <= 0)
        {
            Lose();
        }
        else
            Choose();
    }
    private void Win()
    {
        //Gain exp, Check if levels up, Save player data, End encounter
        playerCollection.GetComponent<LevelManager>().AddExp(enemy.GetComponent<EnemyStats>().exp);
        Debug.Log("Current Level: " + playerCollection.GetComponent<LevelManager>().GetExp());
        gc.GetComponent<SaveAndLoad>().SaveEndEncounter();
        gc.GetComponent<Encounter>().EndEncounter();
    }
    private void Lose()
    {
        if (playerCollection.GetChild(0).GetComponent<PlayerStats>().hp > 0)
            SwitchClass(0);
        else if (playerCollection.GetChild(1).GetComponent<PlayerStats>().hp > 0)
            SwitchClass(1);
        else if (playerCollection.GetChild(2).GetComponent<PlayerStats>().hp > 0)
            SwitchClass(2);
        else
            SceneManager.LoadScene("Lose");
    }
    public Transform getPlayerCollection()
    {
        return playerCollection;
    }
    public void SwitchClass(int classNum)
    {
        playerCollection.GetChild(0).gameObject.SetActive(false);
        playerCollection.GetChild(1).gameObject.SetActive(false);
        playerCollection.GetChild(2).gameObject.SetActive(false);
        playerCollection.GetChild(classNum).gameObject.SetActive(true);

        playerUI.transform.GetChild(1).transform.GetChild(0).GetComponent<DefenceBtn>().ResetButton();
        playerUI.transform.GetChild(1).transform.GetChild(1).GetComponent<DefenceBtn>().ResetButton();
        playerUI.transform.GetChild(1).transform.GetChild(2).GetComponent<DefenceBtn>().ResetButton();

        playerUI.transform.GetChild(2).transform.GetChild(0).GetComponent<AttackBtn>().ResetButton();
        playerUI.transform.GetChild(2).transform.GetChild(1).GetComponent<AttackBtn>().ResetButton();
        playerUI.transform.GetChild(2).transform.GetChild(2).GetComponent<AttackBtn>().ResetButton();

        player = playerCollection.GetChild(classNum).gameObject;
        Choose(false);
    }
}
