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
    public GameObject randomA;
    public GameObject randomB;
    public GameObject[] spawnLocs;
    public UIManager uiM;

    private int SpawnTracker;
    public TextBox textBox;
    private string message;

    public float deadTeamA = 0f;
    public float deadTeamB = 0f;
    

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

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.create));
                    break;


                //places the teams into the game in specific spots 
                case GameState.create:
                    message = "Creating Teams....";
                    teamA = CreateTeam(teamA);
                    teamB = CreateTeam(teamB);

                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.pick));
                    break;
                
                    //randomly selects 1 fighter out of each team to fight one another then, selects another.
                case GameState.pick:
                    message = "Picking fighters!";

                    //Figure out code to call fighters in here
                    randomA = teamA[Random.Range(0, teamSize)];
                    randomB = teamB[Random.Range(0, teamSize)];

                    if (randomA.GetComponent<Character>().health <= 0 | randomB.GetComponent<Character>().health <= 0)
                    {
                        message = "Picking a Different Fighter...";
                        Debug.Log(message);
                        StartCoroutine(TransitionTimer(0f, GameState.pick));
                    }
                    else
                    {

                        StartCoroutine(TransitionTimer(2f, GameState.fight));

                    }
                    break;

                 
                case GameState.fight:
                    //random fighter selected to fight
                    Fight(randomA, randomB);

                    break;

                    //Determines what team has the most amount of players left
                case GameState.result:
                    if (deadTeamA == 3f)
                    {

                        StartCoroutine(TransitionTimer(2f, GameState.victory));

                    }
                    if (deadTeamB == 3f)
                    {

                        StartCoroutine(TransitionTimer(2f, GameState.victory));

                    }
                    if (deadTeamA != 3f && deadTeamB != 3f)
                    {
                        message = "Picking Fighters...";
                        StartCoroutine(TransitionTimer(2f, GameState.pick));
                    }
                    break;

                //Announces the team that won
                case GameState.victory:
                    if (deadTeamA == 3f)
                    {
                        message = "Team B wins";
                        Debug.Log(message);
                        textBox.NewMessage(message);
                    }

                    if (deadTeamB == 3f)
                    {
                        message = "Team A wins";
                        Debug.Log(message);
                        textBox.NewMessage(message);
                    }

                    message = "Victory?";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    Application.Quit();
                    break;

            }
        }
    }

    public GameObject[] CreateTeam(GameObject[] incTeam)
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

    public void Fight(GameObject fighterA, GameObject fighterB)
    {
        int coinflip = Random.Range(0, 2);
        Character fAStats = fighterA.GetComponent<Character>();
        Character fBStats = fighterB.GetComponent<Character>();

        if (coinflip == 0)
        {
            //fighterB.GetComponent<Character>().health -= fighterA.GetComponent<Character>().Attack - fighterB.GetComponent<Character>().defense;
            //defense > attack

            if (fBStats.defense >= fAStats.attack)
            {
                //if the defense is greater then the attack do nothing.
                message = "Fighter A tries to attack Fighter B";
                Debug.Log(message);
                textBox.NewMessage(message);
                fBStats.health = fBStats.health - (fAStats.attack - (fBStats.defense / 4));
                message = "Fighter B takes minimal damage, health is now " + fBStats.health;
                Debug.Log(message);
                textBox.NewMessage(message);

            }
            else
            {
                //if the defense is less then the attack decrease health
                fBStats.health = fBStats.health - (fAStats.attack - fBStats.defense);
                message = "Fighter A attacks Fighter B";
                Debug.Log(message);
                textBox.NewMessage(message);
                message = "Fighter B's health is now = " + fBStats.health;
                Debug.Log(message);
                textBox.NewMessage(message);
            }

            if (fBStats.health <= 0)
            {
                //if fighter B's health is 0 go to the results
                message = "Fighter A defeated Fighter B!";
                deadTeamB = deadTeamB + 1f;
                StartCoroutine(TransitionTimer(2f, GameState.result));
            }
            else
            {
                //if not battle again
                StartCoroutine(TransitionTimer(2f, GameState.fight));
            }

        }
        else
        {
            if (fAStats.defense >= fBStats.attack)
            {
                //if the defense is greater then the attack do nothing.
                message = "Fighter B tries to attack Fighter A";
                Debug.Log(message);
                textBox.NewMessage(message);
                fAStats.health = fAStats.health - (fBStats.attack - (fAStats.defense / 2));
                message = "Fighter A takes minimal damage, health is now " + fAStats.health;
                Debug.Log(message);
                textBox.NewMessage(message);

            }
            else
            {
                //if the defense is less then the attack decrease health
                fAStats.health = fAStats.health - (fBStats.attack - fAStats.defense);
                message = "Fighter B attacks Fighter A";
                Debug.Log(message);
                textBox.NewMessage(message);
                message = "Fighter A's health is now = " + fAStats.health;
                Debug.Log(message);
                textBox.NewMessage(message);
            }

            if (fAStats.health <= 0)
            {
                //if fighter A's health is 0 go to the results
                message = "Fighter B defeated Fighter A!";
                deadTeamA = deadTeamA + 1f;
                StartCoroutine(TransitionTimer(2f, GameState.result));
            }
            else
            {
                //if not battle again
                StartCoroutine(TransitionTimer(2f, GameState.fight));
            }
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





