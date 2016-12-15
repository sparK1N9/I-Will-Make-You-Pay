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
    public RawImage ui;
    public Text[] tx;
    int i = 0;
    public AudioSource sfxSource;
    public AudioSource bgm;
    public AudioSource trans;
    public AudioSource trans2;
    public AudioSource bui;
    public AudioSource win1;
    public AudioSource win2;
    public bool up1 = false;
    public bool up2 = false;
    public bool bu = false;

    void Awake()
    {
        if (main == null)
        {
            main = this;
            DontDestroyOnLoad(gameObject);
            bgm.Play();
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        st.enabled = true;
        p1w.enabled = p2w.enabled = false;
        score1 = score2 = 0;
        funds1 = funds2 = 9001;
        tx = GetComponentsInChildren<Text>();
        tx[0].enabled = false;
        ui.enabled = false;
    }

    void Update()
    {
        if (up2)
        {
            trans2.Play();
            score2++;
            funds2 += 2000;
            funds1 += 5000;
            StartCoroutine(HitPause(1.0f));
            SceneManager.LoadScene("game");
            up2 = false;
        }
        else if (up1)
        {
            trans.Play();
            score1++;
            funds1 += 2000;
            funds2 += 5000;
            StartCoroutine(HitPause(1.0f));
            SceneManager.LoadScene("game");
            up1 = false;
        }
        if (bu)
        {
            bu = false;
            bui.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && i == 0)
        {
            i++;
            bgm.Stop();
            sfxSource.Play();
            SceneManager.LoadScene("game", LoadSceneMode.Single);
            tx[0].enabled = true;
            st.enabled = false;
            ui.enabled = true;
        }
        if ((score1 == 5 || funds2 <= 0) && i != 2)
        {
            win1.Play();
            tx[0].enabled = false;
            ui.enabled = false;
            SceneManager.LoadScene("start", LoadSceneMode.Single);
            p1w.enabled = true;
            i = 2;
        }
        else if ((score2 == 5 || funds1 <= 0) && i != 2)
        {
            win2.Play();
            tx[0].enabled = false;
            ui.enabled = false;
            SceneManager.LoadScene("start");
            p2w.enabled = true;
            i = 2;
        }
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && i == 2)
        {
            p2w.enabled = p1w.enabled = false;
            st.enabled = true;
            bgm.Play();
            i = 0;
            score1 = score2 = 0;
            funds1 = funds2 = 9001;
            tx[0].text = "";
            SceneManager.LoadScene("start");
        }
        if (i != 0)
        {
            text = score1.ToString("N0") + "\t\t\t\t\t\t\t";
            text += score2.ToString("N0");
            tx[0].text = text;
        }
    }

    public IEnumerator HitPause(float pauseTime)
    {
        Time.timeScale = 0.0f;
        float pauseEndtime = Time.realtimeSinceStartup + pauseTime;

        while (Time.realtimeSinceStartup < pauseEndtime)
        {
            yield return 0;
        }

        Time.timeScale = 1;
    }
}
