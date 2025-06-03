using UnityEngine;
using UnityEngine.UI;


namespace Rubix.GUI
{
    public class MainCamera : MonoBehaviour
    {
        Camera _camera;
        float _azimuth = 0.0f;
        float _elevation = 0.0f;

        Rect _fullView = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        Vector3 _initialPosition = new Vector3(0.0f, 0.0f, -10.0f);
        Rect _cameraPixelRect = new Rect();

        const float _rotateAmount = 1.0f;
        float _orbitDeltaAzimuth = 0.0f;

        bool _doOrbitCamera = false;


        void Awake()
        {
            _camera = gameObject.GetComponent<Camera>();

            ApplyCameraAzimuthElevation();
        }


        void Update()
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
                _azimuth += lookDelta.x * _rotateAmount;
            }
            _elevation += -lookDelta.y * _rotateAmount;

            RecalculateCamera();
        }


        void OrbitCamera()
        {
            _azimuth += _orbitDeltaAzimuth * _rotateAmount;

            RecalculateCamera();
        }


        void RecalculateCamera()
        {
            while (_azimuth >= 360.0f) _azimuth -= 360.0f;
            while (_azimuth < 0.0f) _azimuth += 360.0f;

            if (_elevation > 89.0f) _elevation = 89.0f;
            if (_elevation < -89.0f) _elevation = -89.0f;

            ApplyCameraAzimuthElevation();
        }


        void ApplyCameraAzimuthElevation()
        {
            Quaternion rotation = Quaternion.Euler(_elevation, _azimuth, 0.0f);

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
