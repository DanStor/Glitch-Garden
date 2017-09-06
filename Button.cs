using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	
	private Button[] buttonArray;
	private Color defaultColour = new Color (0, 0, 0, 0.52f);
	private Text priceText;
	private int price;
	public static GameObject selectedDefender;
	public GameObject defenderPrefab;
	
	
	void Start ()
	{
		buttonArray = GameObject.FindObjectsOfType<Button>();
		priceText = GetComponentInChildren<Text>();
		price = defenderPrefab.GetComponent<Defenders>().starPrice;
		if(priceText)
		{
			SetPrice();
		}
	}
	
	void OnMouseDown()
	{
		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = defaultColour;
		}
			
		if(!(selectedDefender == defenderPrefab))
		{	
			GetComponent<SpriteRenderer>().color = Color.white;
			selectedDefender = defenderPrefab;
			return;
		}
		
		selectedDefender = null;
	}
	
	void SetPrice()
	{
		priceText.text = price.ToString();
	}	
}
