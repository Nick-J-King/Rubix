using UnityEngine;


// Used to conveniently copy and set transforms.

//..[Serializable]
public class TransformData
{
    public Vector3 localPosition = Vector3.zero;
    public Vector3 localEulerAngles = Vector3.zero;
    public Vector3 localScale = Vector3.one;


    // Unity requires a default constructor for serialization
    public TransformData() { }


    public TransformData(Transform transform)
    {
        localPosition = transform.localPosition;
        localEulerAngles = transform.localEulerAngles;
        localScale = transform.localScale;
    }


    public void ApplyTo(Transform transform)
    {
        transform.localPosition = localPosition;
        transform.localEulerAngles = localEulerAngles;
        transform.localScale = localScale;
    }


    public void ApplyRotationTo(Transform transform)
    {
        transform.localEulerAngles = localEulerAngles;
    }
}
