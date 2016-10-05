using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damageTextBehaviour : MonoBehaviour {

    Animator animator;
    private Text damageText;

	// Use this for initialization
	void Start () {

        //infomation about animation being played
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        //Destroy the text object at the end 
        Destroy(gameObject, clipInfo[0].clip.length);

        damageText = animator.GetComponent<Text>();
	
	}
	
	public void SetText(string text)
    {
        damageText.text = text;
    }
}
