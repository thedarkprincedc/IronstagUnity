using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBandit : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigidbody2D;
    bool facingRight = true;

    public GameObject flintBullet;
    public Vector2 bulletStartPosition;

    private GameObject playerObj = null;
    float someScale;
    Vector2 bulletPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(playerObj == null){
            playerObj = GameObject.Find("FlintIdle");
        }
        someScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.transform.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            facingRight = false;
        } else {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            facingRight = true;
        }
       // RunBanditAI();
    }
    void RunBanditAI(){
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
