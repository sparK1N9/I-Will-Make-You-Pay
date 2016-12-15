using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class p1info : MonoBehaviour {
    public string text;
	
	// Update is called once per frame
	void Update () {
        text = "$" + system.main.funds1.ToString("N2") + "\n";
        text += "HP: " + player1.main.currentHealth/5;
        GetComponent<Text>().text = text;
    }
}
