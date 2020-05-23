using UnityEngine;
using UnityEngine.UI;


public class FacePanel : MonoBehaviour
{
    // enum CubeColours { Top = 0, Bottom = 1, Front = 2, Back = 3, Left = 4, Right = 5 };

    public FaceMap panelMap;        // The map this face panel belongs to.
    public FacePanel panelFace;     // This face panel.

    public bool inverted;           // Whether to invert this panel (rotate 180 degrees).
    
    public GameObject[,] pFacelets;
        // These must be accessed by the FaceMap...


    DefaultControls.Resources uiResources;
    //Image[,] panelImages = new Image[5,5];
        // Internals...


    public void Start()
    {
        Color col = UnityEngine.Color.black;

        switch (name)
        {
            case "PanelTop":        // Light blue.
                col.r = 0.2156f;
                col.g = 0.5294f;
                col.b = 0.9843f;
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

            default:
                col = UnityEngine.Color.black;
                break;
        }

        Initialise(col);
    }


    // Use this for initialization...
    void Initialise(Color col)
    {
        uiResources = new DefaultControls.Resources();

        pFacelets = new GameObject[5, 5];

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                pFacelets[x, y] = CreateFacelet(x, y, col);
            }
        }
    }


    GameObject CreateFacelet(int x, int y, Color col)
    {
        float xTrans = (x - 2) * 40.0f;
        float yTrans = (y - 2) * 40.0f;

        if (inverted)
        {
            x = 4 - x;
            y = 4 - y;
        }

        string codeNumber = string.Format("{0}{1}", x, y);
        string codeName = "Facelet" + codeNumber;

        GameObject facelet = DefaultControls.CreatePanel(uiResources);
        facelet.name = codeName;

        facelet.transform.SetParent(panelFace.transform, false);


        RectTransform rt = facelet.GetComponent<RectTransform>();

        Image img = facelet.GetComponent<Image>();

        // Use a "plain" sprite for now...
        //img.sprite = panelFace.GetComponent<Image>().sprite;
        if (inverted)
        {
            img.sprite = panelMap.faceSpritesInverted[x,y];
        }
        else
        {
            img.sprite = panelMap.faceSprites[x,y];
        }

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40.0f);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40.0f);

        rt.Translate(xTrans, yTrans, 0.0f);

        img.color = col;

        return facelet;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // >>> Put animation code here, perhaps...
    //}
}
