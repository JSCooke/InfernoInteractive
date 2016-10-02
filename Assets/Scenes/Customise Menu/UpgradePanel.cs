using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradePanel : MonoBehaviour
{
    public Text Name;
    public Image Image;

    public void setName(string newName)
    {
        Name.text = newName;
    }
}

