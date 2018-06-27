using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using codenamesAPI;

public class boardSetup : MonoBehaviour {
    Text[] word = new Text[25];
    Image[] tileColor = new Image[25];
    Image[] starter = new Image[3];

    InputField hint;
    Button submit;

    System.Random rnd = new System.Random();

    // 0: red   1: blue   2: white   3: black
    int[]  color = new int[] { 8, 8, 7, 1 };

    int temp;

	// Use this for initialization
	void Start () {
        //Decides which team starts first
        temp = rnd.Next(0, 2);
        color[temp]++;

        //initiallizes board
        hint = GameObject.Find("hint").GetComponent<InputField>();
        submit = GameObject.Find("submitBtn").GetComponent<Button>();

        for (int i = 0; i < 3; i++)
        {
            starter[i] = GameObject.Find("starter" + i.ToString()).GetComponent<Image>();
            if (temp == 0)
                starter[i].color = Color.red;
            else
                starter[i].color = Color.blue;
        }

	//create new connection for database
	Connector test = new Connector();
		
	for (int i = 0; i < 25; i++)
        {
            //sets board image
            int randCol = RandomColor();
            tileColor[i] = GameObject.Find("image" + i.ToString()).GetComponent<Image>();
            if (randCol == 0)
                tileColor[i].color = Color.red;
            else if (randCol == 1)
                tileColor[i].color = Color.blue;
            else if (randCol == 2)
                tileColor[i].color = Color.white;
            else
                tileColor[i].color = Color.black;

            //sets board words
            word[i] = GameObject.Find("word" + i.ToString()).GetComponent<Text>();
            word[i].text = test.getCard();
        	}
	}
	
	// Update is called once per frame
	void Update ()
    {       
        //ensures only one word is used for hint input
        if (hint.text.Contains(" "))
            hint.text = "";
	}
    
    int RandomColor()
    {
        int col;
        while(true)
        {
            col = rnd.Next(0, 4);
            if(color[col] != 0)
            {
                color[col]--;
                return col;
            }
        }
    }
}
