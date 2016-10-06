using UnityEngine;
using System.Collections;

public abstract class ControlStationBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public virtual void onAttachPlayer(UnityEngine.GameObject player){}
	public virtual void onDetachPlayer(UnityEngine.GameObject player){}
	public virtual void keyPressed (bool up, bool left, bool down, bool right){}
	public virtual void keyHeld(bool up, bool left, bool down, bool right){}
	public virtual void keyReleased(bool up, bool left, bool down, bool right){}
}
