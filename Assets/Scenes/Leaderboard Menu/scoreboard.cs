using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreboard : MonoBehaviour {

    public Text[] EasyNames;
    public Text[] EasyTimes;
    public Text[] MedNames;
    public Text[] MedTimes;
    public Text[] HardNames;
    public Text[] HardTimes;
    public PlayerInfo[] easyPlayerInfo = new PlayerInfo[6];
    public PlayerInfo[] medPlayerInfo = new PlayerInfo[6];
    public PlayerInfo[] hardPlayerInfo = new PlayerInfo[6];

    public enum Difficulty { Easy, Medium, Hard };

    void Start () {
	    for (int i = 0; i < easyPlayerInfo.Length; i++)
        {
            easyPlayerInfo[i] = new PlayerInfo();
            easyPlayerInfo[i].Name = "---";
            easyPlayerInfo[i].Time = "--:--";
        }

        for (int i = 0; i < medPlayerInfo.Length; i++)
        {
            medPlayerInfo[i] = new PlayerInfo();
            medPlayerInfo[i].Name = "---";
            medPlayerInfo[i].Time = "--:--";
        }

        for (int i = 0; i < hardPlayerInfo.Length; i++)
        {
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
        }

        for (int i = 0; i < medPlayerInfo.Length; i++)
        {
            MedNames[i].text = medPlayerInfo[i].Name;
            MedTimes[i].text = medPlayerInfo[i].Time;
        }

        for (int i = 0; i < hardPlayerInfo.Length; i++)
        {
            HardNames[i].text = hardPlayerInfo[i].Name;
            HardTimes[i].text = hardPlayerInfo[i].Time;
        }
    }

    public class PlayerInfo
    {
        public string Name;
        public string Time;
        public Difficulty Diff;
    }
}
