using UnityEngine;
using UnityEngine.UI;


namespace Rubix.GUI
{
    [System.Serializable]
    public class AzimuthElevation
    {
        public float azimuth;
        public float elevation;
    }


    public class MainCamera : MonoBehaviour
    {
        public bool doOrbitCamera = false;
        public Slider orbitSlider;  // >>>

        [SerializeField]
        AzimuthElevation _azimuthElevation = new AzimuthElevation();

        Camera _camera;

        Rect _fullView = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        Vector3 _initialPosition = new Vector3(0.0f, 0.0f, -10.0f);
        Rect _cameraPixelRect = new Rect();

        const float _rotateAmount = 1.0f;
        Vector2 _orbitDelta = new Vector2(0.0f, 0.0f);


        void Awake()
        {
            _camera = gameObject.GetComponent<Camera>();


            _azimuthElevation.azimuth = 0.0f;
            _azimuthElevation.elevation = 0.0f;

            SetCameraAzimuthElevation(_azimuthElevation);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }


        void Update()
        {
            if (doOrbitCamera)
            {
                _orbitDelta.x = orbitSlider.value;
                OrbitCamera(_orbitDelta);
            }
        }


        public void ResetViewport()
        {
            (_azimuthElevation.azimuth, _azimuthElevation.elevation) = (0.0f, 0.0f);

            SetCameraAzimuthElevation(_azimuthElevation);
            _camera.rect = _fullView;
        }


        public void OrbitCamera(Vector2 lookDelta)
        {
            _azimuthElevation.azimuth += lookDelta.x * _rotateAmount;
            _azimuthElevation.elevation += lookDelta.y * _rotateAmount;

            // azimuthElevation.azimuth %= 360;
            while (_azimuthElevation.azimuth >= 360.0f) _azimuthElevation.azimuth -= 360.0f;
            while (_azimuthElevation.azimuth < 0.0f) _azimuthElevation.azimuth += 360.0f;

            if (_azimuthElevation.elevation > 89.0f) _azimuthElevation.elevation = 89.0f;
            if (_azimuthElevation.elevation < -89.0f) _azimuthElevation.elevation = -89.0f;

            SetCameraAzimuthElevation(_azimuthElevation);
        }


        public void SetCameraAzimuthElevation(AzimuthElevation azimuthElevation)
        {
            Quaternion rotation = Quaternion.Euler(-azimuthElevation.elevation, azimuthElevation.azimuth, 0.0f);

            Vector3 rotatedPosition = rotation * _initialPosition;

            transform.position = rotatedPosition;
            transform.LookAt(Vector3.zero);
        }


        public void MoveViewport(float move)
        {
            _cameraPixelRect.x = _camera.pixelRect.x + move;
            _cameraPixelRect.y = _camera.pixelRect.y;
            _cameraPixelRect.width = _camera.pixelRect.width - move;
            _cameraPixelRect.height = _camera.pixelRect.height;

            _camera.pixelRect = _cameraPixelRect;
        }
    }
}
