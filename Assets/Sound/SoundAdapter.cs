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
	public AudioClip bossHitSound;
	public static AudioClip myBossHitSound;
	public AudioClip tankHitSound;
	public static AudioClip myTankHitSound;
	public AudioClip bombSound;
	public static AudioClip myBombSound;
	public AudioClip confettiSound;
	public static AudioClip myConfettiSound;
	public AudioClip minionSound;
	public static AudioClip myMinionSound;
	public AudioClip minionSwordSound;
	public static AudioClip myMinionSwordSound;
	public AudioClip popSound;
	public static AudioClip myPopSound;
	public AudioClip frogSound;
	public static AudioClip myFrogSound;
	public AudioClip frogAttackSound;
	public static AudioClip myFrogAttackSound;
	public AudioClip collectSound;
	public static AudioClip myCollectSound;
	public AudioClip fenceSound;
	public static AudioClip myFenceSound;
	public AudioClip hoverSound;
	public static AudioClip myHoverSound;
	public AudioClip clickSound;
	public static AudioClip myClickSound;

	public AudioSource BGM;
	public static AudioSource myBGM;
	public AudioClip altBGM;
	public static AudioClip myAltBGM;
	public AudioClip normalBGM;
	public static AudioClip myNormalBGM;

	public static float soundVolume = 1;

	public float SoundVolume {
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
		myBossHitSound = bossHitSound;
		myTankHitSound = tankHitSound;
		myBombSound = bombSound;
		myConfettiSound = confettiSound;
		myMinionSound = minionSound;
		myMinionSwordSound = minionSwordSound;
		myPopSound = popSound;
		myFrogSound = frogSound;
		myFrogAttackSound = frogAttackSound;
		myNormalBGM = normalBGM;
		myAltBGM = altBGM;
		myCollectSound = collectSound;
		myFenceSound = fenceSound;
		myClickSound = clickSound;
		myHoverSound = hoverSound;

		myBGM = BGM;
		myBGM.clip = myNormalBGM;
		myBGM.Play ();
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
		if (myTankHitSound != null)
		{
			AudioSource.PlayClipAtPoint(myTankHitSound, Camera.main.transform.position, soundVolume);
		}
	}
	public static void playBombSound(){
		AudioSource.PlayClipAtPoint(myBombSound, Camera.main.transform.position, soundVolume);
	}
	public static void playBossHitSound (){
		if (myBossHitSound != null)
		{
			AudioSource.PlayClipAtPoint(myBossHitSound, Camera.main.transform.position, soundVolume);
		}
	}
	public static void playConfettiSound (){
		AudioSource.PlayClipAtPoint (myConfettiSound, Camera.main.transform.position, soundVolume);
	}
	public static void playMinionSound (){
		AudioSource.PlayClipAtPoint (myMinionSound, Camera.main.transform.position, soundVolume);
	}
	public static void playSwordSound (){
		AudioSource.PlayClipAtPoint (myMinionSwordSound, Camera.main.transform.position, soundVolume);
	}
	public static void playPopSound(){
		AudioSource.PlayClipAtPoint (myPopSound, Camera.main.transform.position, soundVolume);
	}
	public static void playFrogSound(){
		AudioSource.PlayClipAtPoint (myFrogSound, Camera.main.transform.position, soundVolume);
	}
	public static void playFrogAttackSound(){
		AudioSource.PlayClipAtPoint (myFrogAttackSound, Camera.main.transform.position, soundVolume);
	}
	public static void playCollectSound(){
		AudioSource.PlayClipAtPoint (myCollectSound, Camera.main.transform.position, soundVolume);
	}
	public static void playFenceSound(){
		AudioSource.PlayClipAtPoint (myFenceSound, Camera.main.transform.position, soundVolume);
	}
	//Main menu requires instance methods
	public void playInstantClickSound(){
		SoundAdapter.playClickSound (this.transform.position);
	}
	public static void playClickSound(Vector3 location){
		AudioSource.PlayClipAtPoint (myClickSound, location, soundVolume);
	}
	public static void playClickSound(){
		AudioSource.PlayClipAtPoint (myClickSound, Camera.main.transform.position, soundVolume);
	}
	//Main menu requires instance methods
	public void playInstantHoverSound(){
		SoundAdapter.playHoverSound (this.transform.position);
	}
	public static void playHoverSound(Vector3 location){
		print (myHoverSound);
		AudioSource.PlayClipAtPoint (myHoverSound, location, soundVolume);
	}
	public static void playHoverSound(){
		AudioSource.PlayClipAtPoint (myHoverSound, Camera.main.transform.position, soundVolume);
	}

	public static void altTrack(){
		myBGM.clip = myAltBGM;
		myBGM.Play ();
	}
	public static void normalTrack(){
		myBGM.clip = myNormalBGM;
		myBGM.Play ();
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

