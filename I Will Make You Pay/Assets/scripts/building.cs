using UnityEngine;
using System.Collections;

public class building : MonoBehaviour {
    public float value;
    public float maxHealth;
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
                system.main.funds1 -= value;
            }
            else if (col.gameObject.tag == "p2")
            {
                system.main.funds2 -= value;
            }
            system.main.bu = true;
            Destroy(gameObject);
        }
    }
}