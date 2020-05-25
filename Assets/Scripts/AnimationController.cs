using UnityEngine;

public enum RotationDirection { normal = 0, reverse = 1 };
public enum CubeAxis { x = 0, y = 1, z = 2 };
public enum CubeSlices { s0 = 0, s01 = 1, s1 = 2, s2 = 3, s3 = 4, s34 = 5, s4 = 6 , s01234 = 7};




// Encode the specification of the cube / map animation
public struct AnimationSpecification
{
    public RotationDirection rotationDirection;
    public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    public CubeSlices cubeSlices;   // Which slices we are currently rotating.
}


// Coordinate the Cube and Map animations.
public class AnimationController : MonoBehaviour
{
    public FaceMap faceMap;
    public MyCube myCube;

    bool isAnimating;
    int animationStep;
    float angleStep = 5.0f;

    readonly int firstStep = 2;
    readonly int secondStep = 4;
    readonly int thirdStep = 9;
    readonly int fourthStep = 14;
    readonly int fifthStep = 16;

    readonly int lastAnimationStep = 18;


    public float currentAngle;
    public float finalAngle;
    public float deltaAngle;


    //-------------------------------------------------
    //
    // Animation stuff...


    readonly float baseAngleStep = 5.0f;


    // Animation

    public RotationDirection rotationDirection;
    public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    public CubeSlices cubeSlices;   // Which slices we are currently rotating.

    
    //-------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void StartAnimation(AnimationSpecification animationSpecification)
    {
        Debug.Log($"Start: {animationSpecification.rotationDirection}");
        if (animationSpecification.rotationDirection == RotationDirection.reverse)
            angleStep = -baseAngleStep;
        else
            angleStep = baseAngleStep;

        myCube.SpecifyAnimation(animationSpecification.cubeAxis, animationSpecification.cubeSlices, animationSpecification.rotationDirection);
        faceMap.SpecifyAnimation(animationSpecification);

        animationStep = 0;
        isAnimating = true;
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
        if (isAnimating)
        {
            animationStep++;
            //if (animationStep != lastAnimationStep)
            { 
                faceMap.DoAnimation(angleStep, IsAnimationOnStep(animationStep));
                myCube.DoAnimation(angleStep);
                Debug.Log($"step: <color=blue>{animationStep}</color> {angleStep} degrees");

            }
            if (animationStep == lastAnimationStep)
            {
                faceMap.FinishAnimation();
                myCube.FinishAnimation();
                isAnimating = false;
            }
        }
    }
}
