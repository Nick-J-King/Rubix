using UnityEngine;


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

    bool isAnimating;
    int animationStep;

    readonly float baseAngleStep = 5.0f;

    float angleStep = 5.0f;

    readonly int firstStep = 2;
    readonly int secondStep = 4;
    readonly int thirdStep = 9;
    readonly int fourthStep = 14;
    readonly int fifthStep = 16;

    readonly int lastAnimationStep = 18;

        
    // Start is called before the first frame update
    void Start()
    {
        isAnimating = false;
    }


    public void StartAnimation(AnimationSpecification animationSpecification)
    {
        if (isAnimating)
            return;

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
            return;

        animationStep++;

        faceMap.DoAnimation(angleStep, IsAnimationOnStep(animationStep));
        myCube.DoAnimation(angleStep);

        if (animationStep == lastAnimationStep)
        {
            faceMap.FinishAnimation();
            myCube.FinishAnimation();
            isAnimating = false;
        }
    }
}
