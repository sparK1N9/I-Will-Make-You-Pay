using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class p1info : MonoBehaviour {
    public string text;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        text = "$" + player1.main.funds.ToString("N2") + "\n";
        text += "HP: " + player1.main.currentHealth;
        GetComponent<Text>().text = text;
    }
}
