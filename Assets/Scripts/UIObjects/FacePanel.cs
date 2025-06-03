using UnityEngine;
using UnityEngine.UI;
using Rubix.Animation;


namespace Rubix.UI
{ 
    public class FaceletData
    {
        public GameObject facelet;
        public Sprite spriteNumber;
    }


    public class FacePanel : MonoBehaviour
    {
        // enum CubeColours { Top = 0, Bottom = 1, Front = 2, Back = 3, Left = 4, Right = 5 };

        public FaceMapPanel panelMap;        // The map this face panel belongs to.
        public FacePanel panelFace;     // This face panel.

        public bool inverted;           // Whether to invert this panel (rotate 180 degrees).

        public FaceletData [,] faceletData;
            // These facelet panels and sprites must be accessed by the FaceMap...

        Color[,] pOrigColor;
        Sprite[,] pOrigSprite;
            // Used to "reset" the face panel.

        DefaultControls.Resources uiResources;


        // The Face map has been initialised in Awake, so we can use its facelet sprites.
        public void Start()
        {
            uiResources = new DefaultControls.Resources();

            faceletData = new FaceletData[5, 5];

            pOrigColor = new Color[5, 5];
            pOrigSprite = new Sprite[5, 5];

            Color colour = GetColourForFace();

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    faceletData[x, y] = CreateFacelet(x, y, colour);

                    pOrigColor[x, y] = colour;
                    pOrigSprite[x, y] = faceletData[x, y].facelet.GetComponent<Image>().sprite;
                }
            }
        }


        Color GetColourForFace()
        { 
            Color colour = UnityEngine.Color.black;

            switch (name)
            {
                case "PanelTop":        // Light blue.
                    colour.r = 0.2156f;
                    colour.g = 0.5294f;
                    colour.b = 0.9843f;
                    break;

                case "PanelBottom":
                    colour = UnityEngine.Color.green;
                    break;

                case "PanelLeft":
                    colour = UnityEngine.Color.red;
                    break;

                case "PanelRight":  // Orange
                    colour.r = 1.0f;
                    colour.g = 0.63f;
                    colour.b = 0.0f;
                    break;

                case "PanelFront":
                    colour = UnityEngine.Color.yellow;
                    break;

                case "PanelBack":
                    colour = UnityEngine.Color.white;
                    break;

                default:
                    colour = UnityEngine.Color.black;
                    break;
            }

            return colour;
        }


        public void SetTexture(TextureType textureType)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Image faceImage = faceletData[x, y].facelet.GetComponent<Image>();
                    if (textureType == TextureType.none)
                    {
                        faceImage.sprite = null;
                    }
                    else if (textureType == TextureType.plain)
                    {
                        faceImage.sprite = panelMap.spritePlain;
                    }
                    else
                    {
                        faceImage.sprite = faceletData[x, y].spriteNumber;
                    }
                }
            }
        }


        // Reset the facelets to their original colour, sprite and orientation.
        public void ResetFace(TextureType textureType)
        {
            transform.rotation = Quaternion.identity;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    faceletData[x, y].facelet.transform.rotation = Quaternion.identity;
                    faceletData[x, y].spriteNumber = pOrigSprite[x, y];

                    Image faceImage = faceletData[x, y].facelet.GetComponent<Image>();
                    faceImage.color = pOrigColor[x, y];

                    if (textureType == TextureType.none)
                    {
                        faceImage.sprite = null;
                    }
                    else if (textureType == TextureType.plain)
                    {
                        faceImage.sprite = panelMap.spritePlain;
                    }
                    else
                    {
                        faceImage.sprite = pOrigSprite[x, y];;
                    }
                }
            }
        }


        FaceletData CreateFacelet(int x, int y, Color col)
        {
            FaceletData faceletData = new FaceletData();

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
            faceletData.facelet = facelet;

            facelet.name = codeName;
            facelet.transform.SetParent(panelFace.transform, false);

            Image img = facelet.GetComponent<Image>();
            img.color = col;

            if (inverted)
            {
                img.sprite = panelMap.faceSpritesInverted[x,y];
                faceletData.spriteNumber = panelMap.faceSpritesInverted[x,y];
            }
            else
            {
                img.sprite = panelMap.faceSprites[x,y];
                faceletData.spriteNumber = panelMap.faceSprites[x,y];
            }

            RectTransform rt = facelet.GetComponent<RectTransform>();

            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 40.0f);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40.0f);

            rt.Translate(xTrans, yTrans, 0.0f);

            return faceletData;
        }
    }
}
