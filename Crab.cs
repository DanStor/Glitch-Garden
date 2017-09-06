using UnityEngine;
using System.Collections;

public class Crab : MonoBehaviour {

	private Attackers attacker;
	private Animator anim;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attackers>();
		anim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D (Collider2D trigger)
	{
		GameObject obj = trigger.gameObject;
		if (!obj.GetComponent<Defenders>())
		{
			return;
		}
		
		attacker.Attack (obj);
		anim.SetBool ("isAttacking", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
