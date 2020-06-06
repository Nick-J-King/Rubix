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

        public AudioClip audioClipSingle;
        public AudioClip audioClipDouble;

        public bool isAnimating = false;

        readonly Queue<AnimationSpecification> _queue = new Queue<AnimationSpecification>();

        bool _doRandomMoves = false;

        int _animationStep = 0;

        readonly float _baseAngleStep = 5.0f;

        float _angleStep = 5.0f;

        readonly int _firstStep = 2;
        readonly int _secondStep = 4;
        readonly int _thirdStep = 9;
        readonly int _fourthStep = 14;
        readonly int _fifthStep = 16;

        readonly int _lastAnimationStepSingle = 18;

        readonly int _sixthStep = 2 + 18;
        readonly int _seventhStep = 4 + 18;
        readonly int _eighthStep = 9 + 18;
        readonly int _ninthStep = 14 + 18;
        readonly int _tenthStep = 16 + 18;

        readonly int _lastAnimationStepDouble = 36;

        MoveType _moveType = MoveType.singleMove;



        AudioSource _myAudioSource;
        bool _playSound = false;


        private void Start()
        {
            _myAudioSource = GetComponent<AudioSource>();
    
        }


        public void ToggleGoRandomMoves()
        {
            _doRandomMoves = !_doRandomMoves;
        }


        public void AddAnimation(AnimationSpecification animationSpecification)
        {
            if (isAnimating)
            {
                _queue.Enqueue(animationSpecification);
                return;
            }

            if (_playSound)
            {
                if (animationSpecification.moveType == MoveType.doubleMove)
                    _myAudioSource.PlayOneShot(audioClipDouble, _myAudioSource.volume); // <<<
                else
                    _myAudioSource.PlayOneShot(audioClipSingle, _myAudioSource.volume); // <<<
            }

            myCube.SpecifyAnimation(animationSpecification);
            faceMapPanel.SpecifyAnimation(animationSpecification);

            movesPanel.AddMove(animationSpecification);

            if (animationSpecification.rotationDirection == RotationDirection.reverse)
                _angleStep = -_baseAngleStep;
            else
                _angleStep = _baseAngleStep;

            _moveType = animationSpecification.moveType;

            _animationStep = 0;
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
            _playSound = !_playSound;
        }


        public void SetVolume(float volume)
        {
            _myAudioSource.volume = volume;
        }




        // Determine whether to "cycle" the facelets on "strips".
        bool IsAnimationOnStep(int animationStep)
        {
            return (animationStep == _firstStep
            || animationStep == _secondStep
            || animationStep == _thirdStep
            || animationStep == _fourthStep
            || animationStep == _fifthStep
            || animationStep == _sixthStep
            || animationStep == _seventhStep
            || animationStep == _eighthStep
            || animationStep == _ninthStep
            || animationStep == _tenthStep);
        }

        bool IsAnimationOnFinishStep(int animationStep)
        {
            return (animationStep == _lastAnimationStepSingle
            || animationStep == _lastAnimationStepDouble);
        }


        bool IsAnimationOnLast(int animationStep)
        {
            return (_moveType == MoveType.singleMove && animationStep == _lastAnimationStepSingle
                 || _moveType == MoveType.doubleMove && animationStep == _lastAnimationStepDouble);
        }


        public void DoRandomMove()
        {
            AnimationSpecification animationSpecification = AnimationData.GetRandomMove();
            AddAnimation(animationSpecification);
        }


        // Update is called once per frame
        void Update()
        {
            if (!isAnimating)
            {
                if (_queue.Count > 0)
                {
                    AnimationSpecification animationSpecification = _queue.Dequeue();
                    AddAnimation(animationSpecification);
                }

                if (_doRandomMoves)
                    DoRandomMove();

                return;
            }

            _animationStep++;

            faceMapPanel.DoAnimation(_angleStep, IsAnimationOnStep(_animationStep));
            myCube.DoAnimation(_angleStep);

            // Transform the rotations into array manipulations.
            if (IsAnimationOnFinishStep(_animationStep))
            {
                faceMapPanel.FinishAnimation();
                myCube.FinishAnimation();
            }

            if (IsAnimationOnLast(_animationStep))
            {
                isAnimating = false;

                if (_doRandomMoves)
                    AddAnimation(AnimationData.GetRandomMove());
            }
        }
    }
}