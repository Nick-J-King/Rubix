using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MyPlayer : MonoBehaviour
{
    public MyGame myGame;
    public MainCamera mainCamera;
    public MyCube myCube;

    public FacePanel frontPanel;
    public FacePanel backPanel;
    public FacePanel leftPanel;
    public FacePanel rightPanel;
    public FacePanel upPanel;
    public FacePanel downPanel;

    private readonly float angleStep = 5.0f;

    private readonly int firstStep = 2;
    private readonly int secondStep = 4;
    private readonly int thirdStep = 9;
    private readonly int fourthStep = 14;
    private readonly int fifthStep = 16;

    // Animation
    private int animationStep;
    private readonly int lastAnimationStep = 18;

    private bool isAnimating;
    private CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    private CubeSlices cubeSlices;   // Which slices we are currently rotating.


    // Start is called before the first frame update
    void Start()
    {
    }

    // Determine whether to "cycle" the facelets on "strips".
    private bool IsAnimationOnStep()
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

            // First slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s4)
            {
                upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromTop(0);
                }

                if (upPanel.transform.localEulerAngles.z <= 270.0f)
                {
                    RotateFaceCW90(upPanel);
                    upPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First two slices from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s34)
            {
                upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromTop(0);
                    CycleSliceFromTop(1);
                }

                if (upPanel.transform.localEulerAngles.z <= 270.0f)
                {
                    RotateFaceCW90(upPanel);
                    upPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Second slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s3)
            {
                if (IsAnimationOnStep())
                {
                    CycleSliceFromTop(1);
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
                    CycleSliceFromTop(2);
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
                    CycleSliceFromTop(3);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth and Fifth slices from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s01)
            {
                downPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromTop(3);
                    CycleSliceFromTop(4);
                }

                if (downPanel.transform.localEulerAngles.z >= 90.0f)
                {
                    RotateFaceACW90(downPanel);
                    downPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }


            // Fifth slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s0)
            {
                downPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromTop(4);
                }

                if (downPanel.transform.localEulerAngles.z >= 90.0f)
                {
                    RotateFaceACW90(downPanel);
                    downPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // X axis

            // First slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s4)
            {
                rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromRight(0);
                }

                if (rightPanel.transform.localEulerAngles.z <= 270.0f)
                {
                    RotateFaceCW90(rightPanel);
                    rightPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First and second slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s34)
            {
                rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromRight(0);
                    CycleSliceFromRight(1);
                }

                if (rightPanel.transform.localEulerAngles.z <= 270.0f)
                {
                    RotateFaceCW90(rightPanel);
                    rightPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Second slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s3)
            {
                if (IsAnimationOnStep())
                {
                    CycleSliceFromRight(1);
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
                    CycleSliceFromRight(2);
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
                    CycleSliceFromRight(3);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth and fifth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s01)
            {
                leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromRight(3);
                    CycleSliceFromRight(4);
                }

                if (leftPanel.transform.localEulerAngles.z >= 90.0f)
                {
                    RotateFaceACW90(leftPanel);
                    leftPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Fifth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s0)
            {
                leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromRight(4);
                }

                if (leftPanel.transform.localEulerAngles.z >= 90.0f)
                {
                    RotateFaceACW90(leftPanel);
                    leftPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Z axis

            // First slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s0)
            {
                frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromFront(0);
                }

                if (frontPanel.transform.localEulerAngles.z >= 90.0f)
                {
                    RotateFaceACW90(frontPanel);
                    frontPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // First and second slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s01)
            {
                frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromFront(0);
                    CycleSliceFromFront(1);
                }

                if (frontPanel.transform.localEulerAngles.z >= 90.0f)
                {
                    RotateFaceACW90(frontPanel);
                    frontPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }


            // Second slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s1)
            {
                if (IsAnimationOnStep())
                {
                    CycleSliceFromFront(1);
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
                    CycleSliceFromFront(2);
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
                    CycleSliceFromFront(3);
                }

                if (animationStep == lastAnimationStep)
                {
                    isAnimating = false;
                }
            }

            // Fourth and fifth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s34)
            {
                backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromFront(3);
                    CycleSliceFromFront(4);
                }

                if (backPanel.transform.localEulerAngles.z <= 270.0f)
                {
                    RotateFaceCW90(backPanel);
                    backPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

            // Fifth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s4)
            {
                backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);

                if (IsAnimationOnStep())
                {
                    CycleSliceFromFront(4);
                }

                if (backPanel.transform.localEulerAngles.z <= 270.0f)
                {
                    RotateFaceCW90(backPanel);
                    backPanel.transform.localEulerAngles = Vector3.zero;
                    isAnimating = false;
                }
            }

        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
                return;

        // >> If camera IS in the reset state, reset the cube...
        mainCamera.Start();
    }

    // Y axis

    // nSlice = 0 is Top. nSlice = 4 is Bottom.
    public void CycleSliceFromTop(int nSlice)
    {
        GameObject[] a = new GameObject[20];

        a[0] = frontPanel.pFacelets[0, 4 - nSlice];
        a[1] = frontPanel.pFacelets[1, 4 - nSlice];
        a[2] = frontPanel.pFacelets[2, 4 - nSlice];
        a[3] = frontPanel.pFacelets[3, 4 - nSlice];
        a[4] = frontPanel.pFacelets[4, 4 - nSlice];

        a[5] = rightPanel.pFacelets[0, 4 - nSlice];
        a[6] = rightPanel.pFacelets[1, 4 - nSlice];
        a[7] = rightPanel.pFacelets[2, 4 - nSlice];
        a[8] = rightPanel.pFacelets[3, 4 - nSlice];
        a[9] = rightPanel.pFacelets[4, 4 - nSlice];

        a[10] = backPanel.pFacelets[4, nSlice];
        a[11] = backPanel.pFacelets[3, nSlice];
        a[12] = backPanel.pFacelets[2, nSlice];
        a[13] = backPanel.pFacelets[1, nSlice];
        a[14] = backPanel.pFacelets[0, nSlice];

        a[15] = leftPanel.pFacelets[0, 4 - nSlice];
        a[16] = leftPanel.pFacelets[1, 4 - nSlice];
        a[17] = leftPanel.pFacelets[2, 4 - nSlice];
        a[18] = leftPanel.pFacelets[3, 4 - nSlice];
        a[19] = leftPanel.pFacelets[4, 4 - nSlice];

        CycleFacelets20(a);
    }

    // X axis

    // nSlice = 0 is Right. nSlice = 4 is Left.
    public void CycleSliceFromRight(int nSlice)
    {
        GameObject[] a = new GameObject[20];

        a[0] = frontPanel.pFacelets[4 - nSlice, 0];
        a[1] = frontPanel.pFacelets[4 - nSlice, 1];
        a[2] = frontPanel.pFacelets[4 - nSlice, 2];
        a[3] = frontPanel.pFacelets[4 - nSlice, 3];
        a[4] = frontPanel.pFacelets[4 - nSlice, 4];

        a[5] = upPanel.pFacelets[4 - nSlice, 0];
        a[6] = upPanel.pFacelets[4 - nSlice, 1];
        a[7] = upPanel.pFacelets[4 - nSlice, 2];
        a[8] = upPanel.pFacelets[4 - nSlice, 3];
        a[9] = upPanel.pFacelets[4 - nSlice, 4];

        a[10] = backPanel.pFacelets[4 - nSlice, 0];
        a[11] = backPanel.pFacelets[4 - nSlice, 1];
        a[12] = backPanel.pFacelets[4 - nSlice, 2];
        a[13] = backPanel.pFacelets[4 - nSlice, 3];
        a[14] = backPanel.pFacelets[4 - nSlice, 4];

        a[15] = downPanel.pFacelets[4 - nSlice, 0];
        a[16] = downPanel.pFacelets[4 - nSlice, 1];
        a[17] = downPanel.pFacelets[4 - nSlice, 2];
        a[18] = downPanel.pFacelets[4 - nSlice, 3];
        a[19] = downPanel.pFacelets[4 - nSlice, 4];

        CycleFacelets20A(a);
    }

    // Z axis

    // nSlice = 0 is Front. nSlice = 4 is Back.
    public void CycleSliceFromFront(int nSlice)
    {
        GameObject[] a = new GameObject[20];

        a[0] = downPanel.pFacelets[0, 4 - nSlice];
        a[1] = downPanel.pFacelets[1, 4 - nSlice];
        a[2] = downPanel.pFacelets[2, 4 - nSlice];
        a[3] = downPanel.pFacelets[3, 4 - nSlice];
        a[4] = downPanel.pFacelets[4, 4 - nSlice];

        a[5] = rightPanel.pFacelets[nSlice, 0];
        a[6] = rightPanel.pFacelets[nSlice, 1];
        a[7] = rightPanel.pFacelets[nSlice, 2];
        a[8] = rightPanel.pFacelets[nSlice, 3];
        a[9] = rightPanel.pFacelets[nSlice, 4];

        a[10] = upPanel.pFacelets[4, nSlice];
        a[11] = upPanel.pFacelets[3, nSlice];
        a[12] = upPanel.pFacelets[2, nSlice];
        a[13] = upPanel.pFacelets[1, nSlice];
        a[14] = upPanel.pFacelets[0, nSlice];

        a[15] = leftPanel.pFacelets[4 - nSlice, 4];
        a[16] = leftPanel.pFacelets[4 - nSlice, 3];
        a[17] = leftPanel.pFacelets[4 - nSlice, 2];
        a[18] = leftPanel.pFacelets[4 - nSlice, 1];
        a[19] = leftPanel.pFacelets[4 - nSlice, 0];

        CycleFacelets20A(a);
    }



    public void RotateFaceCW90(FacePanel face)
    {
        GameObject[] a = new GameObject[4];

        // The outer edge.

        a[0] = face.pFacelets[0, 0];
        a[1] = face.pFacelets[4, 0];
        a[2] = face.pFacelets[4, 4];
        a[3] = face.pFacelets[0, 4];
        CycleFacelets4(a);

        a[0] = face.pFacelets[1, 0];
        a[1] = face.pFacelets[4, 1];
        a[2] = face.pFacelets[3, 4];
        a[3] = face.pFacelets[0, 3];
        CycleFacelets4(a);

        a[0] = face.pFacelets[2, 0];
        a[1] = face.pFacelets[4, 2];
        a[2] = face.pFacelets[2, 4];
        a[3] = face.pFacelets[0, 2];
        CycleFacelets4(a);

        a[0] = face.pFacelets[3, 0];
        a[1] = face.pFacelets[4, 3];
        a[2] = face.pFacelets[1, 4];
        a[3] = face.pFacelets[0, 1];
        CycleFacelets4(a);

        // The inner square

        a[0] = face.pFacelets[1, 1];
        a[1] = face.pFacelets[3, 1];
        a[2] = face.pFacelets[3, 3];
        a[3] = face.pFacelets[1, 3];
        CycleFacelets4(a);

        a[0] = face.pFacelets[2, 1];
        a[1] = face.pFacelets[3, 2];
        a[2] = face.pFacelets[2, 3];
        a[3] = face.pFacelets[1, 2];
        CycleFacelets4(a);

        // Now, rotate the facelets about their centres.
        /*
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                face.pFacelets[x,y].transform.Rotate(0.0f, 0.0f, -90.0f);
            }
        }
        */
    }

    public void RotateFaceACW90(FacePanel face)
    {
        GameObject[] a = new GameObject[4];

        // The outer edge.

        a[0] = face.pFacelets[0, 0];
        a[1] = face.pFacelets[4, 0];
        a[2] = face.pFacelets[4, 4];
        a[3] = face.pFacelets[0, 4];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[1, 0];
        a[1] = face.pFacelets[4, 1];
        a[2] = face.pFacelets[3, 4];
        a[3] = face.pFacelets[0, 3];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[2, 0];
        a[1] = face.pFacelets[4, 2];
        a[2] = face.pFacelets[2, 4];
        a[3] = face.pFacelets[0, 2];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[3, 0];
        a[1] = face.pFacelets[4, 3];
        a[2] = face.pFacelets[1, 4];
        a[3] = face.pFacelets[0, 1];
        CycleFacelets4A(a);

        // The inner square

        a[0] = face.pFacelets[1, 1];
        a[1] = face.pFacelets[3, 1];
        a[2] = face.pFacelets[3, 3];
        a[3] = face.pFacelets[1, 3];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[2, 1];
        a[1] = face.pFacelets[3, 2];
        a[2] = face.pFacelets[2, 3];
        a[3] = face.pFacelets[1, 2];
        CycleFacelets4A(a);

        // Now, rotate the facelets about their centres.
        /*
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                face.pFacelets[x, y].transform.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
        */
    }

    public void CycleFacelets4(GameObject[] f)
    {
        Image[] imgs = new Image[4];

        for (int i = 0; i < 4; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c0 = imgs[0].color;
        //Sprite s0 = imgs[0].sprite;

        for (int i = 0; i < 3; i++)
        {
            imgs[i].color = imgs[i + 1].color;
            //imgs[i].sprite = imgs[i + 1].sprite;
        }
        imgs[3].color = c0;
        //imgs[3].sprite = s0;
    }

    public void CycleFacelets4A(GameObject[] f)
    {
        Image[] imgs = new Image[4];

        for (int i = 0; i < 4; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c3 = imgs[3].color;
        //Sprite s3 = imgs[3].sprite;

        for (int i = 2; i >= 0; i--)
        {
            imgs[i + 1].color = imgs[i].color;
            //imgs[i + 1].sprite = imgs[i].sprite;
        }
        imgs[0].color = c3;
        //imgs[0].sprite = s3;
    }

    public void CycleFacelets20(GameObject[] f)
    {
        Image[] imgs = new Image[20];

        for (int i = 0; i < 20; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c0 = imgs[0].color;
        //Sprite s0 = imgs[0].sprite;

        for (int i = 0; i < 19; i++)
        {
            imgs[i].color = imgs[i + 1].color;
            //imgs[i].sprite = imgs[i + 1].sprite;
        }
        imgs[19].color = c0;
        //imgs[19].sprite = s0;
    }

    public void CycleFacelets20A(GameObject[] f)
    {
        Image[] imgs = new Image[20];

        for (int i = 0; i < 20; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c19 = imgs[19].color;
        //Sprite s19 = imgs[19].sprite;

        for (int i = 18; i >= 0; i--)
        {
            imgs[i + 1].color = imgs[i].color;
            //imgs[i + 1].sprite = imgs[i].sprite;
        }
        imgs[0].color = c19;
        //imgs[0].sprite = s19;
    }


    // Initiate animation of rotation...
    public void OnRotate(InputAction.CallbackContext context, CubeAxis axis, CubeSlices slices)
    {
        if (context.phase != InputActionPhase.Started)
            return;

        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnim(axis, slices);

        cubeSlices = slices;
        cubeAxis = axis;

        isAnimating = true;
        animationStep = 0;
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



    public void OnEscape(InputAction.CallbackContext context)
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        if (Mouse.current.leftButton.isPressed)
        {
            mainCamera.OrbitCamera(move);
        }
    }
}
