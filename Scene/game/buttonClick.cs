using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonClick : MonoBehaviour {

    InputField hint;
    InputField hintCount;
    Button btn;

    // Use this for initialization
    void Start() { 
        btn = GameObject.Find("submitBtn").GetComponent<Button>();
        hint = GameObject.Find("hint").GetComponent<InputField>();
        hintCount = GameObject.Find("hintCount").GetComponent<InputField>();
        btn.onClick.AddListener(delegate
        {
            if (hint.text == "" || hintCount.text == "")
                Debug.Log("a field is empt");
        });
    }
	
	// Update is called once per frame
	void Update () {
    }
}
