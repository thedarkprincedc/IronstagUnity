using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public GameObject [] screens;
    int currentFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        //var go = GameObject.Find("TitleScreenBGM");
        GameObject go = Instantiate(screens[0], transform.position, Quaternion.identity);

        //Renderer rend = go.GetComponent<Renderer>();
        //float alpha = 0.25f; 
        //rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
       
        //StartCoroutine(fadeIn(go));
        //GameObject go = Instantiate(screens[1], transform.position, Quaternion.identity);
    }
    IEnumerator fadeIn(GameObject go)
    {
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0);
        for (float i = 0; i <= 1; i += Time.deltaTime){
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
    //IEnumerator Example()
    //{
    //    print(Time.time);
    //    yield return new WaitForSeconds(5);
    //    print(Time.time);
    //}
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
           
            //SceneManager.LoadScene("SampleScene");
            //if (currentFrame < sizeof(screens))
            //{

            //}
            //else
            //{
            //    SceneManager.LoadScene("SampleScene");
            //}
        }
    }
}
