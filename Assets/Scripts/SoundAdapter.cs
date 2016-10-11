using UnityEngine;
using System.Collections;

public class SoundAdapter : MonoBehaviour
{
	public AudioClip cannonMk1Sound;
	public static AudioClip myCannonMk1Sound;
	public AudioClip machineGunMk1Sound;
	public static AudioClip myMachineGunMk1Sound;
	public AudioClip shieldUpSound;
	public static AudioClip myShieldUpSound;
	public AudioClip shieldDownSound;
	public static AudioClip myShieldDownSound;
	public AudioClip bossSquishSound;
	public static AudioClip myBossSquishSound;


	void Start ()
	{
		myCannonMk1Sound = cannonMk1Sound;
		myMachineGunMk1Sound = machineGunMk1Sound;
		myShieldUpSound = shieldUpSound;
		myShieldDownSound = shieldDownSound;
		myBossSquishSound = bossSquishSound;
	}

	public static void playCannonMk1Sound (){
		AudioSource.PlayClipAtPoint (myCannonMk1Sound, Camera.main.transform.position, 1);
	}
	public static void playMachineGunMk1Sound (){
		AudioSource.PlayClipAtPoint (myMachineGunMk1Sound, Camera.main.transform.position, 1);
	}
	public static void playShieldUpSound (){
		AudioSource.PlayClipAtPoint (myShieldUpSound, Camera.main.transform.position, 1);
	}
	public static void playShieldDownSound (){
		AudioSource.PlayClipAtPoint (myShieldDownSound, Camera.main.transform.position, 1);
	}
	public static void playBossSquishSound (){
		AudioSource.PlayClipAtPoint (myBossSquishSound, Camera.main.transform.position, 1);
	}


	/*
	 * TO CREATE A NEW SOUND:
	 * 
	 * Add a new sound to the sound controller like above in the fields and start method, and drag and drop the audio file in.
	 * Create a method like the static ones above, which play the clip at a point.
	 * Call the method from anywhere to play the sound.
	 * 
	 * To make the sound follow the camera, you have to attach an AudioSource to an object and call play on it.
	 * To change background music, change the clip in the BGM object attached to the main camera.
	 */ 

}

