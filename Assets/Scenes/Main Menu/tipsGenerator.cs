using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class tipsGenerator : MonoBehaviour {

    public Text tipText;

	// Use this for initialization
	void Start () {
        string[] tips = GenerateTips();

        System.Random rnd = new System.Random();
        int index = rnd.Next(tips.Length);

        tipText.text = "Tip: " + tips[index];
    }

    string[] GenerateTips()
    {
        string[] tips = new string[5];

        tips[0] = "Nananananananananananananananana BATMAN!";
        tips[1] = "I am vengeance. I am the night. I am Batman.";
        tips[2] = "To the Batmobile!";
        tips[3] = "'Tis just a flesh wound";
        tips[4] = "We are the knights who say 'Ni'";

        return tips;
    }
}
