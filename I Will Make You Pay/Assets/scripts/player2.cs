using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{
    Transform myTransform;
    public float moveSpeed;
    public float maxHealth;
    public float currentHealth;
    public static player2 main;
    public bullet2 bullet;
    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
        currentHealth = maxHealth;
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 lookPoint = new Vector3(90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 lookPoint = new Vector3(-90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 lookPoint = new Vector3(0, 0, 90);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 lookPoint = new Vector3(0, 0, -90);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            bullet.direction = transform.forward;
            Instantiate(bullet, transform.position + myTransform.forward.normalized, transform.rotation);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "p1")
        {
            currentHealth -= col.gameObject.GetComponent<bullet>().damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("game");
                system.main.score1++;
                system.main.funds1 += 2000;
                system.main.funds2 += 5000;
            }
        }
        else
        {
            myTransform.position -= myTransform.forward.normalized * .2f;
        }
    }
}
