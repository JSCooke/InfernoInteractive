using UnityEngine;
using System.Collections;

public class TriggerWall : MonoBehaviour {

	public GameObject[] countdownBarCanvases;

	void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            for (int i = 0; i < countdownBarCanvases.Length; i++)
            {
                countdownBarCanvases[i].GetComponent<Canvas>().enabled = true;

                //Start the robot's health bar countdown by getting script and enabling countdown boolean
                ((CircularBarScript)countdownBarCanvases[i].GetComponentInChildren(typeof(CircularBarScript))).startCountdown = true;
            }
        }
  	}

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < countdownBarCanvases.Length; i++)
            {
                //Reset all initial values when exiting the trigger field
                countdownBarCanvases[i].GetComponent<Canvas>().enabled = false;
                ((CircularBarScript)countdownBarCanvases[i].GetComponentInChildren(typeof(CircularBarScript))).startCountdown = false;
                ((CircularBarScript)countdownBarCanvases[i].GetComponentInChildren(typeof(CircularBarScript))).circularBar.fillAmount = 1;
            }
        }

    }
}
