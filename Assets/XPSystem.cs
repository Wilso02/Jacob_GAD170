using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    //System
    public int level; //laps
    public float curEXP; //curLapProgress
    public float reqEXP; //reLapProgress

    //Stats
    public float health;
    public float defense;
    public float speed;
    public float attack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitalStates()
    {

    //setup our stats, level, curexp, reqexp, etc...

    }

public void Interaction(float earnedExp)
{

    //this is called by button presses, should grant a diff amount of exp

}

public void GainExp(float gain)
{

    //gain ex, probably something to do with our curEXP

}

public void LevelUp()
{

    //increase our level

}

public void IncreaseStats()
{
    //increase our various stats

}

}
