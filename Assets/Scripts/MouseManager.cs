using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// TODO: Don't set Cursor if it is already set correctly...

public class MouseManager : MonoBehaviour
{
    // The manager configuration

    public LayerMask clickableLayer;    // Layer that is checked.
    public Canvas canvas;               // Canvas with UI components to check.
    public Camera mainCamera;

    public GameObject mapPanel;         // The FaceMap that can be selected and dragged around.
    public Color colorMapSelected;
    public Color colorMapNotSelected;

    public Texture2D pointer;
    public Texture2D cube;
    public Texture2D map;
    public Texture2D sphere;
        // Cursors to use for each condition.

    // Status (out only)... TODO
    public bool isMapHit = false;
    public bool isCubeHit = false;
        // Used to relay status.

    Vector2 vHotSpot;
    Image mapPanelImage;
        // Don't keep newing these...

    GraphicRaycaster m_Raycaster;
    EventSystem m_EventSystem;
    PointerEventData m_PointerEventData;
    List<RaycastResult> m_results;
    int clickableLayerValue;
        // Internals.


    void Awake()
    {
        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_results = new List<RaycastResult>();
        clickableLayerValue = clickableLayer.value;

        vHotSpot.x = 16;
        vHotSpot.y = 16;
        mapPanelImage = mapPanel.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        isMapHit = false;
        isCubeHit = false;

        m_PointerEventData.position = Input.mousePosition;

        // Raycast using the Graphics Raycaster and mouse click position
        m_results.Clear();
        m_Raycaster.Raycast(m_PointerEventData, m_results);

        // For every result returned, output the name of the GameObject on the Canvas hit by the Ray.
        // Check for the FaceMap panel.
        foreach (RaycastResult result in m_results)
        {
            if (result.gameObject.name == "PanelMap")
                isMapHit = true;
        }

        // Are we over the FaceMap panel?
        if (isMapHit)
        {
            Cursor.SetCursor(map, vHotSpot, CursorMode.Auto);
            mapPanelImage.color = colorMapSelected;
            return;
        }
        else
        {
            mapPanelImage.color = colorMapNotSelected;
        }

        // OK, now check the 3D scene...
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 50, clickableLayerValue))
        {
            if (hit.collider.gameObject.CompareTag("Cubelet"))
            {
                Cursor.SetCursor(cube, vHotSpot, CursorMode.Auto);
                isCubeHit = true;
            }
            else
            {
                Cursor.SetCursor(sphere, vHotSpot, CursorMode.Auto);
                    // A generic "sphere" for any other 3D object.
            }
        }
        else
        {
            Cursor.SetCursor(pointer, vHotSpot, CursorMode.Auto);
                // Nothing hit, so use generic pointer.
        }
    }
}
