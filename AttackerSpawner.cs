using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	private float timeSet;
	
	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject thisAttacker in attackerPrefabArray)
		{
			if(isTimeToSpawn(thisAttacker))
			{
				Spawn (thisAttacker);
			}
		}
	}
	
	bool isTimeToSpawn(GameObject thisAttacker)
	{
		Attackers attacker = thisAttacker.GetComponent<Attackers>();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime >= 1)
		{
			Debug.LogWarning ("Frame-rate threshold reached. Reduced spawn rate.");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		if(Random.value < threshold)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	void Spawn (GameObject thisAttacker)
	{
		GameObject newAtk = Instantiate (thisAttacker, transform.position, Quaternion.identity) as GameObject;
		newAtk.transform.parent = transform;
	}
}
