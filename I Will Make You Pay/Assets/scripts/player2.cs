using UnityEngine;
using System.Collections;

public class player2 : MonoBehaviour
{
    Transform myTransform;
    public float moveSpeed;
    public float maxHealth;
    public float currentHealth;
    public float funds;
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
            myTransform.position += myTransform.forward.normalized * Time.deltaTime * moveSpeed;
            Vector3 lookPoint = new Vector3(90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
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
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            bullet.direction = transform.forward;
            Instantiate(bullet, transform.position, transform.rotation);
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
            }
        }
    }
}
