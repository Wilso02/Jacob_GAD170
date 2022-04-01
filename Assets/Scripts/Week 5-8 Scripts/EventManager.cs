using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void ZAction();
    public static event ZAction OnZ;

    public static void RunZ()
    {
        print("Pressed Z");
        OnZ();

    }


}
