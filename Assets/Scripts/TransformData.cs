using UnityEngine;
using System;


namespace Rubix.Data
{ 
    // Used to conveniently copy and set transforms.

    [Serializable]
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


        public void ApplyScaleTo(Transform transform)
        {
            transform.localScale = localScale;
        }


        public void ApplyTranslationTo(Transform transform)
        {
            transform.localPosition = localPosition;
        }


        public void ApplyRotationTo(Transform transform)
        {
            transform.localEulerAngles = localEulerAngles;
        }
    }
}
