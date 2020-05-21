using UnityEngine;
using UnityEngine.UI;


public class FacePanel : MonoBehaviour
{
    enum CubeColours { Top = 0, Bottom = 1, Front = 2, Back = 3, Left = 4, Right = 5 };

    public GameObject pRoot;
        // The "map" this face panel is in.
    
    public GameObject[,] pFacelets;
        // These must be accessed by the FaceMap...
 
    DefaultControls.Resources uiResources;
    Image[,] panelImages = new Image[5,5];
        // Internals...


    public void Start()
    {
        Color col = UnityEngine.Color.black;

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
        string codeNumber = string.Format("{0}{1}", x, y);

        float xTrans = (x - 2) * 40.0f;
        float yTrans = (y - 2) * 40.0f;

        string codeName = "Facelet" + codeNumber;

        GameObject facelet = DefaultControls.CreatePanel(uiResources);
        facelet.name = codeName;

        facelet.transform.SetParent(pRoot.transform, false);

        RectTransform rt = facelet.GetComponent<RectTransform>();

        Image img = facelet.GetComponent<Image>();

        // Use a "plain" sprite for now...
        //img.sprite = pRoot.GetComponent<Image>().sprite;
        img.sprite = Resources.Load<Sprite>("Sprites/Facelet" + codeNumber);

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40.0f);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40.0f);
        rt.Translate(xTrans, yTrans, 0.0f);

        panelImages[x, y] = img;

        img.color = col;

        return facelet;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // >>> Put animation code here, perhaps...
    //}
}
