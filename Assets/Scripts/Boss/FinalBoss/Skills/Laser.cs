using UnityEngine;
using System.Collections;

public class Laser : Skill {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Laser() { }

    public Laser(GameObject player, GameObject enemy) : base(player, enemy) { }
}
