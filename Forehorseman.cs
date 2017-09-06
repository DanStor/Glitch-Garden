using UnityEngine;
using System.Collections;

public class Forehorseman : MonoBehaviour {

	private Attackers attackers;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		attackers = GetComponent<Attackers>();
		anim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D (Collider2D trigger)
	{
		GameObject obj = trigger.gameObject;
		if(!obj.GetComponent<Defenders>())
		{
			return;
		}
		
		attackers.Attack(obj);
		anim.SetBool ("isAttacking", true);
	}
}
