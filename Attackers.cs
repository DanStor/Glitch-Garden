using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attackers : MonoBehaviour {

	[Range (0f, 2f)]
	
	private GameObject currentTarget;
	private Animator anim;
	public float walkSpeed;
	
	[Tooltip ("Average number of seconds between appearance on screen")]
	public float seenEverySeconds;
	
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
		if(!currentTarget)
		{
			anim.SetBool ("isAttacking", false);
		}
	}
	
	void SetSpeed(float newSpeed)
	{
		walkSpeed = newSpeed;
	}
	
	void StrikeCurrentDamage (float damage)
	{
		if (currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			if(health)
			{
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj)
	{
		currentTarget = obj;
	}

}
