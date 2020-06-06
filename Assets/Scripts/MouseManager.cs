using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


// TODO: Don't set Cursor if it is already set correctly...

namespace Rubix.GUI
{ 
    public class MouseManager : MonoBehaviour
    {
    //    enum CursorType { pointer = 0, cube = 1, map = 2, sphere = 3 }

        // The manager configuration

        public LayerMask clickableLayer;    // Layer that is checked.
        public Canvas canvas;               // Canvas with UI components to check.
        public Camera mainCamera;

        public GameObject faceMapPanel;
        public GameObject movesPanel;       
        public GameObject controlsPanel;
            // The panels that can be selected and dragged around.

        public Color colorPanelSelected;
        public Color colorPanelNotSelected;

        public Texture2D pointerCursor;
        public Texture2D cubeCursor;
        public Texture2D faceMapCursor;
        public Texture2D sphereCursor;

        // Status (out only)... TODO
        public bool isFaceMapPanelHit = false;
        public bool isMovesPanelHit = false;
        public bool isControlsPanelHit = false;
        public bool isCubeHit = false;
            // Used to relay status.

        Vector2 _vHotSpot;
        Image _faceMapPanelImage;
        Image _movesPanelImage;
        Image _controlsPanelImage;

        GraphicRaycaster _Raycaster;
        EventSystem _EventSystem;
        PointerEventData _PointerEventData;
        List<RaycastResult> _results;
        int _clickableLayerValue;


        private void Awake()
        {
            _Raycaster = canvas.GetComponent<GraphicRaycaster>();
            _EventSystem = GetComponent<EventSystem>();
            _PointerEventData = new PointerEventData(_EventSystem);
            _results = new List<RaycastResult>();
            _clickableLayerValue = clickableLayer.value;

            _vHotSpot.x = 16;
            _vHotSpot.y = 16;
            _faceMapPanelImage = faceMapPanel.GetComponent<Image>();
            _movesPanelImage = movesPanel.GetComponent<Image>();
            _controlsPanelImage = controlsPanel.GetComponent<Image>();
        }


        private void Update()
        {
            isFaceMapPanelHit = false;
            isMovesPanelHit = false;
            isControlsPanelHit = false;
            isCubeHit = false;

            _PointerEventData.position = Mouse.current.position.ReadValue();

            // Raycast using the Graphics Raycaster and mouse click position
            _results.Clear();
            _Raycaster.Raycast(_PointerEventData, _results);

            // For every result returned, output the name of the GameObject on the Canvas hit by the Ray.
            // Check for the FaceMap panel.
            foreach (RaycastResult result in _results)
            {
                if (result.gameObject.name == faceMapPanel.name)
                    isFaceMapPanelHit = true;

                if (result.gameObject.name == movesPanel.name)
                    isMovesPanelHit = true;

                if (result.gameObject.name == controlsPanel.name)
                    isControlsPanelHit = true;
            }

            if (isFaceMapPanelHit)
            {
                Cursor.SetCursor(faceMapCursor, _vHotSpot, CursorMode.Auto);
                _faceMapPanelImage.color = colorPanelSelected;
                return;
            }
            else
            {
                _faceMapPanelImage.color = colorPanelNotSelected;
            }

            if (isMovesPanelHit)
            {
                Cursor.SetCursor(sphereCursor, _vHotSpot, CursorMode.Auto);
                _movesPanelImage.color = colorPanelSelected;
                return;
            }
            else
            {
                _movesPanelImage.color = colorPanelNotSelected;
            }

            if (isControlsPanelHit)
            {
                Cursor.SetCursor(sphereCursor, _vHotSpot, CursorMode.Auto);
                _controlsPanelImage.color = colorPanelSelected;
                return;
            }
            else
            {
                _controlsPanelImage.color = colorPanelNotSelected;
            }

            // OK, now check the 3D scene...
            if (Physics.Raycast(mainCamera.ScreenPointToRay(_PointerEventData.position), out RaycastHit hit, 50, _clickableLayerValue))
            {
                if (hit.collider.gameObject.CompareTag("Cubelet"))
                {
                    Cursor.SetCursor(cubeCursor, _vHotSpot, CursorMode.Auto);
                    isCubeHit = true;
                }
                else
                {
                    Cursor.SetCursor(sphereCursor, _vHotSpot, CursorMode.Auto);
                        // A generic "sphere" for any other 3D object.
                }
            }
            else
            {
                Cursor.SetCursor(pointerCursor, _vHotSpot, CursorMode.Auto);
                    // Nothing hit, so use generic pointer.
            }
        }
    }
}
