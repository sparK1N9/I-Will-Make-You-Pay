using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float damage = 5;
    public Vector3 direction;
    public float speed = 5;

	void Update () {
        transform.position += direction.normalized * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
