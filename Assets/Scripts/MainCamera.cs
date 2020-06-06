using UnityEngine;
using UnityEngine.UI;


namespace Rubix.GUI
{ 
    public struct AzimuthElevation
    {
        public float azimuth;
        public float elevation;
    }


    public class MainCamera : MonoBehaviour
    {
        public Slider orbitSlider;
        public Camera cam;

        readonly float rotateAmount = 1.0f;

        public bool doOrbitCamera = false;
        Vector2 orbitDelta = new Vector2(0.0f, 0.0f);

        public AzimuthElevation azimuthElevation;


        private void Awake()
        {
            SetCameraAzimuthElevation(azimuthElevation);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }


        private void FixedUpdate()
        {
            //OrbitCamera(lookDelta);
        }


        public void ResetViewport()
        {
            (azimuthElevation.azimuth, azimuthElevation.elevation) = (0.0f, 0.0f);

            SetCameraAzimuthElevation(azimuthElevation);
            cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        }


        void LateUpdate()
        {
           // OrbitCamera();
        }


        void Update()
        {
            if (doOrbitCamera)
            {
                orbitDelta.x = orbitSlider.value;
                OrbitCamera(orbitDelta);
            }
        }


        public void OrbitCamera(Vector2 lookDelta)
        {
            azimuthElevation.azimuth += lookDelta.x * rotateAmount;
            azimuthElevation.elevation += lookDelta.y * rotateAmount;

            // azimuthElevation.azimuth %= 360;
            while (azimuthElevation.azimuth >= 360.0f) azimuthElevation.azimuth -= 360.0f;
            while (azimuthElevation.azimuth < 0.0f) azimuthElevation.azimuth += 360.0f;

            if (azimuthElevation.elevation > 89.0f) azimuthElevation.elevation = 89.0f;
            if (azimuthElevation.elevation < -89.0f) azimuthElevation.elevation = -89.0f;

            SetCameraAzimuthElevation(azimuthElevation);
        }


        public void SetCameraAzimuthElevation(AzimuthElevation azimuthElevation)
        {
            Vector3 position = new Vector3(0.0f, 0.0f, -10.0f);

            Quaternion rotation = Quaternion.Euler(-azimuthElevation.elevation, azimuthElevation.azimuth, 0.0f);

            Vector3 rotatedVector = rotation * position;

            transform.position = rotatedVector;
            transform.LookAt(Vector3.zero);
        }
    }
}
