using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    //System
    public int level; 
    public float curEXP;
    public float reqEXP; 
     

    //Stats
    public float health;
    public float defense;
    public float speed;
    public float attack;

    //Enemies Health
    float alienHealth;
    float headcrabHealth;
    float alienQueen;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Alien Attack! Press 'Spacebar' to begin!");
        Debug.Log("To view Level press 'T'! ");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitalStates()
    {
        //Enemies Health
        alienHealth = 50;
        headcrabHealth = 25;
        alienQueen = 100;


        //Stats
        health = 20;
        defense = 15;
        speed = 10;
        attack = 5;


        //System
        level = 0;
        curEXP = 0;
        reqEXP = 0;

    }

    public void Interaction()
    {

        //this is called by button presses, should grant a diff amount of exp
        // Spacebar begins the alien attack
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You may decide your encounter! Press '1' to fight a xenomorph or '2' to fight a horde of headcrabs!");
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Your current level is " + level);
        }
       

        //Alien Attack
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("You have encountered a Xenomorph, Press 'Q' to attempt to fight!");
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            // Help needed
            Debug.Log("Flamethrower Activate!");
            alienHealth = alienHealth - attack;

        }

        if (alienHealth <= 0)
        {
            Debug.Log("The xenomorph retreated, XP granted!, Press 'Spacebar to return' ");
            GainExp(25);
        }

        else
        {
            Debug.Log("Xenomorph at HP: " + alienHealth);
        }

        // Headcrab Horde Encounter
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("You have encountered a Horde of Headcrabs, Press 'W' to attempt to fight!");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Throwing a grenade!");
            headcrabHealth = headcrabHealth - attack;
        }

        if(headcrabHealth <=0)
        {
            Debug.Log("They're all just corpses now! XP Granted, Press 'Spacebar to return' ");
            GainExp(30);
            Debug.Log("What's that rumbling? Press '3' to investigate. ");
        }
        else
        {
            Debug.Log(" Keep throwing soilder! There's only a couple left!" + headcrabHealth);
        }


        //Boss Fight
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Holy Moses! Thats the Queen Xenomorph! Press 'E' to fight!");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You shoot a rocket, at the Queen!");
            alienQueen = alienQueen - attack;

        }

        if(alienQueen <=0)
        {
            Debug.Log("The Queen has fallen! Well Done Soilder! Proceed to Exfil! Press 'Z' to Exfil");

        }
        else
        {
            Debug.Log("The Queen still stands! Reload! Reload!" + alienQueen);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Congrats Soilder on making it outta their alive! However reports state theres another attack! Your level was " + level);
        }
            // Check with teacher on why it constantly runs
    }

    public void GainExp(float gain)
    {

        //gain ex, probably something to do with our curEXP
        curEXP += gain;
        Debug.Log("XP Gained " + gain);
        Debug.Log("Current XP is : " + curEXP);
        
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

