using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class InputData : ScriptableObject
{
    //public InputAction LookAction;
    //public InputAction FireAction;

    private void OnEnable()
    {
        //LookAction.Enable();
        //FireAction.Enable();
    }
    private void OnDisable()
    {
        //L/ookAction.Disable();
        //FireAction.Disable();
    }
}
