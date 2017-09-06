using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	public float fadeTime;
	
	private Image fadePanel;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		fadePanel.CrossFadeAlpha(0, fadeTime, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad >= fadeTime)
		{
			gameObject.SetActive(false);
		}
	}
}
