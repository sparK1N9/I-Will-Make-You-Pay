using UnityEngine;
using System.Collections;

public class CarSpawnManager: MonoBehaviour
{
//	public player1 currentHealth;
	public float spawnTime = 0.5f; 
	public Transform[] spawnPoints; 
	public Transform[] vehicleTypes;


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
			
		int vehicleTypeIndex = Random.Range (0, vehicleTypes.Length);
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (vehicleTypes[vehicleTypeIndex].gameObject, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].localRotation);
	}
}