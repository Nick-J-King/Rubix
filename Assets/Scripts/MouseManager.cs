using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;
    public Canvas canvas;

    public GameObject mapPanel;

    public Texture2D pointer;
    public Texture2D cube;
    public Texture2D map;
    public Texture2D sphere;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public bool isMapHit = false;
    public bool isCubeHit = false;


    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        isMapHit = false;
        isCubeHit = false;

        //Check if the left Mouse button is clicked
        //if (Input.GetKey(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "PanelMap")
                    isMapHit = true;
            }
        }

        if (isMapHit)
        {
            Cursor.SetCursor(map, new Vector2(16, 16), CursorMode.Auto);
            mapPanel.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.4f);
            return;
        }
        else
        {
            mapPanel.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 0.2f);
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 50, clickableLayer.value))
        {
            if (hit.collider.gameObject.tag == "Cubelet")
            {
                Cursor.SetCursor(cube, new Vector2(16, 16), CursorMode.Auto);
                isCubeHit = true;
            }
            else
            {
                Cursor.SetCursor(sphere, new Vector2(16, 16), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
        }
    }
}
