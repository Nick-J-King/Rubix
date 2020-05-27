using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovesPanel : DragWindow
{
    public GameObject prefab;
    public RectTransform contentRect;


    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
        base.Update();
    }


    public void GoFirst()
    {
        // Unwind to start!
        Debug.Log("GoFirst");
    }


    public void GoPrevious()
    {
        // Unwind last move!
        Debug.Log("GoPrevious");
    }


    public void GoNext()
    {
        // Play next move!
        Debug.Log("GoNext");
    }


    public void GoLast()
    {
        // Replay to end!
        Debug.Log("GoLast");
    }


    public void ClickMove()
    {
        Debug.Log($"Click !");
    }


    public void AddMove(AnimationSpecification animationSpecification)
    {
        RotationDirection rotationDirection = animationSpecification.rotationDirection;
        CubeAxis cubeAxis = animationSpecification.cubeAxis;
        CubeSlices cubeSlices = animationSpecification.cubeSlices;

        string s = "";

        switch (cubeAxis)
        {
            case CubeAxis.x:
                s = "x";
                break;
            case CubeAxis.y:
                s = "y";
                break;
            case CubeAxis.z:
                s = "z";
                break;
        }

        switch (cubeSlices)
        {
            case CubeSlices.s0:
                s += "0";
                break;
            case CubeSlices.s01:
                s += "01";
                break;
            case CubeSlices.s1:
                s += "1";
                break;
            case CubeSlices.s2:
                s += "2";
                break;
            case CubeSlices.s3:
                s += "3";
                break;
            case CubeSlices.s34:
                s += "34";
                break;
            case CubeSlices.s4:
                s += "4";
                break;
            case CubeSlices.s01234:
                s += "01234";
                break;
        }

        if (rotationDirection == RotationDirection.reverse)
            s += "R";

        GameObject g1 = Instantiate(prefab); 

        g1.transform.parent = contentRect;
        g1.SetActive(true);

        var g1m = g1.GetComponent<MyMove>();
        g1m.text.text = "  " + s;
    }
}
