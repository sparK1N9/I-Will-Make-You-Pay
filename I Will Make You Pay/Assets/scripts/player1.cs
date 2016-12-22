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
    public AudioSource sfxSource;
    public GameObject boom;

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
            Instantiate(bullet, transform.position + myTransform.forward.normalized / 2, transform.rotation);
            sfxSource.Play();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "p2")
        {
            currentHealth -= col.gameObject.GetComponent<bullet2>().damage;
            if (currentHealth <= 0)
            {
                system.main.up2 = true;
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            myTransform.position -= myTransform.forward.normalized * .2f;
        }

		if (col.gameObject.tag == "vehicle") {

			currentHealth -= 5;

			if (currentHealth <= 0)
			{
				system.main.up2 = true;
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
			}
		}
    }
}
