public class ControlsPanel : DragWindow
{
    public AnimationController animationController;
    public MainCamera mainCamera;


    public void ToggleGoRandomMoves()
    {
        animationController.ToggleGoRandomMoves();
    }


    public void ToggleOrbitCamera()
    {
        mainCamera.doOrbitCamera = !mainCamera.doOrbitCamera;
    }
}
