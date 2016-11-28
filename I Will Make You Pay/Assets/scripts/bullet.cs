using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float damage;
    public Vector3 direction;
    public float speed;

	void Update () {
        transform.position += direction * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
