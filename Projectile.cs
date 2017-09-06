using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D trigger)
	{
		
		if(trigger.GetComponent<Attackers>())
		{
			Health targetHealth = trigger.GetComponent<Health>();
			targetHealth.DealDamage(damage);
			Destroy(gameObject);
		}
	}
	
	

}
