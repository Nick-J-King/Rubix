using UnityEngine;


namespace Rubix.GUI
{
    public class MainCamera : MonoBehaviour
    {
        private Camera _camera;
        private float _azimuth = 0.0f;
        private float _elevation = 0.0f;

        private readonly Rect _fullView = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        private readonly Vector3 _initialPosition = new Vector3(0.0f, 0.0f, -10.0f);
        private Rect _cameraPixelRect = new Rect();

        private const float RotateAmount = 1.0f;
        private float _orbitDeltaAzimuth = 0.0f;

        private bool _doOrbitCamera = false;


        private void Awake()
        {
            _camera = gameObject.GetComponent<Camera>();

            ApplyCameraAzimuthElevation();
        }


        private void Update()
        {
            if (_doOrbitCamera)
            {
                OrbitCamera();
            }
        }


        public void SetOrbit(bool isOn)
        {
            _doOrbitCamera = isOn;
        }


        public void SetOrbitSpeed(float orbitSpeed)
        {
            _orbitDeltaAzimuth = orbitSpeed;
        }


        public void ResetViewport()
        {
            (_azimuth, _elevation) = (0.0f, 0.0f);

            ApplyCameraAzimuthElevation();
            _camera.rect = _fullView;
        }


        public void OrientCamera(Vector2 lookDelta)
        {
            if (!_doOrbitCamera)
            { 
                _azimuth += lookDelta.x * RotateAmount;
            }
            _elevation += -lookDelta.y * RotateAmount;

            RecalculateCamera();
        }
        
        
        // Orbit the camera one update. 
        private void OrbitCamera()
        {
            _azimuth += _orbitDeltaAzimuth * RotateAmount;

            RecalculateCamera();
        }


        private void RecalculateCamera()
        {
            while (_azimuth >= 360.0f) _azimuth -= 360.0f;
            while (_azimuth < 0.0f) _azimuth += 360.0f;

            if (_elevation > 89.0f) _elevation = 89.0f;
            if (_elevation < -89.0f) _elevation = -89.0f;

            ApplyCameraAzimuthElevation();
        }


        private void ApplyCameraAzimuthElevation()
        {
            Quaternion rotation = Quaternion.Euler(_elevation, _azimuth, 0.0f);

            Vector3 rotatedPosition = rotation * _initialPosition;

            transform.position = rotatedPosition;
            transform.LookAt(Vector3.zero);
        }


        /// <summary>
        /// Moves the viewport the Main Camera maps to by shifting the left edge.
        /// </summary>
        /// <param name="move">Units to move the viewport's left edge.</param>
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
