using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashManage : MonoBehaviour {

	public LevelManager levelMan;

	void Start ()
	{
		Invoke("EndSplash", 5f);
	}
	
	void EndSplash()
	{
		levelMan.LoadNextLevel();
	}	
}
