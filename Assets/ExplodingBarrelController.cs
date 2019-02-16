using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrelController : MonoBehaviour
{
    public GameObject explosionObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        //Debug.Log(other.gameObject.tag);
       // Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            explode();
            Object.Destroy(this.gameObject);
            Object.Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Explosion")
        {
            explode();
            //Object.Destroy(this.gameObject);
            //Object.Destroy(other.gameObject);
        }
    }
    public void explode(){
        
        GameObject obj = Instantiate(explosionObject, transform.position, Quaternion.identity);
    
    }
}
