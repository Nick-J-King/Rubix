using System.Collections.Generic;
using Rubix.Data;
using Rubix.GUI;
using Rubix.UI;
using UnityEngine;


namespace Rubix
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

        public int skipFrames = 0;

        AudioSource _myAudioSource;
        bool _playSound = false;

        readonly Queue<Rubix.Data.AnimationSpecification> _queue = new Queue<Rubix.Data.AnimationSpecification>();

        bool _doRandomMoves = false;

        int _animationStep = 0;
        int _skipStep = 0;

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

        AnimationSpecification _lastAnimationSpecification;
        MoveType _moveType = MoveType.singleMove;


        void Awake()
        {
            _lastAnimationSpecification = AnimationData.GetNullMove();
            _myAudioSource = GetComponent<AudioSource>();

        }


        public void ToggleGoRandomMoves()
        {
            _doRandomMoves = !_doRandomMoves;
        }


        public void SetRandomMoves(bool doRandomMoves)
        {
            _doRandomMoves = doRandomMoves;
        }


        public void SetSound(bool isOn)
        {
            _playSound = isOn;
        }


        public void SetSoundVolume(float volume)
        {
            _myAudioSource.volume = volume;
        }


        public void SetSlowDown(float slowDown)
        {
            skipFrames = (int)slowDown;
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
            faceMapPanel.SpecifyMapAnimation(animationSpecification);

            movesPanel.AddMove(animationSpecification);

            if (animationSpecification.rotationDirection == RotationDirection.reverse)
                _angleStep = -_baseAngleStep;
            else
                _angleStep = _baseAngleStep;

            _moveType = animationSpecification.moveType;

            _lastAnimationSpecification = animationSpecification;
            // Record the "last" animation added to prevent random moves being "duplicated".

            _animationStep = 0;
            isAnimating = true;
        }


        public void StopAnimation()
        {
            isAnimating = false;
            myCube.isAnimating = false;
            faceMapPanel.isAnimating = false;
        }


        // Determine whether to "cycle" the facelets on certain "steps".
        private bool IsAnimationOnStep(int animationStep)
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


        // Whether a quarter turn has been completed.
        private bool IsAnimationOnFinishStep(int animationStep)
        {
            return (animationStep == _lastAnimationStepSingle
                    || animationStep == _lastAnimationStepDouble);
        }


        // Whether this animation has completely finished.
        private bool IsAnimationOnLastStep(int animationStep)
        {
            return (_moveType == MoveType.singleMove && animationStep == _lastAnimationStepSingle
                    || _moveType == MoveType.doubleMove && animationStep == _lastAnimationStepDouble);
        }


        public void AddRandomMove()
        {
            AnimationSpecification animationSpecification = AnimationData.GetRandomMove();

            // Don't allow "similar moves". This avoids back and forth, and triple moves.
            while (animationSpecification.IsSimilarMove(_lastAnimationSpecification))
                animationSpecification = AnimationData.GetRandomMove();

            AddAnimation(animationSpecification);
        }


        private void Update()
        {
            _skipStep++;
            if (_skipStep <= skipFrames)
            {
                return;
            }

            _skipStep = 0;

            if (!isAnimating)
            {
                if (_queue.Count > 0)
                {
                    // We are not currently performing an animation,
                    // but there are Animations on the queue,
                    // so peel off an animation from the queue,
                    // Add it, and proceed directly to execute it.
                    AnimationSpecification animationSpecification = _queue.Dequeue();
                    AddAnimation(animationSpecification);
                }
                else if (_doRandomMoves)
                {
                    // We are not currently performing an animation,
                    // but we have specified to "do random moves",
                    // so Add a random animation, and proceed directly to execute it.
                    AddRandomMove();
                }
                else
                {
                    return;
                }
            }

            _animationStep++;

            faceMapPanel.DoMapAnimation(_angleStep, IsAnimationOnStep(_animationStep));
            myCube.DoAnimation(_angleStep);

            // Transform the rotations into array manipulations.
            if (IsAnimationOnFinishStep(_animationStep))
            {
                faceMapPanel.FinishMapAnimation();
                myCube.FinishAnimation();
            }

            if (IsAnimationOnLastStep(_animationStep))
            {
                isAnimating = false;
            }
        }
    }
}