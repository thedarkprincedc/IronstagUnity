using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintControllerScript : MonoBehaviour, IDamageable<float>
{
    Animator anim;
    Rigidbody2D rigidbody2D;
    float maxSpeed = 10f;
    bool facingRight = true;
    public float jumpForce = 350f;

    public GameObject flintBullet;
    public Vector2 bulletStartPosition;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    public AudioClip bulletSound;
    AudioSource audioSource;
    public bool bTakeDamage = false;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.45f;
    public LayerMask whatIsGround;
    float isFalling;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump")){
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
        //if (!grounded && Input.GetButtonUp("Jump"))
        //{
        //    //anim.SetBool("isFalling", true);
        //}
        if (Input.GetButtonDown("Fire1")){
            anim.SetBool("bShoot", true);
        }
        if (Input.GetButtonUp("Fire1")){
            anim.SetBool("bShoot", false);
        }
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        anim.SetBool("isFalling", (rigidbody2D.velocity.y < 0));

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
 
    public void Fire(){
        audioSource.PlayOneShot(bulletSound);
        bulletPos = transform.position;
        if (facingRight){
            bulletPos += new Vector2(this.bulletStartPosition.x, this.bulletStartPosition.y);
            GameObject obj = Instantiate(flintBullet, bulletPos, Quaternion.identity);
        } else {
            bulletPos += new Vector2(-this.bulletStartPosition.x, this.bulletStartPosition.y);
            GameObject obj = Instantiate(flintBullet, bulletPos, Quaternion.identity);
            obj.GetComponent<Bullet>().velX = -5;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
    }
    public void Damage(float damageTaken){
  
    }
}
