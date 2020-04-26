using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.EventSystems;
using UnityEditor;
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

    public enum CubeAxis { x = 0, y = 1, z = 2 };
    public enum CubeSlices { s0 = 0, s01 = 1, s1 = 2, s2 = 3, s3 = 4, s34 = 5, s4 = 6 };

    public int firstStep = 10;
    public int secondStep = 20;
    public int thirdStep = 45;
    public int fourthStep = 70;
    public int fifthStep = 80;

    // Animation
    public int animationStep;

    public bool isAnimating;
    public float currentAngle;
    public float finalAngle;
    public float deltaAngle;
    public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    public CubeSlices cubeSlices;   // Which slices we are currently rotating.


    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMouseDown()
    {
        if (Input.GetKey("mouse 0"))
        {
            print("Box Clicked!");
        }
    }
    // Update is called once per frame

    void Update()
    {
        if (isAnimating)
        {
            // Y axis

            // First slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s4)
            {
                upPanel.transform.Rotate(0.0f, 0.0f, -1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFirstSliceFromTop();
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
                upPanel.transform.Rotate(0.0f, 0.0f, -1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFirstSliceFromTop();
                    CycleSecondSliceFromTop();
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
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleSecondSliceFromTop();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Third slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s2)
            {
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleThirdSliceFromTop();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Fourth slice from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s1)
            {
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFourthSliceFromTop();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Fourth and Fifth two slices from top.
            if (cubeAxis == CubeAxis.y && cubeSlices == CubeSlices.s01)
            {
                downPanel.transform.Rotate(0.0f, 0.0f, 1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFourthSliceFromTop();
                    CycleFifthSliceFromTop();
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
                downPanel.transform.Rotate(0.0f, 0.0f, 1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFifthSliceFromTop();
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
                rightPanel.transform.Rotate(0.0f, 0.0f, -1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFirstSliceFromRight();
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
                rightPanel.transform.Rotate(0.0f, 0.0f, -1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFirstSliceFromRight();
                    CycleSecondSliceFromRight();
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
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleSecondSliceFromRight();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Third (middle) slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s2)
            {
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleThirdSliceFromRight();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }


            // Fourth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s1)
            {
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFourthSliceFromRight();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Fourth and fifth slice from right.
            if (cubeAxis == CubeAxis.x && cubeSlices == CubeSlices.s01)
            {
                leftPanel.transform.Rotate(0.0f, 0.0f, 1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFourthSliceFromRight();
                    CycleFifthSliceFromRight();
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
                leftPanel.transform.Rotate(0.0f, 0.0f, 1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFifthSliceFromRight();
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
                frontPanel.transform.Rotate(0.0f, 0.0f, 1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFirstSliceFromFront();
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
                frontPanel.transform.Rotate(0.0f, 0.0f, 1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFirstSliceFromFront();
                    CycleSecondSliceFromFront();
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
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleSecondSliceFromFront();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Third slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s2)
            {
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleThirdSliceFromFront();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Fourth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s3)
            {
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFourthSliceFromFront();
                }

                if (animationStep == 90)
                {
                    isAnimating = false;
                }
            }

            // Fourth and fifth slice from front.
            if (cubeAxis == CubeAxis.z && cubeSlices == CubeSlices.s34)
            {
                backPanel.transform.Rotate(0.0f, 0.0f, -1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFourthSliceFromFront();
                    CycleFifthSliceFromFront();
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
                backPanel.transform.Rotate(0.0f, 0.0f, -1.0f);
                animationStep += 1;

                if (animationStep == firstStep
                    || animationStep == secondStep
                    || animationStep == thirdStep
                    || animationStep == fourthStep
                    || animationStep == fifthStep)
                {
                    CycleFifthSliceFromFront();
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

    public void CycleFirstSliceFromTop()
    {
        // Cycle the second slice from the top...
        GameObject [] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[0, 4];
        a[1] = frontPanel.pFacelets[1, 4];
        a[2] = frontPanel.pFacelets[2, 4];
        a[3] = frontPanel.pFacelets[3, 4];
        a[4] = frontPanel.pFacelets[4, 4];

        a[5] = rightPanel.pFacelets[0, 4];
        a[6] = rightPanel.pFacelets[1, 4];
        a[7] = rightPanel.pFacelets[2, 4];
        a[8] = rightPanel.pFacelets[3, 4];
        a[9] = rightPanel.pFacelets[4, 4];

        a[10] = backPanel.pFacelets[4, 0];
        a[11] = backPanel.pFacelets[3, 0];
        a[12] = backPanel.pFacelets[2, 0];
        a[13] = backPanel.pFacelets[1, 0];
        a[14] = backPanel.pFacelets[0, 0];

        a[15] = leftPanel.pFacelets[0, 4];
        a[16] = leftPanel.pFacelets[1, 4];
        a[17] = leftPanel.pFacelets[2, 4];
        a[18] = leftPanel.pFacelets[3, 4];
        a[19] = leftPanel.pFacelets[4, 4];

        CycleFacelets20(a);

    }

    public void CycleSecondSliceFromTop()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[0, 3];
        a[1] = frontPanel.pFacelets[1, 3];
        a[2] = frontPanel.pFacelets[2, 3];
        a[3] = frontPanel.pFacelets[3, 3];
        a[4] = frontPanel.pFacelets[4, 3];

        a[5] = rightPanel.pFacelets[0, 3];
        a[6] = rightPanel.pFacelets[1, 3];
        a[7] = rightPanel.pFacelets[2, 3];
        a[8] = rightPanel.pFacelets[3, 3];
        a[9] = rightPanel.pFacelets[4, 3];

        a[10] = backPanel.pFacelets[4, 1];
        a[11] = backPanel.pFacelets[3, 1];
        a[12] = backPanel.pFacelets[2, 1];
        a[13] = backPanel.pFacelets[1, 1];
        a[14] = backPanel.pFacelets[0, 1];

        a[15] = leftPanel.pFacelets[0, 3];
        a[16] = leftPanel.pFacelets[1, 3];
        a[17] = leftPanel.pFacelets[2, 3];
        a[18] = leftPanel.pFacelets[3, 3];
        a[19] = leftPanel.pFacelets[4, 3];

        CycleFacelets20(a);

    }

    public void CycleThirdSliceFromTop()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[0, 2];
        a[1] = frontPanel.pFacelets[1, 2];
        a[2] = frontPanel.pFacelets[2, 2];
        a[3] = frontPanel.pFacelets[3, 2];
        a[4] = frontPanel.pFacelets[4, 2];

        a[5] = rightPanel.pFacelets[0, 2];
        a[6] = rightPanel.pFacelets[1, 2];
        a[7] = rightPanel.pFacelets[2, 2];
        a[8] = rightPanel.pFacelets[3, 2];
        a[9] = rightPanel.pFacelets[4, 2];

        a[10] = backPanel.pFacelets[4, 2];
        a[11] = backPanel.pFacelets[3, 2];
        a[12] = backPanel.pFacelets[2, 2];
        a[13] = backPanel.pFacelets[1, 2];
        a[14] = backPanel.pFacelets[0, 2];

        a[15] = leftPanel.pFacelets[0, 2];
        a[16] = leftPanel.pFacelets[1, 2];
        a[17] = leftPanel.pFacelets[2, 2];
        a[18] = leftPanel.pFacelets[3, 2];
        a[19] = leftPanel.pFacelets[4, 2];

        CycleFacelets20(a);

    }

    public void CycleFourthSliceFromTop()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[0, 1];
        a[1] = frontPanel.pFacelets[1, 1];
        a[2] = frontPanel.pFacelets[2, 1];
        a[3] = frontPanel.pFacelets[3, 1];
        a[4] = frontPanel.pFacelets[4, 1];

        a[5] = rightPanel.pFacelets[0, 1];
        a[6] = rightPanel.pFacelets[1, 1];
        a[7] = rightPanel.pFacelets[2, 1];
        a[8] = rightPanel.pFacelets[3, 1];
        a[9] = rightPanel.pFacelets[4, 1];

        a[10] = backPanel.pFacelets[4, 3];
        a[11] = backPanel.pFacelets[3, 3];
        a[12] = backPanel.pFacelets[2, 3];
        a[13] = backPanel.pFacelets[1, 3];
        a[14] = backPanel.pFacelets[0, 3];

        a[15] = leftPanel.pFacelets[0, 1];
        a[16] = leftPanel.pFacelets[1, 1];
        a[17] = leftPanel.pFacelets[2, 1];
        a[18] = leftPanel.pFacelets[3, 1];
        a[19] = leftPanel.pFacelets[4, 1];

        CycleFacelets20(a);

    }

    public void CycleFifthSliceFromTop()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[0, 0];
        a[1] = frontPanel.pFacelets[1, 0];
        a[2] = frontPanel.pFacelets[2, 0];
        a[3] = frontPanel.pFacelets[3, 0];
        a[4] = frontPanel.pFacelets[4, 0];

        a[5] = rightPanel.pFacelets[0, 0];
        a[6] = rightPanel.pFacelets[1, 0];
        a[7] = rightPanel.pFacelets[2, 0];
        a[8] = rightPanel.pFacelets[3, 0];
        a[9] = rightPanel.pFacelets[4, 0];

        a[10] = backPanel.pFacelets[4, 4];
        a[11] = backPanel.pFacelets[3, 4];
        a[12] = backPanel.pFacelets[2, 4];
        a[13] = backPanel.pFacelets[1, 4];
        a[14] = backPanel.pFacelets[0, 4];

        a[15] = leftPanel.pFacelets[0, 0];
        a[16] = leftPanel.pFacelets[1, 0];
        a[17] = leftPanel.pFacelets[2, 0];
        a[18] = leftPanel.pFacelets[3, 0];
        a[19] = leftPanel.pFacelets[4, 0];

        CycleFacelets20(a);

    }

    // X axis

    public void CycleFirstSliceFromRight()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[4, 0];
        a[1] = frontPanel.pFacelets[4, 1];
        a[2] = frontPanel.pFacelets[4, 2];
        a[3] = frontPanel.pFacelets[4, 3];
        a[4] = frontPanel.pFacelets[4, 4];

        a[5] = upPanel.pFacelets[4, 0];
        a[6] = upPanel.pFacelets[4, 1];
        a[7] = upPanel.pFacelets[4, 2];
        a[8] = upPanel.pFacelets[4, 3];
        a[9] = upPanel.pFacelets[4, 4];

        a[10] = backPanel.pFacelets[4, 0];
        a[11] = backPanel.pFacelets[4, 1];
        a[12] = backPanel.pFacelets[4, 2];
        a[13] = backPanel.pFacelets[4, 3];
        a[14] = backPanel.pFacelets[4, 4];

        a[15] = downPanel.pFacelets[4, 0];
        a[16] = downPanel.pFacelets[4, 1];
        a[17] = downPanel.pFacelets[4, 2];
        a[18] = downPanel.pFacelets[4, 3];
        a[19] = downPanel.pFacelets[4, 4];

        CycleFacelets20A(a);

    }

    public void CycleSecondSliceFromRight()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[3, 0];
        a[1] = frontPanel.pFacelets[3, 1];
        a[2] = frontPanel.pFacelets[3, 2];
        a[3] = frontPanel.pFacelets[3, 3];
        a[4] = frontPanel.pFacelets[3, 4];

        a[5] = upPanel.pFacelets[3, 0];
        a[6] = upPanel.pFacelets[3, 1];
        a[7] = upPanel.pFacelets[3, 2];
        a[8] = upPanel.pFacelets[3, 3];
        a[9] = upPanel.pFacelets[3, 4];

        a[10] = backPanel.pFacelets[3, 0];
        a[11] = backPanel.pFacelets[3, 1];
        a[12] = backPanel.pFacelets[3, 2];
        a[13] = backPanel.pFacelets[3, 3];
        a[14] = backPanel.pFacelets[3, 4];

        a[15] = downPanel.pFacelets[3, 0];
        a[16] = downPanel.pFacelets[3, 1];
        a[17] = downPanel.pFacelets[3, 2];
        a[18] = downPanel.pFacelets[3, 3];
        a[19] = downPanel.pFacelets[3, 4];

        CycleFacelets20A(a);

    }


    public void CycleThirdSliceFromRight()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[2, 0];
        a[1] = frontPanel.pFacelets[2, 1];
        a[2] = frontPanel.pFacelets[2, 2];
        a[3] = frontPanel.pFacelets[2, 3];
        a[4] = frontPanel.pFacelets[2, 4];

        a[5] = upPanel.pFacelets[2, 0];
        a[6] = upPanel.pFacelets[2, 1];
        a[7] = upPanel.pFacelets[2, 2];
        a[8] = upPanel.pFacelets[2, 3];
        a[9] = upPanel.pFacelets[2, 4];

        a[10] = backPanel.pFacelets[2, 0];
        a[11] = backPanel.pFacelets[2, 1];
        a[12] = backPanel.pFacelets[2, 2];
        a[13] = backPanel.pFacelets[2, 3];
        a[14] = backPanel.pFacelets[2, 4];

        a[15] = downPanel.pFacelets[2, 0];
        a[16] = downPanel.pFacelets[2, 1];
        a[17] = downPanel.pFacelets[2, 2];
        a[18] = downPanel.pFacelets[2, 3];
        a[19] = downPanel.pFacelets[2, 4];

        CycleFacelets20A(a);

    }


    public void CycleFourthSliceFromRight()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[1, 0];
        a[1] = frontPanel.pFacelets[1, 1];
        a[2] = frontPanel.pFacelets[1, 2];
        a[3] = frontPanel.pFacelets[1, 3];
        a[4] = frontPanel.pFacelets[1, 4];

        a[5] = upPanel.pFacelets[1, 0];
        a[6] = upPanel.pFacelets[1, 1];
        a[7] = upPanel.pFacelets[1, 2];
        a[8] = upPanel.pFacelets[1, 3];
        a[9] = upPanel.pFacelets[1, 4];

        a[10] = backPanel.pFacelets[1, 0];
        a[11] = backPanel.pFacelets[1, 1];
        a[12] = backPanel.pFacelets[1, 2];
        a[13] = backPanel.pFacelets[1, 3];
        a[14] = backPanel.pFacelets[1, 4];

        a[15] = downPanel.pFacelets[1, 0];
        a[16] = downPanel.pFacelets[1, 1];
        a[17] = downPanel.pFacelets[1, 2];
        a[18] = downPanel.pFacelets[1, 3];
        a[19] = downPanel.pFacelets[1, 4];

        CycleFacelets20A(a);

    }


    public void CycleFifthSliceFromRight()
    {
        // Cycle the second slice from the top...
        GameObject[] a = new GameObject[20];
        a[0] = frontPanel.pFacelets[0, 0];
        a[1] = frontPanel.pFacelets[0, 1];
        a[2] = frontPanel.pFacelets[0, 2];
        a[3] = frontPanel.pFacelets[0, 3];
        a[4] = frontPanel.pFacelets[0, 4];

        a[5] = upPanel.pFacelets[0, 0];
        a[6] = upPanel.pFacelets[0, 1];
        a[7] = upPanel.pFacelets[0, 2];
        a[8] = upPanel.pFacelets[0, 3];
        a[9] = upPanel.pFacelets[0, 4];

        a[10] = backPanel.pFacelets[0, 0];
        a[11] = backPanel.pFacelets[0, 1];
        a[12] = backPanel.pFacelets[0, 2];
        a[13] = backPanel.pFacelets[0, 3];
        a[14] = backPanel.pFacelets[0, 4];

        a[15] = downPanel.pFacelets[0, 0];
        a[16] = downPanel.pFacelets[0, 1];
        a[17] = downPanel.pFacelets[0, 2];
        a[18] = downPanel.pFacelets[0, 3];
        a[19] = downPanel.pFacelets[0, 4];

        CycleFacelets20A(a);

    }

    // Z axis

    public void CycleFirstSliceFromFront()
    {
        GameObject[] a = new GameObject[20];
        a[0] = downPanel.pFacelets[0, 4];
        a[1] = downPanel.pFacelets[1, 4];
        a[2] = downPanel.pFacelets[2, 4];
        a[3] = downPanel.pFacelets[3, 4];
        a[4] = downPanel.pFacelets[4, 4];

        a[5] = rightPanel.pFacelets[0, 0];
        a[6] = rightPanel.pFacelets[0, 1];
        a[7] = rightPanel.pFacelets[0, 2];
        a[8] = rightPanel.pFacelets[0, 3];
        a[9] = rightPanel.pFacelets[0, 4];

        a[10] = upPanel.pFacelets[4, 0];
        a[11] = upPanel.pFacelets[3, 0];
        a[12] = upPanel.pFacelets[2, 0];
        a[13] = upPanel.pFacelets[1, 0];
        a[14] = upPanel.pFacelets[0, 0];

        a[15] = leftPanel.pFacelets[4, 4];
        a[16] = leftPanel.pFacelets[4, 3];
        a[17] = leftPanel.pFacelets[4, 2];
        a[18] = leftPanel.pFacelets[4, 1];
        a[19] = leftPanel.pFacelets[4, 0];

        CycleFacelets20A(a);

    }


    public void CycleSecondSliceFromFront()
    {
        GameObject[] a = new GameObject[20];
        a[0] = downPanel.pFacelets[0, 3];
        a[1] = downPanel.pFacelets[1, 3];
        a[2] = downPanel.pFacelets[2, 3];
        a[3] = downPanel.pFacelets[3, 3];
        a[4] = downPanel.pFacelets[4, 3];

        a[5] = rightPanel.pFacelets[1, 0];
        a[6] = rightPanel.pFacelets[1, 1];
        a[7] = rightPanel.pFacelets[1, 2];
        a[8] = rightPanel.pFacelets[1, 3];
        a[9] = rightPanel.pFacelets[1, 4];

        a[10] = upPanel.pFacelets[4, 1];
        a[11] = upPanel.pFacelets[3, 1];
        a[12] = upPanel.pFacelets[2, 1];
        a[13] = upPanel.pFacelets[1, 1];
        a[14] = upPanel.pFacelets[0, 1];

        a[15] = leftPanel.pFacelets[3, 4];
        a[16] = leftPanel.pFacelets[3, 3];
        a[17] = leftPanel.pFacelets[3, 2];
        a[18] = leftPanel.pFacelets[3, 1];
        a[19] = leftPanel.pFacelets[3, 0];

        CycleFacelets20A(a);

    }


    public void CycleThirdSliceFromFront()
    {
        GameObject[] a = new GameObject[20];
        a[0] = downPanel.pFacelets[0, 2];
        a[1] = downPanel.pFacelets[1, 2];
        a[2] = downPanel.pFacelets[2, 2];
        a[3] = downPanel.pFacelets[3, 2];
        a[4] = downPanel.pFacelets[4, 2];

        a[5] = rightPanel.pFacelets[2, 0];
        a[6] = rightPanel.pFacelets[2, 1];
        a[7] = rightPanel.pFacelets[2, 2];
        a[8] = rightPanel.pFacelets[2, 3];
        a[9] = rightPanel.pFacelets[2, 4];

        a[10] = upPanel.pFacelets[4, 2];
        a[11] = upPanel.pFacelets[3, 2];
        a[12] = upPanel.pFacelets[2, 2];
        a[13] = upPanel.pFacelets[1, 2];
        a[14] = upPanel.pFacelets[0, 2];

        a[15] = leftPanel.pFacelets[2, 4];
        a[16] = leftPanel.pFacelets[2, 3];
        a[17] = leftPanel.pFacelets[2, 2];
        a[18] = leftPanel.pFacelets[2, 1];
        a[19] = leftPanel.pFacelets[2, 0];

        CycleFacelets20A(a);

    }


    public void CycleFourthSliceFromFront()
    {
        GameObject[] a = new GameObject[20];
        a[0] = downPanel.pFacelets[0, 1];
        a[1] = downPanel.pFacelets[1, 1];
        a[2] = downPanel.pFacelets[2, 1];
        a[3] = downPanel.pFacelets[3, 1];
        a[4] = downPanel.pFacelets[4, 1];

        a[5] = rightPanel.pFacelets[3, 0];
        a[6] = rightPanel.pFacelets[3, 1];
        a[7] = rightPanel.pFacelets[3, 2];
        a[8] = rightPanel.pFacelets[3, 3];
        a[9] = rightPanel.pFacelets[3, 4];

        a[10] = upPanel.pFacelets[4, 3];
        a[11] = upPanel.pFacelets[3, 3];
        a[12] = upPanel.pFacelets[2, 3];
        a[13] = upPanel.pFacelets[1, 3];
        a[14] = upPanel.pFacelets[0, 3];

        a[15] = leftPanel.pFacelets[1, 4];
        a[16] = leftPanel.pFacelets[1, 3];
        a[17] = leftPanel.pFacelets[1, 2];
        a[18] = leftPanel.pFacelets[1, 1];
        a[19] = leftPanel.pFacelets[1, 0];

        CycleFacelets20A(a);

    }


    public void CycleFifthSliceFromFront()
    {
        GameObject[] a = new GameObject[20];
        a[0] = downPanel.pFacelets[0, 0];
        a[1] = downPanel.pFacelets[1, 0];
        a[2] = downPanel.pFacelets[2, 0];
        a[3] = downPanel.pFacelets[3, 0];
        a[4] = downPanel.pFacelets[4, 0];

        a[5] = rightPanel.pFacelets[4, 0];
        a[6] = rightPanel.pFacelets[4, 1];
        a[7] = rightPanel.pFacelets[4, 2];
        a[8] = rightPanel.pFacelets[4, 3];
        a[9] = rightPanel.pFacelets[4, 4];

        a[10] = upPanel.pFacelets[4, 4];
        a[11] = upPanel.pFacelets[3, 4];
        a[12] = upPanel.pFacelets[2, 4];
        a[13] = upPanel.pFacelets[1, 4];
        a[14] = upPanel.pFacelets[0, 4];

        a[15] = leftPanel.pFacelets[0, 4];
        a[16] = leftPanel.pFacelets[0, 3];
        a[17] = leftPanel.pFacelets[0, 2];
        a[18] = leftPanel.pFacelets[0, 1];
        a[19] = leftPanel.pFacelets[0, 0];

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

    }

    public void CycleFacelets4(GameObject[] f)
    {
        Image[] imgs = new Image[4];

        for (int i = 0; i < 4; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c0 = imgs[0].color;
        Sprite s0 = imgs[0].sprite;

        for (int i = 0; i < 3; i++)
        {
            imgs[i].color = imgs[i + 1].color;
            imgs[i].sprite = imgs[i + 1].sprite;
        }
        imgs[3].color = c0;
        imgs[3].sprite = s0;
    }

    public void CycleFacelets4A(GameObject[] f)
    {
        Image[] imgs = new Image[4];

        for (int i = 0; i < 4; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c3 = imgs[3].color;
        Sprite s3 = imgs[3].sprite;

        for (int i = 2; i >= 0; i--)
        {
            imgs[i + 1].color = imgs[i].color;
            imgs[i + 1].sprite = imgs[i].sprite;
        }
        imgs[0].color = c3;
        imgs[0].sprite = s3;
    }

    public void CycleFacelets20(GameObject[] f)
    {
        Image[] imgs = new Image[20];

        for (int i = 0; i < 20; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c0 = imgs[0].color;
        Sprite s0 = imgs[0].sprite;


        for (int i = 0; i < 19; i++)
        {
            imgs[i].color = imgs[i + 1].color;
            imgs[i].sprite = imgs[i + 1].sprite;
        }
        imgs[19].color = c0;
        imgs[19].sprite = s0;

    }

    public void CycleFacelets20A(GameObject[] f)
    {
        Image[] imgs = new Image[20];

        for (int i = 0; i < 20; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c19 = imgs[19].color;
        Sprite s19 = imgs[19].sprite;


        for (int i = 18; i >= 0; i--)
        {
            imgs[i + 1].color = imgs[i].color;
            imgs[i + 1].sprite = imgs[i].sprite;
        }
        imgs[0].color = c19;
        imgs[0].sprite = s19;

    }

    // Outer
    public void OnRotateOuterL(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s0);

        cubeSlices = CubeSlices.s0;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateOuterR(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s4);

        cubeSlices = CubeSlices.s4;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateOuterD(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s0);

        cubeSlices = CubeSlices.s0;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateOuterU(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s4);

        cubeSlices = CubeSlices.s4;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateOuterF(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s0);

        cubeSlices = CubeSlices.s0;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateOuterB(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s4);

        cubeSlices = CubeSlices.s4;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
    }

    // Both
    public void OnRotateBothL(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s01);

        cubeSlices = CubeSlices.s01;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateBothR(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s34);

        cubeSlices = CubeSlices.s34;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateBothD(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s01);

        cubeSlices = CubeSlices.s01;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateBothU(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s34);

        cubeSlices = CubeSlices.s34;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateBothF(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s01);

        cubeSlices = CubeSlices.s01;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateBothB(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s34);

        cubeSlices = CubeSlices.s34;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
    }

    // Inner
    public void OnRotateInnerL(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s1);

        cubeSlices = CubeSlices.s1;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateInnerR(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s3);

        cubeSlices = CubeSlices.s3;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateInnerD(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s1);

        cubeSlices = CubeSlices.s1;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateInnerU(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s3);

        cubeSlices = CubeSlices.s3;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateInnerF(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s1);

        cubeSlices = CubeSlices.s1;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateInnerB(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s3);

        cubeSlices = CubeSlices.s3;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
    }


    public void OnRotateMidLR(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimX(MyCube.CubeSlices.s2);

        cubeSlices = CubeSlices.s2;
        cubeAxis = CubeAxis.x;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateMidUD(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimY(MyCube.CubeSlices.s2);

        cubeSlices = CubeSlices.s2;
        cubeAxis = CubeAxis.y;

        isAnimating = true;
        animationStep = 0;
    }

    public void OnRotateMidFB(InputAction.CallbackContext context)
    {
        if (isAnimating || myCube.isAnimating)
            return;

        myCube.DoAnimZ(MyCube.CubeSlices.s2);

        cubeSlices = CubeSlices.s2;
        cubeAxis = CubeAxis.z;

        isAnimating = true;
        animationStep = 0;
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
