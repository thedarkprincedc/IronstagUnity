using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
