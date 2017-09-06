using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager lvlMng;
	
	void Start ()
	{
		lvlMng = FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D (Collider2D causeOfTrigger)
	{
		if(causeOfTrigger.GetComponent<Attackers>())
		{
			lvlMng.LoadLevel("03b Lose");
		}
	}
}
