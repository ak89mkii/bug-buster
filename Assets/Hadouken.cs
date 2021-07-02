using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadouken : MonoBehaviour {
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(10);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(impactEffect);
        }
        Destroy(impactEffect);

    }
}
