using UnityEngine;
using System.Collections;

public class MeteorStrike : MonoBehaviour {

    public GameObject meteor, player;
    public bool aiming  = true;
    private float startTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (aiming) {
            startTime = UIAdapter.getTimeInSeconds();
            aiming = false;
            aimAnimation();
        } else {
            cooldown();
        }
    }

    public MeteorStrike() { }

    void aimAnimation() {

        float radius = 5f;
		SoundAdapter.playFrogSound ();
        //this.GetComponent<BossController>().difficulty
        for (int i = 0; i < 2; i++) {

            //Referenced from http://answers.unity3d.com/questions/1068513/place-8-objects-around-a-target-gameobject.html
            //float angle = i * Mathf.PI * 2f / this.GetComponent<BossController>().difficulty;
            float angle = i * Mathf.PI * 2f / 2;
            Vector3 newPos = new Vector3(player.transform.position.x + Mathf.Cos(angle) * radius, 0, player.transform.position.z + Mathf.Sin(angle) * radius);

            GameObject child = (GameObject)Instantiate(meteor, newPos, Quaternion.identity);
        }

    }

    void cooldown() {

        //(float)this.GetComponent<FinalBossBehaviour>().chargeDuration
        if (UIAdapter.getTimeInSeconds() - startTime > 3) {
            this.gameObject.SetActive(false);
            aiming = true;
           // GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().randomNextAction(true);
        }
    }

}
