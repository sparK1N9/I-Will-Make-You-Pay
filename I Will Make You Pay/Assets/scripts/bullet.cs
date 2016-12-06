using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float damage = 5;
    public Vector3 direction;
    public float speed = 5;

	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Untagged" || col.gameObject.tag == "p2" || col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
