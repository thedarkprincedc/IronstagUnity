using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureController : MonoBehaviour
{
	Animator anim;
    Rigidbody2D rigidbody2D;
	bool facingRight = false;
	public bool isDead = false;
    Vector3 vOriginalPosition;
    float move = -1;
    float maxSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        this.vOriginalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isDead", isDead);
       
    }
    void FixedUpdate(){
        vultureAI();
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
      
    }
	void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Bullet"){
            //Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).clipName);
            //AnimatorClipInfo[] m_CurrentClipInfo;
            //m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
            //Debug.Log(m_CurrentClipInfo[0].clip.name);
            //Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            isDead = true;
			Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        } else if(other.gameObject.tag == "Player"){
            
        } else{
            Flip();
        }
    }
	void vultureAI(){
        if (this.transform.position.x <= this.vOriginalPosition.x + -3)
        {
            move *= -1;
            Flip();
        }
        if (this.transform.position.x >= this.vOriginalPosition.x + 3)
        {
            move *= -1;
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
}
