﻿using Rubix.Data;
using Rubix.GUI;
using Rubix.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Rubix
{

    public class MyPlayer : MonoBehaviour
    {
        // Animation
        public AnimationController animationController;

        // GUI
        public MainCamera mainCamera;
        public MyCube myCube;
        public MouseManager mouseManager;

        // UI
        public FaceMapPanel faceMapPanel;
        public MovesPanel movesPanel;
        public ControlsPanel controlsPanel;


        // Get the AnimationController to do the animation of the Cube and the Map.
        private void OnRotate(InputAction.CallbackContext context, CubeAxis axis, CubeSlices slices)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            AnimationSpecification animationSpecification;
            animationSpecification.cubeAxis = axis;
            animationSpecification.cubeSlices = slices;

            if (Keyboard.current.leftShiftKey.isPressed)
            {
                animationSpecification.rotationDirection = RotationDirection.reverse;
            }
            else
            {
                animationSpecification.rotationDirection = RotationDirection.normal;
            }

            if (Keyboard.current.leftCtrlKey.isPressed)
            {
                animationSpecification.moveType = MoveType.doubleMove;
            }
            else
            {
                animationSpecification.moveType = MoveType.singleMove;
            }

            animationController.AddAnimation(animationSpecification);
        }


        // All (entire cube).

        public void OnRotateAllLR(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s01234);
        }

        public void OnRotateAllUD(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s01234);
        }

        public void OnRotateAllFB(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s01234);
        }


        // Outer slices.

        public void OnRotateOuterL(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s0);
        }

        public void OnRotateOuterR(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s4);
        }

        public void OnRotateOuterD(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s0);
        }

        public void OnRotateOuterU(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s4);
        }

        public void OnRotateOuterF(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s0);
        }

        public void OnRotateOuterB(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s4);
        }


        // Both slices (outermost and next one in).

        public void OnRotateBothL(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s01);
        }

        public void OnRotateBothR(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s34);
        }

        public void OnRotateBothD(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s01);
        }

        public void OnRotateBothU(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s34);
        }

        public void OnRotateBothF(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s01);
        }

        public void OnRotateBothB(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s34);
        }


        // Inner slices.

        public void OnRotateInnerL(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s1);
        }

        public void OnRotateInnerR(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s3);
        }

        public void OnRotateInnerD(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s1);
        }

        public void OnRotateInnerU(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s3);
        }

        public void OnRotateInnerF(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s1);
        }

        public void OnRotateInnerB(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s3);
        }


        // Midline slices.

        public void OnRotateMidLR(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.x, CubeSlices.s2);
        }

        public void OnRotateMidUD(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.y, CubeSlices.s2);
        }

        public void OnRotateMidFB(InputAction.CallbackContext context)
        {
            OnRotate(context, CubeAxis.z, CubeSlices.s2);
        }


        // Random move.

        public void OnRotateRandom(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            animationController.AddRandomMove();
        }


        // Miscellaneous

        public void ToggleFaceMapViewable(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            faceMapPanel.ToggleViewable();
        }


        public void ToggleMovesPanelViewable(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            movesPanel.ToggleViewable();
        }


        public void ToggleControlsPanelViewable(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            controlsPanel.ToggleViewable();
        }


        public void CycleMapTextures(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            faceMapPanel.CycleMapTextures();
        }


        public void CycleCubeTextures(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            myCube.CycleTextures();
        }


        public void OnResetView(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            mainCamera.ResetViewport();
            faceMapPanel.ResetPositionAndScale();
            movesPanel.ResetPositionAndScale();
            controlsPanel.ResetPositionAndScale();
            myCube.ResetScale();
        }


        public void OnResetConfiguration(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            animationController.StopAnimation();

            movesPanel.ClearMoves();

            myCube.ResetCube();
            faceMapPanel.ResetMap();
        }


        public void OnReassemble(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            animationController.StopAnimation();

            movesPanel.ClearMoves();

            myCube.ReassembleCube();
            faceMapPanel.ResetMap();
        }


        public void OnMyDestroy(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            animationController.StopAnimation();

            myCube.DoMyDestroy();
        }


        public void OnZoom(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            var scrollValue = context.action.ReadValue<float>();


            if (faceMapPanel.isDragging)
            {
                faceMapPanel.ScaleUp(scrollValue, 0.1f, 0.1f, 10.0f);
            }
            else if (movesPanel.isDragging)
            {
                movesPanel.ScaleUp(scrollValue, 0.1f, 0.1f, 10.0f);
            }
            else if (controlsPanel.isDragging)
            {
                controlsPanel.ScaleUp(scrollValue, 0.1f, 0.1f, 10.0f);
            }


            else if (mouseManager.isFaceMapPanelTop)
            {
                faceMapPanel.ScaleUp(scrollValue, 0.1f, 0.1f, 10.0f);
            }
            else if (mouseManager.isMovesPanelTop)
            {
                movesPanel.ScaleUp(scrollValue, 0.1f, 0.1f, 10.0f);
            }
            else if (mouseManager.isControlsPanelTop)
            {
                controlsPanel.ScaleUp(scrollValue, 0.1f, 0.1f, 10.0f);
            }
            else if (mouseManager.isCubeHit)
            {
                myCube.ScaleUp(scrollValue, 0.05f, 0.05f, 2.0f);
            }
        }


        public void OnEscape(InputAction.CallbackContext context)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }


        public void OnMouseClick(InputAction.CallbackContext context)
        {
//            NJK.Log($"OnMouseClick {context.phase}");

            if (context.phase != InputActionPhase.Started)
                return;

            mouseManager.UpdateDirect(); // <><><>
        }


        public void OnMouseDelta(InputAction.CallbackContext context)
        {
//            NJK.Log($"OnMouseDelta {context.phase}");

            mouseManager.UpdateDirect(); // <><><>

            if (faceMapPanel.isDragging || movesPanel.isDragging || controlsPanel.isDragging ||
                mouseManager.isMovesPanelHit)
                return;

            if (EventSystem.current.IsPointerOverGameObject()) // <><><>
                return;

            Vector2 move = context.ReadValue<Vector2>();

            if (Mouse.current.leftButton.isPressed)
            {
                mainCamera.OrientCamera(move);
            }

            if (Mouse.current.rightButton.isPressed)
            {
                mainCamera.MoveViewport(move.x * 5.0f);
            }
        }


        public void OnDebug(InputAction.CallbackContext context)
        {
            Debug.Log(Mouse.current.position.ReadValue());
        }
    }
}