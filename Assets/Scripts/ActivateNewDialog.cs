using UnityEngine;
using System.Collections;

public class ActivateNewDialog : MonoBehaviour {

	public UnityEngine.GameObject cutscene;
    public UnityEngine.GameObject mainCamera;

    public TextAsset theText;

    public int startLine = 0;
    public int endLine = 0;

    public DialogTextManager dialogManager;

    public bool destroyWhenActivated = true;

    public bool stopGameMovements;

    private QuickCutsceneController cutsceneController;
    public int lineNumber;

	//potential spawner
	public bool shouldSpawn = false;
	public Spawnable spawningObject; 

    // Use this for initialization
    void Start () {
        dialogManager = FindObjectOfType<DialogTextManager>();
		if (cutscene != null) {
			cutsceneController = cutscene.GetComponent<QuickCutsceneController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Tank")
        {
            if(stopGameMovements == true)
            {
                dialogManager.stopGameMovements = true;
            }
            else
            {
                dialogManager.stopGameMovements = false;
            }

            dialogManager.ReloadScript(theText);
            dialogManager.currentLineNumber = startLine;
            dialogManager.endLineNumber = endLine;
            dialogManager.SetCutscene(mainCamera, cutsceneController, lineNumber);
            dialogManager.EnableDialogBox();

			if (shouldSpawn == true) {
				dialogManager.shouldSpawn = true;
				dialogManager.spawningObject = spawningObject;
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
        }
    }

}
