using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogTextManager : MonoBehaviour {

    public GameObject textBox;
    public Text inputText;
    public Image dialogueImage;

    public TankController tank;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLineNumber;
    public int endLineNumber;

    public bool isActive;

    public bool stopGameMovements;

    //List of different sprites
    public Sprite Jessie;
    public Sprite James;
    public Sprite GeneralWatson;
    public Sprite Civilian1;
    public Sprite Civilian2;
    public Sprite Civilian3;
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
        sprites.Add("Civilian 1", Civilian1);
        sprites.Add("Civilian 2", Civilian2);
        sprites.Add("Civilian 3", Civilian3);
        sprites.Add("Informative text", InformativeText);

        tank = FindObjectOfType<TankController>();

        if (textFile != null)
        {
            //put each new line in array element
            textLines = (textFile.text.Split('\n'));
        }

        //if end line isnt inputted default to all lines
        if(endLineNumber == 0)
        {
            endLineNumber = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableDialogBox();
        } else
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

        if (stopGameMovements == true)
        {
			Time.timeScale = 0;
        }
    }


    public void DisableDialogBox()
    {
        if (stopGameMovements == true)
        {
			Time.timeScale = 1;
        }
        textBox.SetActive(false);
        isActive = false;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }


}
