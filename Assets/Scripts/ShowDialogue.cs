using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShowDialogue : MonoBehaviour {

	public bool hasDialogue;

	public TextAsset theText;
	public Canvas NextCanvas;

	public int startLine = 0;
	public int endLine = 0;

	public DialogManagerVer2 dialogManager;

	private bool dialogueShown = false;

    void Start() {
        //If there are bugs, check here
        if (this.gameObject.name == "LogoCanvas") {
            StartCoroutine(TimeOut());
        }
    }

	void Update()
	{
		if (this.GetComponent<Canvas>().enabled)
		{
			if (!dialogueShown && hasDialogue)
			{
				dialogueShown = true;

				dialogManager.ReloadScript(theText);
				dialogManager.currentLineNumber = startLine;
				dialogManager.endLineNumber = endLine;
				dialogManager.EnableDialogBox();

				//if end line isnt inputted default to all lines
				if (endLine == 0)
				{
					dialogManager.endLineNumber = dialogManager.textLines.Length - 1;
				}
			}

			if (Input.GetKeyUp(KeyCode.Return))
			{
				if (!hasDialogue || (hasDialogue && !dialogManager.isActive))
				{
					goToNext();
				}
			}
			else if (Input.GetKeyUp(KeyCode.Escape))
			{
				goToMain();
			}
		}
		
	}

    IEnumerator TimeOut() {
        yield return new WaitForSeconds(2);
        goToNext();
    }

	void goToNext()
	{
		if (NextCanvas == null)
		{
			goToMain();
		}
		else
		{
			NextCanvas.GetComponent<Canvas>().enabled = true;
			this.GetComponent<Canvas>().enabled = false;
		}
	}

	void goToMain()
	{
        // go to main scene
        SceneManager.LoadScene(1);
    }
}
