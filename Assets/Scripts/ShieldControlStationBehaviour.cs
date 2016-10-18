using UnityEngine;
using System.Collections;

public class ShieldControlStationBehaviour : ControlStationBehaviour {
	public UnityEngine.GameObject shield, cabin;
	public TankController tankController;
	public TextMesh cooldownIndicator;
	public float cooldown, shieldDuration;
	public Color blue, red;

	private float cooldownRemaining, shieldDurationRemaining;
	// Use this for initialization
	void Start () {
		//Find the shield in the tank object
		shield = GetComponentInParent<TankController> ().transform.Find ("Shield").gameObject;
		foreach (Transform t in GetComponentInParent<TankController>().GetComponentsInChildren<Transform>()) {
			if (t.gameObject.name == "Shield") {
				shield = t.gameObject;
				shield.SetActive (false);
			}
		}
		tankController = GetComponentInParent<TankController> ();
		cabin = tankController.transform.Find ("Cabin").gameObject;
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

	public override void onAttachPlayer(UnityEngine.GameObject player){
		print (cooldownRemaining);
		if (cooldownRemaining <= 0) {
			AchievementController.hasUsedShield = true;
			shieldDurationRemaining = shieldDuration;
			SoundAdapter.playShieldUpSound ();
			shield.SetActive (true);
			cooldownRemaining = cooldown;
		}
		player.GetComponent<PlayerController> ().detach ();
	}
		
}
