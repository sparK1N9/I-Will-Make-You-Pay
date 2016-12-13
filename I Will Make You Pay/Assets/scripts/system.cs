using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour
{
    public float funds1;
    public float funds2;
    public static system main;
    public int score1;
    public int score2;
    public string text;
    public RawImage p1w;
    public RawImage p2w;
    public RawImage st;
    public Text[] tx;
    int i = 0;

    void Awake()
    {
        if (main == null)
        {
            main = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        st.enabled = true;
        p1w.enabled = p2w.enabled = false;
        score1 = score2 = 0;
        funds1 = funds2 = 9001;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && i == 0)
        {
            i++;
            st.enabled = false;
            SceneManager.LoadScene("game", LoadSceneMode.Single);
        }
        if ((score1 == 5 || funds2 <= 0) && i != 2)
        {
            SceneManager.LoadScene("start", LoadSceneMode.Single);
            p1w.enabled = true;
            i = 2;
        }
        else if ((score2 == 5 || funds1 <= 0) && i != 2)
        {
            SceneManager.LoadScene("start", LoadSceneMode.Single);
            p2w.enabled = true;
            i = 2;
        }
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && i == 2)
        {
            p2w.enabled = p1w.enabled = false;
            st.enabled = true;
            i = 0;
            score1 = score2 = 0;
            funds1 = funds2 = 9001;
            tx[0].text = "";
            SceneManager.LoadScene("start");
        }
        if (i != 0)
        {
            tx = GetComponentsInChildren<Text>();
            text = score1.ToString("N0") + "\t";
            text += score2.ToString("N0");
            tx[0].text = text;
        }
    }
}
