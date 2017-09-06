using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	private Image fadePanel;
	
	public void FadeIn () {
		print ("FadeIn called");
		gameObject.SetActive(true);
		fadePanel = GetComponent<Image>();
		fadePanel.CrossFadeAlpha(255f, 0.3f, false);
	}
}