using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class p2info : MonoBehaviour {
    public string text;

    // Update is called once per frame
    void Update()
    {
        text = "$" + player2.main.funds.ToString("N2") + "\n";
        text += "HP: " + player2.main.currentHealth;
        GetComponent<Text>().text = text;
    }
}
