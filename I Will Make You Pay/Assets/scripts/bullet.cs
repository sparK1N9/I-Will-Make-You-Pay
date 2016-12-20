﻿using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float damage;
    public Vector3 direction;
    public float speed = 5;

	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
