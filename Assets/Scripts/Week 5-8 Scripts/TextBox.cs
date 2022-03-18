using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public Text textComp;
    public List<string> textLines;
    private string curText;



    // Start is called before the first frame update
    void Start()
    {

        textComp = GetComponent<Text>();

    }

    public void NewMessage(string message)
    {

    //check if we already have 4 lines
    if (textLines.Count >= 4)
      {
            //if so make room
            textLines.RemoveAt(0);
      }

        //"\n" creates a new line in a text box
        textLines.Add(message + "\n");

        //reset the text variable to store new lines
        curText = " ";

        //add each of our lines to our curText variable
        for (int i = 0; i < textLines.Count; i++)
        {

            curText += textLines[i];

        }

        //set the textbox to display our curText variable
        textComp.text = curText;

    }

}
