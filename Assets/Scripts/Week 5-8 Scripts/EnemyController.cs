using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //this will run when object is enabled
    void OnEnable()
    {

        EventManager.OnZ += EnemyChange;

    }

    void EnemyChange()
    {
        Color c = new Color(Random.Range(0.4f, 1f),Random.Range(0.4f, 1f),Random.Range(0.4f, 1f));

        this.GetComponent<Renderer>().material.color = c;

    }

}
