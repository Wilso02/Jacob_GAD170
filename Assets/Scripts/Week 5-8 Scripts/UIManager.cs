using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Slider> hpBars;
    public List<Stats> charStats;

  private void Awake()
    {

        
        charStats = new List<Stats>();

    }

    public void AssignBars(GameObject[] incteam)
    {

        for(int i = 0; i < incteam.Length; i++)
        {

            charStats.Add(incteam[i].GetComponent<Stats>());

        }

    }

    public void UpdateBars()
    {

        for(int i = 0; i < hpBars.Count; i++)
        {

            //slider value is between 0.0 and 1.0
            float percent = charStats[i].health / 100f;
            hpBars[i].value = percent;


        }

    }


}
