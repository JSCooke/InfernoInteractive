using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ddrController : MonoBehaviour {

	public GameObject[] spawners;
	public DiscoLightController discoLightController;

	//Dialogue things
	public TextAsset theText;

	public int startLine = 0;
	public int endLine = 0;

	public DialogTextManager dialogManager;

	public bool destroyWhenActivated = true;

	public bool stopGameMovements;

	public bool shouldSpawn = true;
	public Spawnable spawningObject; 


	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("ddrSpawner");
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Tank")
		{
                //fade to black??
				other.transform.position = transform.position;
				//fade from black
                other.GetComponent<TankController>().canMove = false;
                other.attachedRigidbody.velocity = new Vector3(0, 0, 0);


				//DIALOGUE SECtiON
				dialogManager.ReloadScript(theText);
				dialogManager.currentLineNumber = startLine;
				dialogManager.endLineNumber = endLine;
				dialogManager.stopGameMovements = stopGameMovements;
				dialogManager.EnableDialogBox();

				if (shouldSpawn == true) {
					dialogManager.shouldSpawn = true;
					dialogManager.spawningObject = spawningObject;
				} else {
					dialogManager.shouldSpawn = false;
				}

				//if end line isnt inputted default to all lines
				if (endLine == 0)
				{
					dialogManager.endLineNumber = dialogManager.textLines.Length - 1;
				}

				if (destroyWhenActivated)
				{
					Destroy(gameObject);
				}

				//DIALOGUE SECtiON
            

			//start the disco
			discoLightController.startDisco();
		}

	}

}
