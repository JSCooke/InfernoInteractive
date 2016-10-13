using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour {

	private bool loaded = false;

	void Update () {
		if (!loaded)
		{
			loaded = true;
			System.Threading.Thread.Sleep(2000);
			SceneManager.LoadScene("Level2");
		}
		
	}
	
}
