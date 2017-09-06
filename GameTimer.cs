using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float gameLength;
	private GameObject winLabel;
	private LevelManager lvlMng;
	private Slider slide;
	private float sliderPos = 0f;
	private AudioSource winSound;
	
	// Use this for initialization
	void Start () {
		lvlMng = FindObjectOfType<LevelManager>();
		slide = GetComponent<Slider>();
		slide.value = sliderPos;
		winSound = GetComponent<AudioSource>();
		FindWinLabel();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CalculateSliderValue();
		
		if(Time.timeSinceLevelLoad == gameLength)
		{
			EndGame();
		}
	}
	
	void FindWinLabel()
	{
		winLabel = GameObject.Find ("YouWin");
		if(!winLabel)
		{
			Debug.LogError("Please create Win Label");
		}
		
		winLabel.SetActive(false);
	}
	
	void CalculateSliderValue()
	{
		sliderPos = Time.time / gameLength;
		slide.value = sliderPos;
	}
	
	void EndGame()
	{
		print ("EndGame called");
		winLabel.SetActive(true);
		Text winText = winLabel.GetComponent<Text>();
		winText.CrossFadeAlpha(255f, 2f, true);
		
		Time.timeScale = 0.4f;
		Invoke ("LoadNext", 4f);
		winSound.Play();
		
	}
	
	void LoadNext ()
	{
		lvlMng.LoadLevel("03a Win");
	}
}
