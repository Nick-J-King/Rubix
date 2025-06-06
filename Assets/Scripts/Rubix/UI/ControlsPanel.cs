﻿using Rubix.GUI;


namespace Rubix.UI
{
    public class ControlsPanel : DragWindow
    {
        public AnimationController animationController;
        public MainCamera mainCamera;


        public void ToggleGoRandomMoves(bool isOn)
        {
            animationController.SetRandomMoves(isOn);
        }


        public void ToggleOrbitCamera(bool isOn)
        {
            mainCamera.SetOrbit(isOn);
        }


        public void SetOrbitSpeed(float speed)
        {
            mainCamera.SetOrbitSpeed(speed);
        }


        public void ToggleSoundOn(bool isOn)
        {
            animationController.SetSound(isOn);
        }


        public void SetSoundVolume(float volume)
        {
            animationController.SetSoundVolume(volume);
        }


        public void SetSlowDown(float slowDown)
        {
            animationController.SetSlowDown(slowDown);
        }
    }
}
