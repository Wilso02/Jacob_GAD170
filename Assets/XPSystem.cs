using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    //System
    public int level; //laps
    public float curEXP;
    public float reqEXP; //reLapProgress
     

    //Stats
    public float health;
    public float defense;
    public float speed;
    public float attack;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to XP Simulator!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitalStates()
    {

        //Stats
        health = 20;
        defense = 15;
        speed = 10;
        attack = 5;


        //System
        level = 0;
        curEXP = 0;
        reqEXP = 50;

    }

    public void Interaction(float earnedExp)
    {

        //this is called by button presses, should grant a diff amount of exp

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GainExp(15);
            

        }

    }

    public void GainExp(float gain)
    {

        //gain ex, probably something to do with our curEXP
        curEXP += gain;
        Debug.Log("XP Gained" + gain);
        Debug.Log("Current XP is : " + curEXP);
        Debug.Log("Current Level is " + level);

        return;


    }

    public void LevelUp()
    {
        if (curEXP >= 50)
        {
            IncreaseStats();
            level += 1;
            curEXP = 0;
            
            Debug.Log("Next Level Achieved! Level" + level);

        }
    }

    public void IncreaseStats()
    {
        //increase our various stats
        
        {
            health += 5;
            defense += 5;
            speed += 5;
            attack += 5;
        }
    }
}

