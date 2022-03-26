using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        prep,
        create,
        pick,
        fight,
        result,
        victory

    }

    public GameState gState;
    public GameObject fighterPrefab;
    public int teamSize = 3;
    public string[] fighterNames;
    public GameObject[] teamA;
    public GameObject[] teamB;
    public GameObject[] spawnLocs;
    public UIManager uiM;
    private int SpawnTracker;
    public TextBox textBox;
    private string message;
    private bool simulate = true;


    // Start is called before the first frame update
    void Start()
    {


        //this updates the health bar on damge taken during fighting scene
        uiM = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if (uiM != null)
        {

            uiM.AssignBars(teamA);
            uiM.AssignBars(teamB);
            uiM.UpdateBars();

        }


    }

    void Update()
    {
        if (simulate)
        {

            simulate = false;
            switch (gState)
            {
                //prepares the fighters (creates teams and places players within)
                case GameState.prep:
                    message = "Preparing...";
                    teamA = CreateTeam(teamA);
                    teamB = CreateTeam(teamB);

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.create));
                    break;


                //places the teams into the game in specific spots 
                case GameState.create:
                    message = "Creating Teams....";
                    GameObject[] CreateTeam(GameObject[] incTeam)
                    {
                        incTeam = new GameObject[teamSize];
                        for (int i = 0; i < teamSize; i++)
                        {
                            GameObject go = Instantiate(fighterPrefab, spawnLocs[SpawnTracker].transform.position, transform.rotation);
                            SpawnTracker++;

                            incTeam[i] = go;

                            go.GetComponent<Character>().UpdateName(fighterNames[Random.Range(0, fighterNames.Length)]);

                        }

                        return incTeam;
                    }

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.pick));
                    break;
                
                    //randomly selects 1 fighter out of each team to fight one another then, selects another.
                case GameState.pick:
                    message = "Picking fighters!";
                    //Figure out code to call fighters in here

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.fight));
                    break;

                 
                case GameState.fight:
                    //random fighter selected to fight
                    GameObject randomA = teamA[Random.Range(0, teamSize)];
                    GameObject randomB = teamB[Random.Range(0, teamSize)];

                    Fight(randomA, randomB);


                    break;

                    //Determines what team has the most amount of players left
                case GameState.result:
                    message = "The results are in!";

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.victory));
                    break;

                    //Announces the team that won
                case GameState.victory:
                    message = "And the winner is... ";

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    Application.Quit();
                    break;

            }
        }
    }

    public void Fight(GameObject fighterA, GameObject fighterB)
    {

        Character fAstats = fighterA.GetComponent<Character>();
        Character fBstats = fighterB.GetComponent<Character>();

        //if fighterA has faster speed they will attack first otherwise fighterB will attack first
        if (fAstats.speed < fBstats.speed)
        {
            // Mathf.Clamp(variable, minimumValue, MaximumValue
            int dmg = fAstats.attack - fBstats.defense;
            dmg = Mathf.Clamp(dmg, 1, fAstats.attack);

            fBstats.health -= dmg;

            Debug.Log("Fighter A attacks Fighter B");
            Debug.Log("Fighter B's health is now: " + fBstats.health);

        }

        else
        {
            int dmg = fBstats.attack - fAstats.defense;
            dmg = Mathf.Clamp(dmg, 1, fBstats.attack);

            fAstats.health -= dmg;

            Debug.Log("Fighter B attacks Fighter A");
            Debug.Log("Fighter A's Health is now: " + fBstats.health);
        }

        //if health is 0 we have a winner
        if (fBstats.health <= 0)
        {

            StartCoroutine(TransitionTimer(2f, GameState.result));

        }

        //no team is fully eliminated fight continues
        else
        {

            StartCoroutine(TransitionTimer(2f, GameState.fight));

        }

        //if health is 0 we have a winner
        if (fAstats.health <= 0)
        {

            StartCoroutine(TransitionTimer(2f, GameState.result));

        }
        
        //no team is fully eliminated fight continues
        else
        {

            StartCoroutine(TransitionTimer(2f, GameState.fight));

        }

    }


    IEnumerator TransitionTimer(float delay, GameState newState)
    {

        //the timer takes a delay, and determines what state we want to switch to
        yield return new WaitForSeconds(delay);

        //set the new state
        gState = newState;

        //Let the code run again
        simulate = true;

    }

    public void ButtonPressed()
    {

        int rand = Random.Range(0, 7);

        if (rand >= 3)
        {
            teamB[Random.Range(0, teamSize)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));

        }

        else
        {

            teamA[Random.Range(0, teamSize)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));

        }

        if (uiM != null)
        {

            uiM.UpdateBars();

        }

        int killed = 0;
        for (int i = 0; i < teamSize; i++)
        {

            if (teamA[i].GetComponent<Stats>().health <= 0)
            {

                killed++;

            }
        }

        if (killed >= 3)
        {

            Debug.Log("Team A is defeated!");
            Application.Quit();

        }

        killed = 0;

        for (int x = 0; x < teamSize; x++)
        {

            if (teamB[x].GetComponent<Stats>().health <= 0)
            {

                killed++;

            }

        }

        if (killed >= 3)
        {

            Debug.Log("Team B is defeated!");
            Application.Quit();

        }
    }
}





