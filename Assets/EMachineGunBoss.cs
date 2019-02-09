using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMachineGunBoss : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigidbody2D;
    private GameObject playerObj = null;
    float someScale;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (playerObj == null)
        {
            playerObj = GameObject.Find("FlintIdle");
        }
        someScale = transform.localScale.x;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet"){
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerObj.transform.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            facingRight = false;
        }
        else
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            facingRight = true;
        }
    }
}
