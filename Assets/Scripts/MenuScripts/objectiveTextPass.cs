using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class objectiveTextPass : MonoBehaviour {

    static string objectiveDescription = "";
    Text objeText;

	// Use this for initialization
	void Start () {
        objeText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        objeText.text = objectiveDescription;
	}
}
