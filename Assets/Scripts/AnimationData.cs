using UnityEngine;


namespace Rubix.Animation
{ 
    public enum CubeAxis { x = 0, y = 1, z = 2 };
    public enum CubeSlices { s0 = 0, s01 = 1, s1 = 2, s2 = 3, s3 = 4, s34 = 5, s4 = 6 , s01234 = 7};
    public enum RotationDirection { normal = 0, reverse = 1 };
    public enum MoveType { noMove = 0, singleMove = 1, doubleMove = 2 };


    // Encode the specification of the cube / map animation
    public struct AnimationSpecification
    {
        public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
        public CubeSlices cubeSlices;   // Which slices we are currently rotating.
        public RotationDirection rotationDirection;
        public MoveType moveType;

        public bool IsSimilarMove(AnimationSpecification animationSpecification)
        {
            if (animationSpecification.moveType == MoveType.noMove)
                return false;
            if (animationSpecification.cubeAxis == cubeAxis
             && animationSpecification.cubeSlices == cubeSlices)
                return true;
            return false;
        }
    }


    // ??? Why do I need to make a "dummy" AnimationData class with only this static function ???
    public static class AnimationData
    {
        public static AnimationSpecification GetNullMove()
        {
            AnimationSpecification animationSpecification;
            animationSpecification.cubeAxis = CubeAxis.x;
            animationSpecification.cubeSlices = CubeSlices.s0;
            animationSpecification.rotationDirection = RotationDirection.normal;
            animationSpecification.moveType = MoveType.noMove;

            return animationSpecification;
        }


        public static AnimationSpecification GetRandomMove()
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

            x = Random.Range(0, 2);
            if (x == 0)
                animationSpecification.moveType = MoveType.singleMove;
            else
                animationSpecification.moveType = MoveType.doubleMove;

            return animationSpecification;
        }
    }
}