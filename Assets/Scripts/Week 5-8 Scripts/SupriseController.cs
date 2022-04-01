using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupriseController : MonoBehaviour
{
    private void OnEnable()
    {

        EventManager.OnZ += SurpriseAction;

    }


    void SurpriseAction()
    {
        float size = Random.Range(0.3f, 2f);
        this.transform.localScale = new Vector3(size, size, size);


    }





}
