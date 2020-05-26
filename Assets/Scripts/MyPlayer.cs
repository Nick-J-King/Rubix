using UnityEngine;
using UnityEngine.InputSystem;


public class MyPlayer : MonoBehaviour
{
    public MainCamera mainCamera;
    public MyCube myCube;
    public FaceMap faceMap;
    public MovesPanel movesPanel;

    public MouseManager mouseManager;
    public AnimationController animationController;


    void Start()
    {
    }


    // Get the AnimationController to do the animation of the Cube and the Map.
    public void OnRotate(InputAction.CallbackContext context, CubeAxis axis, CubeSlices slices)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        if (myCube.isAnimating || faceMap.isAnimating)
            return;

        AnimationSpecification animationSpecification;
        animationSpecification.cubeAxis = axis;
        animationSpecification.cubeSlices = slices;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animationSpecification.rotationDirection = RotationDirection.reverse;
        }
        else
        {
            animationSpecification.rotationDirection = RotationDirection.normal;
        }

        animationController.StartAnimation(animationSpecification);
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


    // Miscellaneous

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        mainCamera.Start();
        faceMap.ResetPositionAndScale();
        movesPanel.ResetPositionAndScale();
        myCube.ResetScale();
    }


    public void OnResetConfiguration(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        animationController.StopAnimation();

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


    public void OnScroll(InputAction.CallbackContext context)
    {
        var d = Input.GetAxis("Mouse ScrollWheel");

        if (mouseManager.isMapHit)
        { 
            if (d > 0.0f)
            {
                // scroll up
                float ls = faceMap.transform.localScale.x;
                ls += 0.1f;
                if (ls > 10.0f)
                    ls = 10.0f;

                faceMap.transform.localScale = new Vector3(ls, ls, 1.0f);
            }
            else if (d < 0.0f)
            {
                // scroll down
                float ls = faceMap.transform.localScale.x;
                ls -= 0.1f;
                if (ls < 0.1f)
                    ls = 0.1f;

                faceMap.transform.localScale = new Vector3(ls, ls, 1.0f);
            }
        }
        else if (mouseManager.isMovesHit)
        { 
            if (d > 0.0f)
            {
                // scroll up
                float ls = movesPanel.transform.localScale.x;
                ls += 0.1f;
                if (ls > 10.0f)
                    ls = 10.0f;

                movesPanel.transform.localScale = new Vector3(ls, ls, 1.0f);
            }
            else if (d < 0.0f)
            {
                // scroll down
                float ls = movesPanel.transform.localScale.x;
                ls -= 0.1f;
                if (ls < 0.1f)
                    ls = 0.1f;

                movesPanel.transform.localScale = new Vector3(ls, ls, 1.0f);
            }
        }
        else if (mouseManager.isCubeHit)
        {
            if (d > 0.0f)
            {
                // scroll up
                float ls = myCube.transform.localScale.x;
                ls += 0.05f;
                if (ls > 2.0f)
                    ls = 2.0f;

                myCube.transform.localScale = new Vector3(ls, ls, ls);
            }
            else if (d < 0.0f)
            {
                // scroll down
                float ls = myCube.transform.localScale.x;
                ls -= 0.05f;
                if (ls < 0.05f)
                    ls = 0.05f;

                myCube.transform.localScale = new Vector3(ls, ls, ls);
            }
        }
    }


    public void OnEscape(InputAction.CallbackContext context)
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if (faceMap.isDragging || movesPanel.isDragging)
            return;

        Vector2 move = context.ReadValue<Vector2>();

        if (Mouse.current.leftButton.isPressed)
        {
            mainCamera.OrbitCamera(move);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            float x = mainCamera.cam.pixelRect.x;
            float y = mainCamera.cam.pixelRect.y;
            float w = mainCamera.cam.pixelRect.width;
            float h = mainCamera.cam.pixelRect.height;
            mainCamera.cam.pixelRect = new Rect(x + move.x * 5.0f, y, w - move.x * 5.0f, h);
        }
    }


    public void OnDebugMe(InputAction.CallbackContext context)
    {
        //myCube.DebugMe();
    }
}
