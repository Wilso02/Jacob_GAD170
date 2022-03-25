using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStuff : MonoBehaviour
{
    public enum GameState
    {
        prep,
        pick,
        fight,
        result,
        victory
    }

    public GameState gState;
    public TextBox textBox;
    private string message;
    private bool simulate = true;


    // Update is called once per frame
    void Update()
    {
        if (simulate)
        {
            simulate = false;

            switch (gState)
            {
                case GameState.prep:
                    message = "Preparing....";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.pick));
                    break;

                case GameState.pick:
                    message = "Choose your fighter!!";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.fight));
                    break;

                case GameState.fight:
                    //if(RandomFighterA.Stats.Health > 0 && RandomFighter.B.Stats.Health > 0
                    //Both are alive, keep fighting
                    //Else one of them is dead, check wich one, and print the winner to the results
                    //Might be good to set a message  for attacks and health.
                    //A tip: message = "some random info" then call SendMessage so you can then send another
                    //line by setting message = "new info" again.
                    //you can put as many phases as you like, consider how much code you're writing

                    if(Random.Range(1, 20) >= 15)
                    {

                        message = "Fight is over!";
                        StartCoroutine(TransitionTimer(2f, GameState.result));

                    }

                    else
                    {

                        message = "Fighting!";
                        StartCoroutine(TransitionTimer(2f, GameState.fight));

                    }
                    
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;

                case GameState.result:
                    message = "We have a Winner.....";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.victory));
                    break;

                case GameState.victory:
                    message = "Game Over!";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;

            }
        }
    }

    IEnumerator TransitionTimer(float delay, GameState newState)
    {

        yield return new WaitForSeconds(delay);
        gState = newState;
        simulate = true;

    }



}
