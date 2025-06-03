using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// TODO: Don't set Cursor if it is already set correctly...

namespace Rubix
{
    public class MouseManager : MonoBehaviour
    {
        //    enum CursorType { pointer = 0, cube = 1, map = 2, sphere = 3 }

        // The manager configuration

        public LayerMask clickableLayer; // Layer that is checked.
        public Canvas canvas; // Canvas with UI components to check.
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

        public bool isFaceMapPanelTop = false;
        public bool isMovesPanelTop = false;
        public bool isControlsPanelTop = false;

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

        //public void Update()
        //{
        //    UpdateDirect();
        //}

        public void UpdateDirect()
        {
            Njk.Log("MouseManager Update Direct");

            ResetFlags();
            CastRayFromMouse(Mouse.current.position.ReadValue());
            SetCursorFromFlags();
        }

        private void ResetFlags()
        {
            isFaceMapPanelHit = false;
            isMovesPanelHit = false;
            isControlsPanelHit = false;

            isFaceMapPanelTop = false;
            isMovesPanelTop = false;
            isControlsPanelTop = false;

            isCubeHit = false;
        }


        private void CastRayFromMouse(Vector2 position)
        {
            _PointerEventData.position = position;

            _results.Clear();
            _Raycaster.Raycast(_PointerEventData, _results);

            bool topHit = true;
            foreach (RaycastResult result in _results)
            {
                if (result.gameObject.name == faceMapPanel.name)
                {
                    isFaceMapPanelHit = true;
                    if (topHit)
                    {
                        isFaceMapPanelTop = true;
                        topHit = false;
                    }
                }

                if (result.gameObject.name == movesPanel.name)
                {
                    isMovesPanelHit = true;
                    if (topHit)
                    {
                        isMovesPanelTop = true;
                        topHit = false;
                    }
                }

                if (result.gameObject.name == controlsPanel.name)
                {
                    isControlsPanelHit = true;
                    if (topHit)
                    {
                        isControlsPanelTop = true;
                        topHit = false;
                    }
                }
            }

        }

        private void SetCursorFromFlags()
        {
            if (isFaceMapPanelTop)
            {
                Cursor.SetCursor(faceMapCursor, _vHotSpot, CursorMode.Auto);
                //_faceMapPanelImage.color = colorPanelSelected;
            }

            if (isMovesPanelTop)
            {
                Cursor.SetCursor(sphereCursor, _vHotSpot, CursorMode.Auto);
                //_movesPanelImage.color = colorPanelSelected;
            }

            if (isControlsPanelTop)
            {
                Cursor.SetCursor(sphereCursor, _vHotSpot, CursorMode.Auto);
                //_controlsPanelImage.color = colorPanelSelected;
            }


            if (isFaceMapPanelHit)
            {
                _faceMapPanelImage.color = colorPanelSelected;
            }
            else
            {
                _faceMapPanelImage.color = colorPanelNotSelected;
            }

            if (isMovesPanelHit)
            {
                _movesPanelImage.color = colorPanelSelected;
            }
            else
            {
                _movesPanelImage.color = colorPanelNotSelected;
            }

            if (isControlsPanelHit)
            {
                _controlsPanelImage.color = colorPanelSelected;
            }
            else
            {
                _controlsPanelImage.color = colorPanelNotSelected;
            }

            if (isFaceMapPanelHit || isMovesPanelHit || isControlsPanelHit)
            {
                return; // Dialogs block the cube.
            }

            // OK, now check the 3D scene...
            if (Physics.Raycast(mainCamera.ScreenPointToRay(_PointerEventData.position), out RaycastHit hit, 50,
                    _clickableLayerValue))
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
                // Nothing hit, so use a generic pointer.
            }
        }
    }
}