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
    public AudioSource sfxSource;

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
            Instantiate(bullet, transform.position + myTransform.forward.normalized / 2, transform.rotation);
            sfxSource.Play();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "p1")
        {
            currentHealth -= col.gameObject.GetComponent<bullet>().damage;
            if (currentHealth <= 0)
            {
                system.main.up1 = true;
                Destroy(gameObject);
                SceneManager.LoadScene("game");
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
				system.main.up1 = true;
				Destroy(gameObject);
			}
		}
    }
}
