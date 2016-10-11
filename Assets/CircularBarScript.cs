using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularBarScript : MonoBehaviour {

    [SerializeField]
    private Image circularBar;

	// Use this for initialization
	void Start () {
        circularBar.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
        circularBar.fillAmount = circularBar.fillAmount - (float)0.1*Time.deltaTime;
	}
}
