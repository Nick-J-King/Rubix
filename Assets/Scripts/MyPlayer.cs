using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MyPlayer : MonoBehaviour
{
    public MyGame myGame;
    public MainCamera mainCamera;
    public MyCube myCube;
    public MouseManager mouseManager;
    public FaceMap faceMap;

    readonly float baseAngleStep = 5.0f;
    float angleStep; // Same as base for normal direction, negative for reverse.

    readonly int firstStep = 2;
    readonly int secondStep = 4;
    readonly int thirdStep = 9;
    readonly int fourthStep = 14;
    readonly int fifthStep = 16;

    // Animation
    int animationStep;
    readonly int lastAnimationStep = 18;

    bool isAnimating;
    RotationDirection rotationDirection;
    CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    CubeSlices cubeSlices;   // Which slices we are currently rotating.


    // Start is called before the first frame update
    void Start()
    {
    }

    // Determine whether to "cycle" the facelets on "strips".
    bool IsAnimationOnStep()
    {
        return (animationStep == firstStep
        || animationStep == secondStep
        || animationStep == thirdStep
        || animationStep == fourthStep
        || animationStep == fifthStep);
    }

    // Update is called once per frame

    void Update()
    {
        if (isAnimating)
        {
            animationStep += 1;

            // Y axis

            // All slices from top to bottom.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s01234)
            {
                faceMap.downPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                faceMap.upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(0, rotationDirection);
                    faceMap.CycleSliceFromTop(1, rotationDirection);
                    faceMap.CycleSliceFromTop(2, rotationDirection);
                    faceMap.CycleSliceFromTop(3, rotationDirection);
                    faceMap.CycleSliceFromTop(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.downPanel, rotationDirection);
                    faceMap.RotateFaceCW90(faceMap.upPanel, rotationDirection);
                    faceMap.downPanel.transform.localEulerAngles = Vector3.zero;
                    faceMap.upPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s4)
            {
                faceMap.upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(0, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.upPanel, rotationDirection);
                    faceMap.upPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First two slices from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s34)
            {
                faceMap.upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(0, rotationDirection);
                    faceMap.CycleSliceFromTop(1, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.upPanel, rotationDirection);
                    faceMap.upPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Second slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s3)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(1, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Third slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s2)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(2, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s1)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(3, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth and Fifth slices from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s01)
            {
                faceMap.downPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(3, rotationDirection);
                    faceMap.CycleSliceFromTop(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.downPanel, rotationDirection);
                    faceMap.downPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }


            // Fifth slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s0)
            {
                faceMap.downPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromTop(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.downPanel, rotationDirection);
                    faceMap.downPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // X axis

            // All slices from left to right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s01234)
            {
                faceMap.leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                faceMap.rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(0, rotationDirection);
                    faceMap.CycleSliceFromRight(1, rotationDirection);
                    faceMap.CycleSliceFromRight(2, rotationDirection);
                    faceMap.CycleSliceFromRight(3, rotationDirection);
                    faceMap.CycleSliceFromRight(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.leftPanel, rotationDirection);
                    faceMap.RotateFaceCW90(faceMap.rightPanel, rotationDirection);
                    faceMap.leftPanel.transform.localEulerAngles = Vector3.zero;
                    faceMap.rightPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s4)
            {
                faceMap.rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(0, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.rightPanel, rotationDirection);
                    faceMap.rightPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First and second slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s34)
            {
                faceMap.rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(0, rotationDirection);
                    faceMap.CycleSliceFromRight(1, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.rightPanel, rotationDirection);
                    faceMap.rightPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Second slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s3)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(1, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Third (middle) slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s2)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(2, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }


            // Fourth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s1)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(3, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth and fifth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s01)
            {
                faceMap.leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(3, rotationDirection);
                    faceMap.CycleSliceFromRight(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.leftPanel, rotationDirection);
                    faceMap.leftPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Fifth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s0)
            {
                faceMap.leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromRight(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.leftPanel, rotationDirection);
                    faceMap.leftPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Z axis

            // All slices from front to back.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s01234)
            {
                faceMap.backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                faceMap.frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(0, rotationDirection);
                    faceMap.CycleSliceFromFront(1, rotationDirection);
                    faceMap.CycleSliceFromFront(2, rotationDirection);
                    faceMap.CycleSliceFromFront(3, rotationDirection);
                    faceMap.CycleSliceFromFront(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.backPanel, rotationDirection);
                    faceMap.RotateFaceACW90(faceMap.frontPanel, rotationDirection);
                    faceMap.backPanel.transform.localEulerAngles = Vector3.zero;
                    faceMap.frontPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s0)
            {
                faceMap.frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(0, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.frontPanel, rotationDirection);
                    faceMap.frontPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First and second slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s01)
            {
                faceMap.frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(0, rotationDirection);
                    faceMap.CycleSliceFromFront(1, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceACW90(faceMap.frontPanel, rotationDirection);
                    faceMap.frontPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }


            // Second slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s1)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(1, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Third slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s2)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(2, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s3)
            {
                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(3, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth and fifth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s34)
            {
                faceMap.backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(3, rotationDirection);
                    faceMap.CycleSliceFromFront(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.backPanel, rotationDirection);
                    faceMap.backPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Fifth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s4)
            {
                faceMap.backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    faceMap.CycleSliceFromFront(4, rotationDirection);
                }

                if (animationStep == lastAnimationStep)
                {
                    faceMap.RotateFaceCW90(faceMap.backPanel, rotationDirection);
                    faceMap.backPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

        }
    }


    // Initiate animation of rotation...
    public void OnRotate(InputAction.CallbackContext context, CubeAxis axis, CubeSlices slices)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        if (isAnimating || myCube.isAnimating)
            return;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotationDirection = RotationDirection.reverse;
            angleStep = -baseAngleStep;
        }
        else
        {
            rotationDirection = RotationDirection.normal;
            angleStep = baseAngleStep;
        }

        myCube.DoAnim(axis, slices, rotationDirection);

        cubeSlices = slices;
        cubeAxis = axis;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnDebugMe(InputAction.CallbackContext context)
    {
        myCube.DebugMe();
    }

    // ALL

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

    // Outer
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

    // Both
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

    // Inner
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

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        // TODO>>> If camera IS in the reset state, reset the cube...
        mainCamera.Start();
        faceMap.ResetPositionAndScale();
        myCube.ResetCube();
        faceMap.ResetMap();
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
        if (faceMap.isDragging)
            return;

        Vector2 move = context.ReadValue<Vector2>();

        if (Mouse.current.leftButton.isPressed)
        {
            mainCamera.OrbitCamera(move);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            //cubeX += move.x;
            //cubeY += move.y;

            float x = mainCamera.cam.pixelRect.x;
            float y = mainCamera.cam.pixelRect.y;
            float w = mainCamera.cam.pixelRect.width;
            float h = mainCamera.cam.pixelRect.height;
            mainCamera.cam.pixelRect = new Rect(x + move.x * 5.0f, y, w - move.x * 5.0f, h);
        }
    }
}
