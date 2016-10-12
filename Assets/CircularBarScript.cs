using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularBarScript : MonoBehaviour {

    public GameObject enemy;
    public Image circularBar;
    public float speed;
	public GameObject countdownBarCanvas;

    void Start () {
        circularBar.fillAmount = 1;
	}

	void Update () {
        //Change colour frome green to red
        circularBar.color = Color.Lerp(Color.red, Color.yellow, circularBar.fillAmount);

        //Make health bar empty/unfill to representing a timer running out
        circularBar.fillAmount = circularBar.fillAmount - speed*Time.deltaTime;

        //Make the health bar appear below the specified enemy
        Vector3 newPosition = enemy.transform.position;
        newPosition.y = (float)1.5;
        transform.position = Camera.main.WorldToScreenPoint(newPosition);

		if (circularBar.fillAmount == 0) {
			countdownBarCanvas.SetActive (false);
		}
    }
}
