using UnityEngine;
using System.Collections;

public class CarSpawnManager: MonoBehaviour
{
//	public player1 currentHealth;
	public GameObject car; 
	public float spawnTime = 0.5f; 
	public Transform[] spawnPoints; 


	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
//		if(player1.currentHealth <= 0f || player2.currentHealth <= 0f)
//		{
//			return;
//		}
			

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (car, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}