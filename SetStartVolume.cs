using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private AudioManager audioManager;
	
	void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
		float currentVolume = PlayerPrefsManager.GetMasterVolume();
		audioManager.ChangeVolume(currentVolume);
	}
}
