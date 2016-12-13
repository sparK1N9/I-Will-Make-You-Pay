using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player1 : MonoBehaviour {
    Transform myTransform;
    public float moveSpeed;
    public static player1 main;
    public bullet bullet;
    public float currentHealth;
    public float maxHealth;

    void Start () {
        myTransform = GetComponent<Transform>();
        currentHealth = maxHealth;
        main = this;
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 lookPoint = new Vector3(90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 lookPoint = new Vector3(-90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 lookPoint = new Vector3(0, 0, 90);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 lookPoint = new Vector3(0, 0, -90);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet.direction = transform.forward;
            Instantiate(bullet, transform.position + myTransform.forward.normalized, transform.rotation);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "p2")
        {
            currentHealth -= col.gameObject.GetComponent<bullet2>().damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("game");
                system.main.score2++;
                system.main.funds2 += 2000;
                system.main.funds1 += 5000;
            }
        }
        else
        {
            myTransform.position -= myTransform.forward.normalized * .2f;
        }
    }
}
