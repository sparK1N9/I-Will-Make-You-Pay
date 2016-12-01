using UnityEngine;
using System.Collections;

public class building : MonoBehaviour {
    public float value = 2000;
    public float maxHealth = 20;
    public float currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "p1")
        {
            currentHealth -= col.gameObject.GetComponent<bullet>().damage;
        }
        else if (col.gameObject.tag == "p2")
        {
            currentHealth -= col.gameObject.GetComponent<bullet2>().damage;
        }
        // only take penalities when a building is completely destroyed
        if (currentHealth <= 0)
        {
            if (col.gameObject.tag == "p1")
            {
                player1.main.funds -= value;
            }
            else if (col.gameObject.tag == "p2")
            {
                player2.main.funds -= value;
            }
            Destroy(gameObject);
        }
    }
}
