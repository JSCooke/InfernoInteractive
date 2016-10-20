using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlStationController : MonoBehaviour {
	public ParticleSystem glowParticles;

	private List<UnityEngine.GameObject> hoveringPlayers = new List<UnityEngine.GameObject>();

	public UnityEngine.GameObject attachedPlayer;
	private PlayerController attachedPlayerController;

	private ControlStationBehaviour controlStationBehaviour;
	public ControlStationBehaviour behaviour{ get { return controlStationBehaviour; } }
	
	// Use this for initialization
	void Start () {
		controlStationBehaviour = GetComponent<ControlStationBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void attachPlayer(UnityEngine.GameObject player){
		attachedPlayer = player;
		attachedPlayerController = player.GetComponent<PlayerController> ();
		
		behaviour.onAttachPlayer (player);

		glowParticles.enableEmission = false;
	}

	public void detachPlayer(){	
		behaviour.onDetachPlayer (attachedPlayer);
		attachedPlayer = null;
		attachedPlayerController = null;

		glowParticles.enableEmission = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			glowParticles.enableEmission = true;
			hoveringPlayers.Add (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			hoveringPlayers.Remove (other.gameObject);
			if (hoveringPlayers.Count == 0) {
				glowParticles.enableEmission = false;
			}
		}
	}
}
