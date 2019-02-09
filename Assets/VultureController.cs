using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureController : MonoBehaviour
{
	Animator anim;
	bool facingRight = false;
	public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isDead", isDead);
		vultureAI();
    }
	void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Bullet"){
            //Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).clipName);
            //AnimatorClipInfo[] m_CurrentClipInfo;
            //m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
            //Debug.Log(m_CurrentClipInfo[0].clip.name);
            Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            isDead = true;
			Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
    }
	void vultureAI(){
		
	}
}
