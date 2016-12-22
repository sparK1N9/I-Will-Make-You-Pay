using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {
	
	public float value;
	public float maxHealth;
	public float currentHealth;
    public GameObject boom;

    public float damage;
	public Vector3 direction;
	public float speed = 3; 

	void Start () {
		
		currentHealth = maxHealth;

	}
	
	void Update () {
		
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

	}

	void OnCollisionEnter(Collision col)
	{
		//take damage from bullet
		if (col.gameObject.tag == "p1")
		{
			currentHealth -= col.gameObject.GetComponent<bullet>().damage;
		}
		else if (col.gameObject.tag == "p2")
		{
			currentHealth -= col.gameObject.GetComponent<bullet2>().damage;
		}
		//hitting a player
		else if (col.gameObject.tag == "player1" || col.gameObject.tag == "player2")
		{
			currentHealth = 0;
		}
		if (currentHealth <= 0)
		{
			if (col.gameObject.tag == "p1" || col.gameObject.tag == "player1")
			{
				system.main.funds1 -= value;
			}
			else if (col.gameObject.tag == "p2" || col.gameObject.tag == "player2")
			{
				system.main.funds2 -= value;
			}
			system.main.bu = true;//sound effect
			Destroy(gameObject);
		}
			
	}

}

	