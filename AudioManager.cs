using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] musicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake	 ()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log ("Don't destroy on load " +name);
	}
	
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded (int level)
	{
		if(musicChangeArray[level])
		{
			AudioClip thisLevelMusic = musicChangeArray[level];
			Debug.Log ("Playing clip: " + musicChangeArray[level]);
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume (float volume)
	{
		audioSource.volume = volume;
	}

}
