using UnityEngine;
using UnityEngine.InputSystem;


public class MyPlayer : MonoBehaviour
{
    public MainCamera mainCamera;
    public MyCube myCube;
    public FaceMap faceMap;
    public MovesPanel movesPanel;
    public ControlsPanel controlsPanel;

    public MouseManager mouseManager;
    public AnimationController animationController;


    // Get the AnimationController to do the animation of the Cube and the Map.
    public void OnRotate(InputAction.CallbackContext context, CubeAxis axis, CubeSlices slices)
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


    public void OnRotateRandom(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        animationController.DoRandomMove();
    }


    // Miscellaneous

    public void ToggleMap(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        faceMap.gameObject.SetActive(!faceMap.gameObject.activeInHierarchy);
    }


    public void ToggleMoves(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        movesPanel.gameObject.SetActive(!movesPanel.gameObject.activeInHierarchy);
    }

    
    public void ToggleControlsPanel(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        controlsPanel.gameObject.SetActive(!controlsPanel.gameObject.activeInHierarchy);
    }


    public void ToggleTextures(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        faceMap.ToggleTextures();
        myCube.ToggleTextures();
    }


    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        mainCamera.ResetViewport();
        faceMap.ResetPositionAndScale();
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
        faceMap.ResetMap();
    }


    public void OnMyDestroy(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        animationController.StopAnimation();

        myCube.DoMyDestroy();
    }


    void ScaleUp(GameObject go, float factor, float step, float min, float max)
    {
        float ls = go.transform.localScale.x;

        if (factor > 0.0f)      // scroll up
        {
            ls += step;
            if (ls > max)
                ls = max;
        }
        else if (factor < 0.0f) // scroll down
        {
            ls -= step;
            if (ls < min)
                ls = min;
        }
        go.transform.localScale = new Vector3(ls, ls, ls);
    }


    public void OnScroll(InputAction.CallbackContext context)
    {
        var scrollValue = context.action.ReadValue<float>();

        if (mouseManager.isMapHit)
        {
            ScaleUp(faceMap.gameObject, scrollValue, 0.1f, 0.1f, 10.0f);
        }
        else if (mouseManager.isMovesHit)
        { 
            ScaleUp(movesPanel.gameObject, scrollValue, 0.1f, 0.1f, 10.0f);
        }
        else if (mouseManager.isControlsHit)
        { 
            ScaleUp(controlsPanel.gameObject, scrollValue, 0.1f, 0.1f, 10.0f);
        }
        else if (mouseManager.isCubeHit)
        {
            ScaleUp(myCube.gameObject, scrollValue, 0.05f, 0.05f, 2.0f);
        }
    }


    public void OnEscape(InputAction.CallbackContext context)
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if (faceMap.isDragging || movesPanel.isDragging || controlsPanel.isDragging || mouseManager.isMovesHit)
            return;

        Vector2 move = context.ReadValue<Vector2>();

        if (Mouse.current.leftButton.isPressed)
        {
            mainCamera.OrbitCamera(move);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            float moveStep = 5.0f;

            float x = mainCamera.cam.pixelRect.x;
            float y = mainCamera.cam.pixelRect.y;
            float w = mainCamera.cam.pixelRect.width;
            float h = mainCamera.cam.pixelRect.height;

            mainCamera.cam.pixelRect = new Rect(x + move.x * moveStep, y, w - move.x * moveStep, h);
        }
    }
}
