using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 5.0f;
    public float velX = 5f;
    public float velY = 0f;
    public float timeToLive = 3.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, timeToLive);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);

    }
}
