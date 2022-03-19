using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject fighterPrefab;
    public int teamSize = 3;
    public string[] fighterNames;
    public GameObject[] teamA;
    public GameObject[] teamB;

    // Start is called before the first frame update
    void Start()
    {
        teamA = CreateTeam(teamA);
        teamB = CreateTeam(teamB);

        GameObject randomA = teamA[Random.Range(0, teamSize)];
        GameObject randomB = teamB[Random.Range(0, teamSize)];
    }

    public GameObject[] CreateTeam(GameObject[] incTeam)
    {
        incTeam = new GameObject[teamSize];
        for (int i = 0; i < teamSize; i++)
        {
            GameObject go = Instantiate(fighterPrefab);

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

            fBstats.health -= fAstats.attack - fBstats.defense;
            Debug.Log("Fighter A attacks Fighter B");
            Debug.Log("Fighter B's health is now: " + fBstats.health);

        }

        else
        {
            fAstats.health -= fBstats.attack - fAstats.defense;
            Debug.Log("Fighter B attacks Fighter A");
            Debug.Log("Fighter A's Health is now: " + fBstats.health);
        }

    }

}
