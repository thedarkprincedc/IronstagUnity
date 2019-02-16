using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class TransitionState{
//    public GameObject gameObject;
//    public float displayTime;
//    public void TransitionState(){
        
//    }
//}
//public abstract class Action : ScriptableObject
//{
//    public abstract void Act(StateController controller);
//}
//public class ScreenTransition{
//    public delegate void FinishFunctionDelegate();


//    //void Start(){
        
//    //}
//    //void push(GameObject gameObject, float displayTime, IEnumerator in, IEnumerator out, F){
        
//    //}    
//    //void next(){
        
//    //}
//    //void prev()
//    //{

//    //}
//}

public class TitleScreenController : MonoBehaviour
{
    public GameObject [] screens;
    public GameObject goLastFrame;
    //public TransitionState state;
    int currentFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        first();
        //var go = GameObject.Find("TitleScreenBGM");
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
    IEnumerator fadeInFadeOut(GameObject go){
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0);
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            rend.material.color = new Color(1, 1, 1, i);
            Debug.Log(i);
            yield return null;
        }
        yield return new WaitForSeconds(2.5f); 
        //Renderer rend = go.GetComponent<Renderer>();
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
    void first(){
        currentFrame = 0;
        GameObject go = Instantiate(screens[currentFrame], transform.position, Quaternion.identity);
        go.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.0f);
        //StartCoroutine(fadeIn(go));
        //StartCoroutine(fadeOut(go));
        StartCoroutine(fadeInFadeOut(go));

        goLastFrame = go;
    }
    void next(){
        currentFrame++;
        StartCoroutine(fadeOut(goLastFrame));
        GameObject go = Instantiate(screens[currentFrame], transform.position, Quaternion.identity);
        go.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.0f);
        StartCoroutine(fadeIn(go));
        goLastFrame = go;

        //if (currentFrame > sizeof(screens)){
        //    SceneManager.LoadScene("SampleScene");
        //}
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            next();
        }
    }
}
