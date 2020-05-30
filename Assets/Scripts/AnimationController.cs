using UnityEngine;
using System.Collections.Generic;


public enum CubeAxis { x = 0, y = 1, z = 2 };
public enum CubeSlices { s0 = 0, s01 = 1, s1 = 2, s2 = 3, s3 = 4, s34 = 5, s4 = 6 , s01234 = 7};
public enum RotationDirection { normal = 0, reverse = 1 };


// Encode the specification of the cube / map animation
public struct AnimationSpecification
{
    public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    public CubeSlices cubeSlices;   // Which slices we are currently rotating.
    public RotationDirection rotationDirection;
}


// Coordinate the Cube and Map animations.
public class AnimationController : MonoBehaviour
{
    public FaceMap faceMap;
    public MyCube myCube;
    public MovesPanel movesPanel;

    public bool isAnimating;
    public Queue<AnimationSpecification> queue;

    int animationStep;

    readonly float baseAngleStep = 5.0f;

    float angleStep = 5.0f;

    readonly int firstStep = 2;
    readonly int secondStep = 4;
    readonly int thirdStep = 9;
    readonly int fourthStep = 14;
    readonly int fifthStep = 16;

    readonly int lastAnimationStep = 18;

    bool doRandomMoves;


    public void ToggleGoRandomMoves()
    {
        doRandomMoves = !doRandomMoves;
    }

    void Start()
    {
        doRandomMoves = false;
        queue = new Queue<AnimationSpecification>();

        isAnimating = false;
    }


    public AnimationSpecification GetRandomMove()
    {
        AnimationSpecification animationSpecification;

        int x = Random.Range(0,3);

        if (x == 0)
            animationSpecification.cubeAxis = CubeAxis.x;
        else if (x == 1)
            animationSpecification.cubeAxis = CubeAxis.y;
        else
            animationSpecification.cubeAxis = CubeAxis.z;

        x = Random.Range(0, 8);
        if (x == 0)
            animationSpecification.cubeSlices = CubeSlices.s0;
        else if (x == 1)
            animationSpecification.cubeSlices = CubeSlices.s01;
        else if (x == 2)
            animationSpecification.cubeSlices = CubeSlices.s01234;
        else if (x == 3)
            animationSpecification.cubeSlices = CubeSlices.s1;
        else if (x == 4)
            animationSpecification.cubeSlices = CubeSlices.s2;
        else if (x == 5)
            animationSpecification.cubeSlices = CubeSlices.s3;
        else if (x == 6)
            animationSpecification.cubeSlices = CubeSlices.s34;
        else
            animationSpecification.cubeSlices = CubeSlices.s4;

        x = Random.Range(0, 2);
        if (x == 0)
            animationSpecification.rotationDirection = RotationDirection.normal;
        else
            animationSpecification.rotationDirection = RotationDirection.reverse;

        return animationSpecification;
    }


    public void StartAnimation(AnimationSpecification animationSpecification)
    {
        if (isAnimating)
        {
            queue.Enqueue(animationSpecification);
            return;
        }

        myCube.SpecifyAnimation(animationSpecification);
        faceMap.SpecifyAnimation(animationSpecification);
        movesPanel.AddMove(animationSpecification);

        if (animationSpecification.rotationDirection == RotationDirection.reverse)
            angleStep = -baseAngleStep;
        else
            angleStep = baseAngleStep;

        animationStep = 0;
        isAnimating = true;
    }


    public void StopAnimation()
    {
        isAnimating = false;
    }


    // Determine whether to "cycle" the facelets on "strips".
    bool IsAnimationOnStep(int animationStep)
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
        if (!isAnimating)
        {
            if (queue.Count > 0)
            {
                AnimationSpecification animationSpecification = queue.Dequeue();
                StartAnimation(animationSpecification);
            }

            if (doRandomMoves)
                StartAnimation(GetRandomMove());

            return;
        }

        animationStep++;

        faceMap.DoAnimation(angleStep, IsAnimationOnStep(animationStep));
        myCube.DoAnimation(angleStep);

        if (animationStep == lastAnimationStep)
        {
            faceMap.FinishAnimation();
            myCube.FinishAnimation();
            isAnimating = false;

            if (doRandomMoves)
                StartAnimation(GetRandomMove());
        }
    }
}
