using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameObject lifeStripObj = null;
    // Start is called before the first frame update
    void Start()
    {
        if (lifeStripObj == null)
        {
            lifeStripObj = GameObject.Find("LifeStrip");
        }
        lifeStripObj.transform.localScale = new Vector3(1F, 8F, 1F);
        lifeStripObj.transform.localScale.Set(1F,5F,1F);
    }

    // Update is called once per frame
    void Update()
    {
        //float f = 8F;
        //lifeStripObj.transform.localScale = new Vector3(1F, 8F, 1F);
    }
}
