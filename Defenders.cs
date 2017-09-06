using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	private GraveStone GS;
	private Animator anim;
	private StarDisplay starDisp;
	
	[Tooltip ("Minimum stars required to place defender")]
	public int starPrice;
	
	void Start ()
	{
		anim = GetComponent<Animator>();
		starDisp = FindObjectOfType<StarDisplay>();
	}
			
	void OnTriggerEnter2D (Collider2D trigger)
	{
		//Checks whether the trigger is caused by Grave and Fox - exits if true
		if(gameObject.GetComponent<GraveStone>() && trigger.GetComponent<Fox>())
		{
			return;
		}
		
		//Confirms that the trigger is caused by an attack and reacts
		if(trigger.GetComponent<Attackers>())
		{
			anim.SetBool("underAttack", true);
		}
	}
	
	void OnTriggerExit2D (Collider2D trigger)
	{
		anim.SetBool("underAttack", false);
	}
	
	public void AddStars (int amount)
	{
		starDisp.AddStars(amount);
	}
	
	void OnMouseDown()
	{
		if(Button.selectedDefender.GetComponent<Spade>())
		{
			Destroy(gameObject);
		}
	}

	
	
}
