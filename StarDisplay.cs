using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	public Text starCountText;
	public enum Status {SUCESS, FAILURE};
	public int currentStars;
	
	void Start()
	{
		UpdateText();
	}
	
	public void AddStars (int amount)
	{
		print ("stars added to display");
		currentStars += amount;
		UpdateText();
	}
	
	void UpdateText ()
	{
		starCountText.text = currentStars.ToString();
	}
	
	public Status SpendStars (int price)
	{
		if(price <= currentStars)
		{
			currentStars -= price;
			UpdateText();
			return Status.SUCESS;
		}
		print ("Failure");
		return Status.FAILURE;
	}
}
