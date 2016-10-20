using UnityEngine;
using System.Collections;

public class AutoDestroyParticleSystem : MonoBehaviour {

    public float delay;
	private ParticleSystem particleSystem;
    private float time;
	// Use this for initialization
	void Start () {
	    
		particleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
        //If delay is specified, destroy it after the delay or the particle finishing, whichever comes first
        time += Time.deltaTime;
        if(time>delay && delay != 0) {
            Destroy(gameObject);
        }
		if (particleSystem) {
			if (!particleSystem.IsAlive ()) {

				Destroy (gameObject);

			}
		}
	
	}
}
