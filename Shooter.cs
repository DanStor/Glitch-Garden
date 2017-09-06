using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	public float velocity;
	private GameObject projectileParent;
	private Animator anim;
	private AttackerSpawner mySpawner;
	
	void Start ()
	{
		anim = GetComponent<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent)
		{
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}
	
	void Update ()
	{
		if(EnemyInFront())
		{
			anim.SetBool("isDefending", true);
		}
		else
		{
			anim.SetBool ("isDefending", false);
		}
	}
	
	bool EnemyInFront()
	{
		if(mySpawner.transform.childCount <= 0)
		{
			return false;
		}
		
		foreach (Transform child in mySpawner.transform)
		{
			if((child.transform.position.x <= 10f) && (child.transform.position.x > gameObject.transform.position.x))
			{
				return true;
			}
		}
		
		return false;	
	}
	
	//Look through all spawners and find the one in my lane
	void SetMyLaneSpawner()
	{
		AttackerSpawner[] attackSpawnersArray = FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner thisSpawner in attackSpawnersArray)
		{
			if(thisSpawner.transform.position.y == gameObject.transform.position.y)
			{
				mySpawner = thisSpawner;
				return;
			}
		}
	}
	
 	private void FireGun ()
 	{
 		GameObject projClone = Instantiate(projectile) as GameObject;
 		projClone.transform.parent = projectileParent.transform;
 		projClone.transform.position = gun.transform.position;  
 	}

}
