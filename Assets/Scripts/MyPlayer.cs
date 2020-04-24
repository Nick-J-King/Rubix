using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.EventSystems;
using UnityEditor;

public class MyPlayer : MonoBehaviour
{
    public MyGame myGame;
    public MainCamera mainCamera;
    public MyCube myCube;


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

       // if (Input.GetMouseButtonDown(0))
       // {
       //     if (EventSystem.
       //         Debug.Log("left-click over a GUI element!");
//
  //          else Debug.Log("just a left-click!");
    //    }

    }
    public void OnFire(InputAction.CallbackContext context)
    {
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        // >> If camera IS in the reset state, reset the cube...
        mainCamera.Start();
    }


    // Outer
    public void OnRotateOuterL(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s0);
    }

    public void OnRotateOuterR(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s4);
    }


    public void OnRotateOuterD(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s0);
    }

    public void OnRotateOuterU(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s4);
    }


    public void OnRotateOuterF(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s0);
    }

    public void OnRotateOuterB(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s4);
    }

    // Both
    public void OnRotateBothL(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s01);
    }

    public void OnRotateBothR(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s34);
    }


    public void OnRotateBothD(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s01);
    }

    public void OnRotateBothU(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s34);
    }


    public void OnRotateBothF(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s01);
    }

    public void OnRotateBothB(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s34);
    }

    // Inner
    public void OnRotateInnerL(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s1);
    }

    public void OnRotateInnerR(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s3);
    }


    public void OnRotateInnerD(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s1);
    }

    public void OnRotateInnerU(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s3);
    }


    public void OnRotateInnerF(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s1);
    }

    public void OnRotateInnerB(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s3);
    }


    public void OnRotateMidLR(InputAction.CallbackContext context)
    {
        myCube.DoAnimX(MyCube.CubeSlices.s2);
    }

    public void OnRotateMidUD(InputAction.CallbackContext context)
    {
        myCube.DoAnimY(MyCube.CubeSlices.s2);
    }

    public void OnRotateMidFB(InputAction.CallbackContext context)
    {
        myCube.DoAnimZ(MyCube.CubeSlices.s2);
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
