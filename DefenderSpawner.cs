using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarDisplay starDisp;
	public Spade spade;
	
	void Start ()
	{
		starDisp = FindObjectOfType<StarDisplay>();
		
		parent = GameObject.Find("Defenders");
		if(!parent)
		{
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown ()
	{
		if(!Button.selectedDefender)
		{
			return;
		}
		
		if(Button.selectedDefender.GetComponent<Spade>())
		{
			return;
		}
		
		int defenderCost = Button.selectedDefender.GetComponent<Defenders>().starPrice;
		
		if(starDisp.SpendStars(defenderCost) == StarDisplay.Status.SUCESS)
		{
			Vector3 snapPoint = SnapToGrid(CalcWorldPointMouse());
			GameObject newDef = Instantiate (Button.selectedDefender, snapPoint, Quaternion.identity) as GameObject;
			newDef.transform.parent = parent.transform;
			return;
		}	
		
		Debug.Log("Not enough stars");
	}
	
	//Takes the mouse point (Vector3) in pixels and returns it in world points
	Vector3 CalcWorldPointMouse ()
	{
		float mousePosX = Input.mousePosition.x;
		float mousePosY = Input.mousePosition.y;
		
		//The distance from the main camera to the level canvas
		float distanceFromCamera = 10f;
		
		return Camera.main.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, distanceFromCamera));
	}
	
	//Takes the world point of the mouse and rounds it to the nearest whole number
	Vector3 SnapToGrid(Vector3 rawWorldPoint)
	{
		float roundedX = Mathf.Round(rawWorldPoint.x);
		float roundedY = Mathf.Round(rawWorldPoint.y);
		
		//No need to round 'z' as it will always be 0

		Vector3 roundedSpawnPoint = new Vector3(roundedX, roundedY, 0f);
		
		return roundedSpawnPoint;
	}
}
