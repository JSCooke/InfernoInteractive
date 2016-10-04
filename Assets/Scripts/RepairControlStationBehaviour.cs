using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RepairControlStationBehaviour : ControlStationBehaviour {
	public TextMesh textPrompt;
	public int textPulseInterval;
	
	public string[] p1Buttons;
	public string[] p2Buttons;

	private int currentButton=0;
	private string currentPlayer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % textPulseInterval == 0) {
			if (textPrompt.fontStyle == FontStyle.Bold) {
				textPrompt.fontStyle = FontStyle.Normal;
			} else {
				textPrompt.fontStyle = FontStyle.Bold;
			}
		}
	}

	void setPrompt(){
		//Generate a new button to press (make sure it's different to the last one)
		int lastButton = currentButton;
		while (lastButton==currentButton) {
			currentButton = Random.Range (0, 4);
		}

		if (currentPlayer == "Player1") {
			textPrompt.text = p1Buttons [currentButton];
		}
		if (currentPlayer == "Player2") {
			textPrompt.text = p2Buttons [currentButton];
		}
	}

	void repair(){
		print ("repair");
		textPrompt.color = Color.black;
		setPrompt ();
	}

	void wrongButton(){
		print ("wrong button");
		textPrompt.color = Color.red;
	}

	public override void keyPressed (bool up, bool left, bool down, bool right){
		switch (currentButton) {
		case 0:
			if (up) {
				repair ();
			}
			if (left || down || right) {
				wrongButton ();
			}
			break;
		case 1:
			if (left) {
				repair ();
			}
			if (up || down || right) {
				wrongButton ();
			}
			break;
		case 2:
			if (down) {
				repair ();
			}
			if (up || left || right) {
				wrongButton ();
			}
			break;
		case 3:
			if (right) {
				repair ();
			}
			if (up || left || down) {
				wrongButton ();
			}
			break;
		}
	}

	public override void onAttachPlayer(UnityEngine.GameObject player){
		textPrompt.gameObject.SetActive (true);
		currentPlayer = player.name;
		setPrompt ();
	}

	public override void onDetachPlayer(UnityEngine.GameObject player){
		textPrompt.gameObject.SetActive (false);
		currentPlayer=null;
	}

}
