using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attackers))]
public class Fox : MonoBehaviour {

	private Attackers attacker;
	private Animator anim;
	
	void Start ()
	{
		attacker = GetComponent<Attackers>();
		anim = GetComponent<Animator>();
		anim.SetBool("isAttacking", false);
	}
	
	void OnTriggerEnter2D (Collider2D trigger)
	{
		GameObject obj = trigger.gameObject;
		if(!obj.GetComponent<Defenders>())
		{
			return;
		}
		
		if(obj.GetComponent<GraveStone>())
		{
			anim.SetTrigger("jumpTrigger");
		}
		else
		{
			attacker.Attack(obj);
			anim.SetBool("isAttacking", true);
		}
	}
}
