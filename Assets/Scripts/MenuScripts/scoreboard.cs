using UnityEngine;
using UnityEngine.UI;
using System.Linq;
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
            easyPlayerInfo[i].Time = int.MaxValue;

            medPlayerInfo[i] = new PlayerInfo();
            medPlayerInfo[i].Name = "---";
            medPlayerInfo[i].Time = int.MaxValue;

            hardPlayerInfo[i] = new PlayerInfo();
            hardPlayerInfo[i].Name = "---";
            hardPlayerInfo[i].Time = int.MaxValue;
        }
    }
	
	void Update () {

        easyPlayerInfo = SortArray(easyPlayerInfo);
        medPlayerInfo = SortArray(medPlayerInfo);
        hardPlayerInfo = SortArray(hardPlayerInfo);

        for (int i = 0; i < easyPlayerInfo.Length; i++)
        {
            EasyNames[i].text = easyPlayerInfo[i].Name;
            if (easyPlayerInfo[i].Time != int.MaxValue)
            {
                EasyTimes[i].text = easyPlayerInfo[i].Time.ToString();
            }

            MedNames[i].text = medPlayerInfo[i].Name;
            if (medPlayerInfo[i].Time != int.MaxValue)
            {
                MedTimes[i].text = medPlayerInfo[i].Time.ToString();
            }

            HardNames[i].text = hardPlayerInfo[i].Name;
            if (hardPlayerInfo[i].Time != int.MaxValue)
            {
                HardTimes[i].text = hardPlayerInfo[i].Time.ToString();
            }
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

        playerInfo[5].Name = Name;
        playerInfo[5].Time = System.Int32.Parse(inputTime.text);
    }

    PlayerInfo[] SortArray(PlayerInfo[] playerInfo)
    {
        playerInfo = playerInfo.OrderBy(x => x.Time).ToArray();
        return playerInfo;
    }

    public class PlayerInfo
    {
        public string Name;
        public int Time;
    }
}
