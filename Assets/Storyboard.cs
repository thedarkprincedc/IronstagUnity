using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Renderer rend = go.GetComponent<Renderer>();
        //StartCoroutine(fadeIn(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeIn(GameObject go)
    {
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0);
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            rend.material.color = new Color(1, 1, 1, i);
            Debug.Log(i);
            yield return null;
        }
    }
    IEnumerator fadeOut(GameObject go)
    {
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            rend.material.color = new Color(1, 1, 1, i);
            Debug.Log(i);
            yield return null;
        }
    }
}
