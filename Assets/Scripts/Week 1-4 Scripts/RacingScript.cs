using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingScript : MonoBehaviour
{

    int laps = 0;

    float curLapProgress = 0f;
    float reqLapProgress = 100f;

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainProgress(speed);

        }
    }

    public void GainProgress(float progress)
    {
        curLapProgress += progress;
        Debug.Log("Progress Gained" + progress);
        Debug.Log("Current Progress is: " + curLapProgress);
        CheckProgress(curLapProgress);
    }

    public void CheckProgress(float progress)
    {
        if (progress >= reqLapProgress)
        {

            //Completed a lap!
            LapCompleted();
            Debug.Log("Required Progress Achieved!");

        }
    }

    public void LapCompleted()
    {
        //Update Laps
        laps += 1;

        //reset our current lap progress
        curLapProgress = 0f;

        //either increase our required lap progress, or change our speed
        reqLapProgress *= 1.15f;
        Debug.Log("Lap Completed");
        Debug.Log("Laps Completed: " + laps);
    }


}
