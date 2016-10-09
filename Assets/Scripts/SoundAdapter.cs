using UnityEngine;
using System.Collections;

public class SoundAdapter : MonoBehaviour
{
	public AudioClip cannonMk1Sound;
	public static AudioClip myCannonMk1Sound;
	public AudioClip machineGunMk1Sound;
	public static AudioClip myMachineGunMk1Sound;
	// Use this for initialization
	void Start ()
	{
		myCannonMk1Sound = cannonMk1Sound;
		myMachineGunMk1Sound = machineGunMk1Sound;
	}

	public static void playCannonMk1Sound (){
		AudioSource.PlayClipAtPoint (myCannonMk1Sound, Camera.main.transform.position, 1);
	}
	public static void playMachineGunMk1Sound (){
		AudioSource.PlayClipAtPoint (myMachineGunMk1Sound, Camera.main.transform.position, 1);
	}
}

