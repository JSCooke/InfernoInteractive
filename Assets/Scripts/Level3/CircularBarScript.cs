using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularBarScript : MonoBehaviour {

    public GameObject robot;
    public GameObject deathAnimation;
    public Image circularBar;
    public float speed;
	public GameObject countdownBarCanvas;
    public bool startCountdown;
    public GameObject door;
    public GameObject orb;
    public GameObject redLight, greenLight;

    void Start () {
        circularBar.fillAmount = 1;
        circularBar.color = Color.yellow;
    }

	void Update () {
        
		if (startCountdown) {
            robot.SetActive(true);
            StartCountdownHealthBar();
        }

        //Make the health bar appear below the specified enemy
        Vector3 newPosition = robot.transform.position;
        newPosition.y = (float)1.5;
        transform.position = Camera.main.WorldToScreenPoint(newPosition);

        //Reset all values when health bar runs out
        if (circularBar.fillAmount == 0)
        {
            countdownBarCanvas.GetComponent<Canvas>().enabled = false;
            ((CircularBarScript)countdownBarCanvas.GetComponentInChildren(typeof(CircularBarScript))).startCountdown = false;
            circularBar.fillAmount = 1;

            robot.SetActive(false);
            //Explosion animation
			SoundAdapter.playBombSound();
            Instantiate(deathAnimation, robot.transform.position, robot.transform.rotation);
            for(int i = 0; i < 10; i++) {
                Instantiate(deathAnimation, robot.transform.position + (Random.RandomRange(-20, 20) * Vector3.forward) + (Random.RandomRange(-20, 20) * Vector3.left), robot.transform.rotation);
            }
            DropOrb();
            UIAdapter.damagePlayer(5);
        }
    }

    void StartCountdownHealthBar()
    {
        //Change colour from green to red
        circularBar.color = Color.Lerp(Color.red, Color.yellow, circularBar.fillAmount);

        //Make health bar empty/unfill to representing a timer running out
        circularBar.fillAmount = circularBar.fillAmount - speed * Time.deltaTime;
    }

    void DropOrb()
    {
        Collider[] colliders = Physics.OverlapSphere(robot.transform.position, 100f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Player")
            {
                if (this.tag.Equals("Left"))
                {
                    ((BossDoorController)door.GetComponent(typeof(BossDoorController))).redOrb = false;
                    UIAdapter.setRedOrbActive(false);
                    redLight.SetActive(true);
                    
                }
                else
                {
                    ((BossDoorController)door.GetComponent(typeof(BossDoorController))).greenOrb = false;
                    UIAdapter.setGreenOrbActive(false);
                    greenLight.SetActive(true);
                }
                orb.SetActive(true);
            }
        }
    }
}
