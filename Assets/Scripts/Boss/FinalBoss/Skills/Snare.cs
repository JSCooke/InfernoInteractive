using UnityEngine;
using System.Collections;

public class Snare : SkillController {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Snare() { }

    public Snare(GameObject player, GameObject enemy) : base(player, enemy) {}
}
