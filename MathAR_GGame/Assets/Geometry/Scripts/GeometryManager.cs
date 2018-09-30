using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeometryManager : MonoBehaviour {

    [Header("Gameplay")]
    public GameObject actual_geo;
    public List<GameObject> geos;
    [Header("Canvas")]
    public Text areaTxt;
    public Text volumeTxt;
    public Text extraTxt;
    public Button btn_sqr;
    public Button btn_pyr;
    public Button btn_prs;

    private EGeom geom;

    private void Awake()
    {
        LoadForms();
    }

    private void Start()
    {
        btn_sqr.onClick.AddListener(delegate { ChangeType(EGeom.square); });
        btn_prs.onClick.AddListener(delegate { ChangeType(EGeom.prism); });
        btn_pyr.onClick.AddListener(delegate { ChangeType(EGeom.piramide); });
        ChangeType(EGeom.square);
    }
    /* Square
     * Cylinder
     * Pyramid
     * 
     * 
     */
    public void CallConstAnim()
    {
        actual_geo.GetComponent<Geometry>().ConstAnim();
    }

    public void CallAreaAnim()
    {
        actual_geo.GetComponent<Geometry>().AreaAnim();
    }

    private void ChangeType(EGeom gm)
    {
        actual_geo.SetActive(false);
        geom = gm;
        switch(geom)
        {
            case EGeom.square:
                actual_geo = geos[0];
                break;
            case EGeom.prism:
                actual_geo = geos[1];
                break;
            case EGeom.piramide:
                actual_geo = geos[2];
                break;
        }
        actual_geo.SetActive(true);
    }

    private void LoadForms()
    {
        areaTxt.text = " Fórmula da área: \n" + actual_geo.GetComponent<Geometry>().AreaForm;
        volumeTxt.text = " Fórmula do volume: \n" + actual_geo.GetComponent<Geometry>().VolumForm;
        if(actual_geo.GetComponent<Geometry>().extraForm != "")
        {
            extraTxt.gameObject.SetActive(true);
            extraTxt.text = actual_geo.GetComponent<Geometry>().extraForm;
        } else
        {
            extraTxt.gameObject.SetActive(false);
        }
    }

}
