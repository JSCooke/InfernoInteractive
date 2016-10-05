using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogManagerVer2 : MonoBehaviour
{

	public GameObject textBox;
	public Text inputText;
	public Image dialogueImage;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLineNumber;
	public int endLineNumber;

	public bool isActive;

	//List of different sprites
	public Sprite Jessie;
	public Sprite James;
	public Sprite GeneralWatson;
	public Sprite Soldier;
	public Sprite InformativeText;


	private Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
	private string[] sentance;

	// Use this for initialization
	void Start()
	{
		//hashmap for strings -> sprites

		sprites.Add("Jessie", Jessie);
		sprites.Add("James", James);
		sprites.Add("General Watson", GeneralWatson);
		sprites.Add("Soldier", Soldier);
		sprites.Add("Informative text", InformativeText);

		if (textFile != null)
		{
			//put each new line in array element
			textLines = (textFile.text.Split('\n'));
		}

		//if end line isnt inputted default to all lines
		if (endLineNumber == 0)
		{
			endLineNumber = textLines.Length - 1;
		}

		if (isActive)
		{
			EnableDialogBox();
		}
		else
		{
			DisableDialogBox();
		}


	}

	void Update()
	{
		if (isActive)
		{
			if (currentLineNumber <= endLineNumber)
			{
				//get the current line
				inputText.text = textLines[currentLineNumber];
				//split the sentence
				sentance = (inputText.text.Split(':'));
				//get the next sprite and set it
				Sprite nextSprite;
				sprites.TryGetValue(sentance[0], out nextSprite);
				dialogueImage.sprite = nextSprite;

				if (Input.GetKeyUp(KeyCode.Return))
				{
					currentLineNumber++;
				}

			}

			if (currentLineNumber > endLineNumber)
			{
				DisableDialogBox();
			}
		}

	}

	public void EnableDialogBox()
	{
		textBox.SetActive(true);
		isActive = true;
	}


	public void DisableDialogBox()
	{
		textBox.SetActive(false);
		isActive = false;
	}

	public void ReloadScript(TextAsset theText)
	{
		if (theText != null)
		{
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}
	}


}