using UnityEngine;
using System.Collections;

public class Shield : Skill {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Shield() { }

    public Shield(GameObject player, GameObject enemy) : base(player, enemy) { }
}
