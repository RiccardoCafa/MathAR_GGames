using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Geometry : MonoBehaviour {

    [Header("Atibutos")]
    public Animator anim;
    [Header("Formulas")]
    public string AreaForm;
    public string VolumForm;
    public string extraForm;

    private Transform myT;
    

    private void Awake()
    {
        myT = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        ComingAnim();
    }

    private void ComingAnim()
    {
        myT.localPosition = new Vector3(0f, 0.5f);
        StartCoroutine("IComeDown");
    }

    IEnumerator IComeDown()
    {
        while(myT.localPosition.y >= 0.05f)
        {
            yield return new WaitForSeconds(0.05f);
            myT.Translate(new Vector3(0f, -0.03f));
        }
    }

    public void AreaAnim()
    {
        anim.Play("BoxOpening");
    }

    public void ConstAnim()
    {
        anim.Play("none");
        StartCoroutine("IShowIt");
    }

    IEnumerator IShowIt()
    {
        foreach (Transform g in transform)
        {
            g.gameObject.SetActive(false);
        }

        foreach(Transform ga in transform)
        {
            yield return new WaitForSeconds(0.5f);
            ga.gameObject.SetActive(true);
        }
        
    }

    public void VolumAnim()
    {

    }

    private void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        foreach(Transform t in transform)
        {
            t.gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);
        }
    }

    private void OnEnable()
    {
        ChangeColor();
        ComingAnim();
    }

}
