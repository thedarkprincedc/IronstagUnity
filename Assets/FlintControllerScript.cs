using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintControllerScript : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigidbody2D;
    float maxSpeed = 10f;
    bool facingRight = true;
    public float jumpForce = 300f;

    public GameObject flintBullet;
    public Vector2 bulletStartPosition;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            //anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
        if (Input.GetButtonDown("Fire1")){
            anim.SetBool("bShoot", true);
            Fire();
        }
        if (Input.GetButtonUp("Fire1")){
            anim.SetBool("bShoot", false);
        }
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
        if (move > 0 && !facingRight){
            Flip();
        } else if (move < 0 && facingRight){
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Fire(){
        bulletPos = transform.position;
        if (facingRight)
        {
            bulletPos += new Vector2(this.bulletStartPosition.x, this.bulletStartPosition.y);
            GameObject obj = Instantiate(flintBullet, bulletPos, Quaternion.identity);

        }
        else
        {
            bulletPos += new Vector2(-this.bulletStartPosition.x, this.bulletStartPosition.y);
            GameObject obj = Instantiate(flintBullet, bulletPos, Quaternion.identity);
            obj.GetComponent<Bullet>().velX = -5;
        }
    }
}
