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
	public AudioClip tankHitSound;
	public static AudioClip myTankHitSound;
	public AudioClip bombSound;
	public static AudioClip myBombSound;

	public AudioSource BGM;
	public static AudioSource myBGM;
	public static float soundVolume = 1;

	public float Soundvolume {
		get {
			return soundVolume;
		}
		set {
			soundVolume = value;
		}
	}

	public static float musicVolume = 1;

	public float MusicVolume {
		get {
			return musicVolume;
		}
		set {
			musicVolume = value;
		}
	}

	void Start ()
	{
		myCannonMk1Sound = cannonMk1Sound;
		myMachineGunMk1Sound = machineGunMk1Sound;
		myShieldUpSound = shieldUpSound;
		myShieldDownSound = shieldDownSound;
		myBossSquishSound = bossSquishSound;
		myTankHitSound = tankHitSound;
		myBGM = BGM;
		myBombSound = bombSound;
	}

	void Update()
	{
		myBGM.volume = musicVolume;
	}

	public static void playCannonMk1Sound (){
		AudioSource.PlayClipAtPoint (myCannonMk1Sound, Camera.main.transform.position, soundVolume);
	}
	public static void playMachineGunMk1Sound (){
		AudioSource.PlayClipAtPoint (myMachineGunMk1Sound, Camera.main.transform.position, soundVolume);
	}
	public static void playShieldUpSound (){
		AudioSource.PlayClipAtPoint (myShieldUpSound, Camera.main.transform.position, soundVolume);
	}
	public static void playShieldDownSound (){
		AudioSource.PlayClipAtPoint (myShieldDownSound, Camera.main.transform.position, soundVolume);
	}
	public static void playTankHitSound (){
		AudioSource.PlayClipAtPoint (myTankHitSound, Camera.main.transform.position, soundVolume);
	}
	public static void playBombSound(){
		AudioSource.PlayClipAtPoint(myBombSound, Camera.main.transform.position, soundVolume);
	}
	public static void playBossSquishSound (Vector3 location){
		AudioSource.PlayClipAtPoint (myBossSquishSound, Camera.main.transform.position, soundVolume);
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

