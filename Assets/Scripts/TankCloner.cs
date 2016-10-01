using UnityEngine;
using System.Collections;

public class TankCloner : MonoBehaviour {
	public GameObject original;
	public bool isClone = false;
	//Make a clone of the tank which doesn't move to use for simulating in-tank physics
	void Start () {
		print (isClone);
		if (!isClone) {
			//If this is the original, make a copy
			GameObject clone = (GameObject)Instantiate (gameObject, new Vector3 (0, -99999, 0), new Quaternion ());
			clone.GetComponent<TankCloner> ().isClone = true;
			clone.GetComponent<TankCloner> ().original = gameObject;
		} else {
			//If this is a clone, disable all mesh renderers
			foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>()) {
				renderer.enabled = false;
			}
			//set rigidbody to kinematic and disable movement
			GetComponent<Rigidbody> ().isKinematic = true;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;

			//Disable all scripts except the player controllers and control station controllers
			foreach (MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>()) {
				if (script.GetType () != typeof(PlayerController) && 
				    script.GetType () != typeof(ControlStationController) && 
				    !script.GetType ().IsSubclassOf(typeof(ControlStationBehaviour))) {
					script.enabled = false;
				}
			}

			//Add proxy movement controllers to the 'real' players so that their movement is determined by the clone ones instead
			for (int i=0; i<2; i++) {
				//Get the original player and player controller
				PlayerController originalPlayerController = original.GetComponentsInChildren<PlayerController> () [i];
				GameObject originalPlayer = originalPlayerController.gameObject;

				///Get the clone player and player controller
				PlayerController clonePlayerController = GetComponentsInChildren<PlayerController> () [i];
				GameObject clonePlayer = clonePlayerController.gameObject;

				//Disable movement input on the original
				originalPlayerController.enableMovement = false;

				//Add a proxy controller on the original
				ProxyPlayerController proxyController = original.GetComponentsInChildren<PlayerController> () [i].gameObject.AddComponent<ProxyPlayerController> ();

				//link it with the clone
				proxyController.original = clonePlayer;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
