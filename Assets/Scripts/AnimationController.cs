using UnityEngine;
using System.Collections.Generic;
using Rubix.UI;
using Rubix.GUI;


namespace Rubix.Animation
{ 
    // Coordinate the Cube and Map animations.
    public class AnimationController : MonoBehaviour
    {
        public MyCube myCube;
        public FaceMapPanel faceMapPanel;
        public MovesPanel movesPanel;

        public bool isAnimating = false;

        readonly Queue<AnimationSpecification> queue = new Queue<AnimationSpecification>();

        bool doRandomMoves = false;

        int animationStep = 0;

        readonly float baseAngleStep = 5.0f;

        float angleStep = 5.0f;

        readonly int firstStep = 2;
        readonly int secondStep = 4;
        readonly int thirdStep = 9;
        readonly int fourthStep = 14;
        readonly int fifthStep = 16;

        readonly int lastAnimationStepSingle = 18;

        readonly int sixthStep = 2 + 18;
        readonly int seventhStep = 4 + 18;
        readonly int eighthStep = 9 + 18;
        readonly int ninthStep = 14 + 18;
        readonly int tenthStep = 16 + 18;

        readonly int lastAnimationStepDouble = 36;

        MoveType moveType = MoveType.singleMove;


        AudioSource myAudioSource;
        bool playSound = false;

        public AudioClip audioClipSingle;
        public AudioClip audioClipDouble;


        private void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
    
        }


        public void ToggleGoRandomMoves()
        {
            doRandomMoves = !doRandomMoves;
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

            x = Random.Range(0, 2);
            if (x == 0)
                animationSpecification.moveType = MoveType.singleMove;
            else
                animationSpecification.moveType = MoveType.doubleMove;

            return animationSpecification;
        }


        public void AddAnimation(AnimationSpecification animationSpecification)
        {
            if (isAnimating)
            {
                queue.Enqueue(animationSpecification);
                return;
            }

            if (playSound)
            {
                if (animationSpecification.moveType == MoveType.doubleMove)
                    myAudioSource.PlayOneShot(audioClipDouble, myAudioSource.volume); // <<<
                else
                    myAudioSource.PlayOneShot(audioClipSingle, myAudioSource.volume); // <<<
            }

            myCube.SpecifyAnimation(animationSpecification);
            faceMapPanel.SpecifyAnimation(animationSpecification);

            movesPanel.AddMove(animationSpecification);

            if (animationSpecification.rotationDirection == RotationDirection.reverse)
                angleStep = -baseAngleStep;
            else
                angleStep = baseAngleStep;

            moveType = animationSpecification.moveType;

            animationStep = 0;
            isAnimating = true;
        }


        public void StopAnimation()
        {
            isAnimating = false;
            myCube.isAnimating = false;
            faceMapPanel.isAnimating = false;
        }


        public void ToggleSound()
        {
            playSound = !playSound;
        }


        public void SetVolume(float volume)
        {
            myAudioSource.volume = volume;
        }




        // Determine whether to "cycle" the facelets on "strips".
        bool IsAnimationOnStep(int animationStep)
        {
            return (animationStep == firstStep
            || animationStep == secondStep
            || animationStep == thirdStep
            || animationStep == fourthStep
            || animationStep == fifthStep
            || animationStep == sixthStep
            || animationStep == seventhStep
            || animationStep == eighthStep
            || animationStep == ninthStep
            || animationStep == tenthStep);
        }

        bool IsAnimationOnFinishStep(int animationStep)
        {
            return (animationStep == lastAnimationStepSingle
            || animationStep == lastAnimationStepDouble);
        }


        bool IsAnimationOnLast(int animationStep)
        {
            return (moveType == MoveType.singleMove && animationStep == lastAnimationStepSingle
                 || moveType == MoveType.doubleMove && animationStep == lastAnimationStepDouble);
        }


        public void DoRandomMove()
        {
            AnimationSpecification animationSpecification = GetRandomMove();
            AddAnimation(animationSpecification);
        }


        // Update is called once per frame
        void Update()
        {
            if (!isAnimating)
            {
                if (queue.Count > 0)
                {
                    AnimationSpecification animationSpecification = queue.Dequeue();
                    AddAnimation(animationSpecification);
                }

                if (doRandomMoves)
                    DoRandomMove();

                return;
            }

            animationStep++;

            faceMapPanel.DoAnimation(angleStep, IsAnimationOnStep(animationStep));
            myCube.DoAnimation(angleStep);

            // Transform the rotations into array manipulations.
            if (IsAnimationOnFinishStep(animationStep))
            {
                faceMapPanel.FinishAnimation();
                myCube.FinishAnimation();
            }

            if (IsAnimationOnLast(animationStep))
            {
                isAnimating = false;

                if (doRandomMoves)
                    AddAnimation(GetRandomMove());
            }
        }
    }
}