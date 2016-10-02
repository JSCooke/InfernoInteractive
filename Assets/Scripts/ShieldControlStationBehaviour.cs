using UnityEngine;
using System.Collections;

public class ShieldControlStationBehaviour : ControlStationBehaviour {
	public GameObject shield;
	public TextMesh cooldownIndicator;
	public float cooldown, shieldDuration;
	public Color blue, red;

	private float cooldownRemaining, shieldDurationRemaining;
	// Use this for initialization
	void Start () {
		//Find the shield in the tank object
		shield = GetComponentInParent<TankController> ().transform.Find ("Shield").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining = Mathf.Max (0, cooldownRemaining);
		cooldownIndicator.text = Mathf.Ceil (cooldownRemaining) + "";
		cooldownIndicator.color = Color.Lerp (Color.blue, Color.red, cooldownRemaining / cooldown);

		shieldDurationRemaining = Mathf.Max (0, shieldDurationRemaining);
		if (shieldDurationRemaining == 0) {
			shield.SetActive (false);
		}
	}

	void FixedUpdate(){
		//Doing this on fixedupdate so that pausing (timescale=0) also pauses this
		cooldownRemaining -= Time.fixedDeltaTime;
		shieldDurationRemaining -= Time.fixedDeltaTime;
	}

	public override void onAttachPlayer(GameObject player){
		print (cooldownRemaining);
		if (cooldownRemaining <= 0) {
			shieldDurationRemaining = shieldDuration;
			shield.SetActive (true);
			cooldownRemaining = cooldown;
		}
		player.GetComponent<PlayerController> ().detach ();
	}
}
