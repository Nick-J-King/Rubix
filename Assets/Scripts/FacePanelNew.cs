using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEditor;


public class FacePanelNew : MonoBehaviour
{
    public GameObject pRoot;
    private Image iRootImage;

    private Image[,] panelImages = new Image[5,5];


    // PRIVATE members --------------------------

    private GameObject[,] pFacelets;
    private DefaultControls.Resources uiResources;

    enum CubeColours { Top = 0, Bottom = 1, Front = 2, Back = 3, Left = 4, Right = 5 };

    private int[,] faceColours;    // <<<


    public void Start()
    {
        Debug.Log("Panel = " + name);

        Color col = UnityEngine.Color.red;

        switch (name)
        {
            case "PanelTop":
                col = UnityEngine.Color.blue;
                break;
            case "PanelBottom":
                col = UnityEngine.Color.green;
                break;
            case "PanelLeft":
                col = UnityEngine.Color.red;
                break;
            case "PanelRight":  // Orange
                col.r = 1.0f;
                col.g = 0.63f;
                col.b = 0.0f;
                break;
            case "PanelFront":
                col = UnityEngine.Color.yellow;
                break;
            case "PanelBack":
                col = UnityEngine.Color.white;
                break;
        }

        Initialise(col);
    }


    // Use this for initialization
    public void Initialise(Color col)
    {
        uiResources = new DefaultControls.Resources();

        iRootImage = pRoot.GetComponent<Image>();

        //isAnimating = false;
        pFacelets = new GameObject[5, 5];
        
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                pFacelets[x, y] = CreateFacelet(x, y, col);
            }
        }

    }


    public GameObject CreateFacelet(int x, int y, Color col)
    {
        string codeNumber = string.Format("{0}{1}", x, y);

        float xTrans = (x - 2) * 40.0f;
        float yTrans = (y - 2) * 40.0f;

        string codeName = "Facelet" + codeNumber;

        GameObject facelet = DefaultControls.CreatePanel(uiResources);
        facelet.name = codeName;

        facelet.transform.SetParent(pRoot.transform, false);

        RectTransform rt = facelet.GetComponent<RectTransform>();

        Image img = facelet.GetComponent<Image>();

        img.sprite = Resources.Load<Sprite>("Sprites/Facelet" + codeNumber);

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40.0f);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40.0f);
        rt.Translate(xTrans, yTrans, 0.0f);

        panelImages[x, y] = img;

        img.color = col;



        return facelet;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
