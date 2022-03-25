using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        prep,
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


    void Awake()
    {

        teamA = CreateTeam(teamA);
        teamB = CreateTeam(teamB);

        GameObject randomA = teamA[Random.Range(0, teamSize)];
        GameObject randomB = teamB[Random.Range(0, teamSize)];

    }
    // Start is called before the first frame update
    void Start()
    {

        uiM = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if(uiM != null)
        {

            uiM.AssignBars(teamA);
            uiM.AssignBars(teamB);
            uiM.UpdateBars();

        }


    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {

            GameObject randA = teamA[Random.Range(0, teamSize)];
            GameObject randB = teamB[Random.Range(0, teamSize)];

            randA.GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
            randB.GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));

            if (uiM != null)
            {

                uiM.UpdateBars();

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
        
        Character fAstats = fighterA.GetComponent<Character>();
        Character fBstats = fighterB.GetComponent<Character>();

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

        
    }

    public void ButtonPressed()
    {

        int rand = Random.Range(0, 7);

        if(rand >= 3)
        {
            teamB[Random.Range(0, teamSize)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));

        }

        else
        {

            teamA[Random.Range(0, teamSize)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));

        }

        if(uiM != null)
        {

            uiM.UpdateBars();

        }

        int killed = 0;
        for(int i = 0; i < teamSize; i++)
        {

                if (teamA[i].GetComponent<Stats>().health <= 0)
                {

                    killed++;
                
                }
        }

        if(killed >= 3)
        {

            Debug.Log("Team A is defeated!");
            Application.Quit();

        }

        killed = 0;

        for(int x = 0; x < teamSize; x++)
        {

            if(teamB[x].GetComponent<Stats>().health <= 0)
            {

                killed++;

            }

        }

        if(killed >= 3)
        {

            Debug.Log("Team B is defeated!");
            Application.Quit();

        }

    }

}
