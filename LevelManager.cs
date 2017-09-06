using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: "+name);
		Application.LoadLevel(name);
	}
	
	public void QuitReq(string name) {
		Debug.Log ("Quit requested at: "+name);
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void WinDelayed()
	{
		print ("WinDelayed called");
		Invoke("LoadWin", 2f);
	}
	
	void LoadWin()
	{
		LoadLevel ("03a Win");
	}
}
