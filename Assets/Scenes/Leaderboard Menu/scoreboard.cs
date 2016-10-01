using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreboard : MonoBehaviour {

    //TODO remove
    public Dropdown dropdown;
    public Text inputName;
    public Text inputTime;

    public Text[] EasyNames;
    public Text[] EasyTimes;
    public Text[] MedNames;
    public Text[] MedTimes;
    public Text[] HardNames;
    public Text[] HardTimes;
    public PlayerInfo[] easyPlayerInfo = new PlayerInfo[6];
    public PlayerInfo[] medPlayerInfo = new PlayerInfo[6];
    public PlayerInfo[] hardPlayerInfo = new PlayerInfo[6];

    void Start () {
	    for (int i = 0; i < easyPlayerInfo.Length; i++)
        {
            easyPlayerInfo[i] = new PlayerInfo();
            easyPlayerInfo[i].Name = "---";
            easyPlayerInfo[i].Time = "--:--";

            medPlayerInfo[i] = new PlayerInfo();
            medPlayerInfo[i].Name = "---";
            medPlayerInfo[i].Time = "--:--";

            hardPlayerInfo[i] = new PlayerInfo();
            hardPlayerInfo[i].Name = "---";
            hardPlayerInfo[i].Time = "--:--";
        }
    }
	
	void Update () {
	    for (int i = 0; i < easyPlayerInfo.Length; i++)
        {
            EasyNames[i].text = easyPlayerInfo[i].Name;
            EasyTimes[i].text = easyPlayerInfo[i].Time;

            MedNames[i].text = medPlayerInfo[i].Name;
            MedTimes[i].text = medPlayerInfo[i].Time;

            HardNames[i].text = hardPlayerInfo[i].Name;
            HardTimes[i].text = hardPlayerInfo[i].Time;
        }
    }

    public void addScore()
    {
        PlayerInfo[] playerInfo;
        string Name = inputName.text.ToUpper();

        if (dropdown.value == 0) { playerInfo = easyPlayerInfo; }
        else if (dropdown.value == 1) { playerInfo = medPlayerInfo; }
        else { playerInfo = hardPlayerInfo; }

        if (Name == null || Name.Trim().Length == 0) { Name = "CIA"; }

        playerInfo[0].Name = Name;
        playerInfo[0].Time = inputTime.text;
    }

    public class PlayerInfo
    {
        public string Name;
        public string Time;
    }
}
