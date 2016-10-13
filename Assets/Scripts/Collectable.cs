using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public GameObject door;
    public string colourOfOrb;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {

            if(colourOfOrb.Equals("red"))
            {
                ((BossDoorController)door.GetComponent(typeof(BossDoorController))).redOrb = true;
            }
            else
            {
                ((BossDoorController)door.GetComponent(typeof(BossDoorController))).greenOrb = true;
            }
                        
            //Do not destroy orb in case player drops orb and reappearing needs to occur
            this.gameObject.SetActive(false);
        }
    }

}
