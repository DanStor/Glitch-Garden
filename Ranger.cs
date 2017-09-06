using UnityEngine;
using System.Collections;

public class Ranger : MonoBehaviour {

	private Animator anim;
	private GameObject currentTarget;
	public float damage;
	
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	void Update ()
	{
		if(!currentTarget)
		{
			anim.SetBool ("underAttack", false);
		}
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		if(!trigger.GetComponent<Attackers>())
		{
			return;
		}
	
		anim.SetBool ("underAttack", true);
		currentTarget = trigger.gameObject;
	}
	
	void StrikeCurrentDamage ()
	{
		Health attackTarget = currentTarget.GetComponent<Health>();
		attackTarget.DealDamage(damage);
	}
}
