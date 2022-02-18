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
         if(Input.GetKeyDown(KeyCode.Space))
        {
            GainProgress(speed);

        }
    }

    public void GainProgress(float progress)
    {
        curLapProgress += progress;
        Debug.Log("Progress Gained" + progress);
        Debug.Log("Current Progress is: " + curLapProgress);
    }

}
