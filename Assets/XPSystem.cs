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
        InitialStates();
        
        Debug.Log("Welcome to Alien Attack! Press 'Spacebar' to begin!");
        Debug.Log("To view Level press 'T'! ");

        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You may decide your encounter! Press 'R' to fight a xenomorph or 'A' to fight a horde of headcrabs!");   
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("You have choosen to fight the Xenomorph! Good Luck!");
            AlienAttack();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("You have choosen to fight the Horde of Headcrabs! Good Luck!");
            HeadcrabAttack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Holy Moses! Thats the Queen Xenomorph! FIGHT! FIGHT! FIGHT!");
            QueenAttack();
        }

            if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Your current level is " + level);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LeaveInteraction();
        }

    }

    public void InitialStates()
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

   

    public void AlienAttack()
    {

            //Alien Attack
            Debug.Log("Flamethrower Activate!");
            alienHealth = alienHealth - attack;

            if (alienHealth <= 0)
            {
                Debug.Log("The xenomorph retreated, XP granted!, Press 'Spacebar to return' ");
                GainExp(25);
            }
   
            else
            {
                Debug.Log("Xenomorph at HP: " + alienHealth);
            }  
            
    }


    public void HeadcrabAttack()
    {

            //Headcrab Attack
            Debug.Log("Throwing a grenade!");
            headcrabHealth = headcrabHealth - attack;

            if (headcrabHealth <= 0)
            {
                Debug.Log("They're all just corpses now! XP Granted, Press 'Spacebar' to return or 'S' to investigate the rumbling. ");
                GainExp(30);
            }

            else
            {
               Debug.Log(" Keep throwing soilder! There's only a couple left! HP: " + headcrabHealth);
            }

    }


    public void QueenAttack()
    {

            Debug.Log("You shoot a rocket, at the Queen!");
            alienQueen = alienQueen - attack;

           if (alienQueen <= 0)
           {
            Debug.Log("The Queen has fallen! Well Done Soilder! Proceed to Exfil! Press 'Z' to Exfil");
            LeaveInteraction();
           }

           else
           {
            Debug.Log("The Queen still stands! Reload! Reload! HP: " + alienQueen);
           }

    }
        
    public void LeaveInteraction()
    { 
            Debug.Log("Congrats Soilder on making it outta their alive! However reports state theres another attack! Your level was " + level);
    }


    public void GainExp(float gain)
    {

        //gain ex, probably something to do with our curEXP
        curEXP += gain;
        Debug.Log("XP Gained " + gain);
        Debug.Log("Current XP is : " + curEXP);
        LevelUp();
        
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

