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
        //anim.SetBool("bShoot", true);
        //anim.SetFloat("fShootAngle", 0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet"){
            anim.SetBool("bDead", true);
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
       

        fire();
        bossAi();
    }
    void fire()
    {
        Vector2 diff = playerObj.transform.position - transform.position;
        //Debug.Log(diff);
        float fAng = Mathf.Atan2(diff.y, diff.x);
        //if(fAng >= 180 - 30 && fAng <= 180 + 30){
        //    Debug.Log("r");
        //}
        var fAngDeg = fAng * Mathf.Rad2Deg;
        if(fAngDeg == 180){
            
        }


        ///Debug.Log(fAng * Mathf.Rad2Deg);
    //    if (diff.y > 0)
    //    {
    //        anim.SetFloat("fShootAngle", 0f);
    //    }
    //    else if (diff.y < 0)
    //    {
    //        anim.SetFloat("fShootAngle", 1f);
    //    }
    //    else
    //    {
    //        anim.SetFloat("fShootAngle", 0.5f);
    //    }
    }
    public string state = "idle";
    public float gameTimer;
    public int seconds = 0;
    void bossAi(){
        //if(Time.time > gameTimer + 1){
        //    gameTimer = Time.time;
        //    seconds++;
        //}
        //if(seconds == 5){
        //    seconds = 0;
        //    state == "jumping";
        //}
        //if(state == "idle"){
            
            
        //} else if(state == "jumping"){
        //    console.log(" >>>>>>>>>>>>>");
        //}
        //Debug.Log(playerObj.transform.position.y - transform.position.y);

    }
}
