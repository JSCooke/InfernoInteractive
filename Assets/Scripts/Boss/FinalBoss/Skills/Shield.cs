﻿using UnityEngine;
using System.Collections;

public class Shield : Skill {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (performSkill){
            invulnerable();
        }
	}

    public Shield() { }

    public Shield(GameObject player, GameObject enemy) : base(player, enemy) { }

    void invulnerable() {

    }
}
