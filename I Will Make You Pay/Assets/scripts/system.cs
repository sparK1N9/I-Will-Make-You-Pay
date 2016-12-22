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
    int y = 0;
    public RawImage a1;
    public RawImage a2;
    public RawImage a3;
    public RawImage a4;
    public RawImage a5;
    public RawImage a6;
    public RawImage a7;
    public RawImage a8;

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
        a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && y == 0)
        {
            y++;
            a1.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 1)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a2.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 2)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a3.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 3)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a4.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 4)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a5.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 5)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a6.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 6)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a7.enabled = true;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && y == 7)
        {
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            y++;
            a8.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && y == 8)
        {
            y++;
            a1.enabled = a2.enabled = a3.enabled = a4.enabled = a5.enabled = a6.enabled = a7.enabled = a8.enabled = false;
            i++;
            bgm.Stop();
            sfxSource.Play();
            SceneManager.LoadScene("game", LoadSceneMode.Single);
            tx[0].enabled = true;
            st.enabled = false;
            ui.enabled = true;
        }
        else if (y == 9)
        {
            if (up2)
            {
                trans2.Play();
                score1++;
                funds2 += 2000;
                funds1 += 5000;
                StartCoroutine(HitPause(1.0f));
                SceneManager.LoadScene("game");
                up2 = false;
            }
            else if (up1)
            {
                trans.Play();
                score2++;
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
            if ((score1 == 5 || funds1 <= 0) && i != 2)
            {
                win1.Play();
                tx[0].enabled = false;
                ui.enabled = false;
                SceneManager.LoadScene("start", LoadSceneMode.Single);
                p1w.enabled = true;
                i = 2;
            }
            else if ((score2 == 5 || funds2 <= 0) && i != 2)
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
                y = 0;
            }
            if (i != 0)
            {
                text = score2.ToString("N0") + "\t\t\t\t\t\t\t";
                text += score1.ToString("N0");
                tx[0].text = text;
            }
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
