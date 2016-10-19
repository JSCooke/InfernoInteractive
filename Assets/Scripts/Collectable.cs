using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public GameObject door;
    public string colourOfOrb;

    public GameObject redLight, greenLight;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponentInParent<TankController>() != null) {

            if(colourOfOrb.Equals("red"))
            {
				SoundAdapter.playCollectSound ();
				((BossDoorController)door.GetComponent(typeof(BossDoorController))).redOrb = true;
                UIAdapter.setRedOrbActive(true);
                redLight.SetActive(false);
            }
            else
            {
				SoundAdapter.playCollectSound ();
                ((BossDoorController)door.GetComponent(typeof(BossDoorController))).greenOrb = true;
                UIAdapter.setGreenOrbActive(true);
                greenLight.SetActive(false);
            }
                        
            //Do not destroy orb in case player drops orb and reappearing needs to occur
            this.gameObject.SetActive(false);
        }
    }

}
