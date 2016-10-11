using UnityEngine;
using System.Collections;

public class Illusion : Skill {

    private bool left = true;

	// Use this for initialization
	void Start () {
	      
	}
	
	// Update is called once per frame
	void Update () {

	    if (performSkill) {
            illude();
        }
	}

    public Illusion() { }

    public Illusion(GameObject player, GameObject enemy) : base(player, enemy) { }

    void illude() {

        if (left)
            transform.Translate(Vector2.left * 5f * Time.deltaTime);
        else
            transform.Translate(-Vector2.left * 5f * Time.deltaTime);

        if (transform.position.x >= 4.0f) {
            left = false;
        }

        if (transform.position.x <= -4) {
            left = true;
        }

    }

}
