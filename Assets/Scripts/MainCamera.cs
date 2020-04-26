using UnityEngine;


public struct AzimuthElevation
{
    public float azimuth;
    public float elevation;
}


public struct XYZ
{
    public float x;
    public float y;
    public float z;
}


public class MainCamera : MonoBehaviour
{
    //[Header("Data")]
    //[SerializeField]

    //private InputData inputData;

    private float RotateAmount = 1.0f;

    public AzimuthElevation azimuthElevation;
    public XYZ xyz;


    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        //Vector2 lookDelta = inputData.LookAction.ReadValue<Vector2>();
        //Debug.Log(lookDelta);
        //OrbitCamera(lookDelta);
    }

   public  void Start()
    {
        azimuthElevation.azimuth = 0.0f;
        azimuthElevation.elevation = 0.0f;

        xyz.x = 0.0f;
        xyz.y = 0.0f;
        xyz.z = 0.0f;

        SetCameraAzimuthElevation(azimuthElevation);
    }


    void LateUpdate()
    {
       // OrbitCamera();
    }


    public void OrbitCamera(Vector2 lookDelta)
    {
        azimuthElevation.azimuth += lookDelta.x * RotateAmount;
        azimuthElevation.elevation += lookDelta.y * RotateAmount;

        azimuthElevation.azimuth = azimuthElevation.azimuth % 360;
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
        xyz.x = rotatedVector.x;
        xyz.y = rotatedVector.y;
        xyz.z = rotatedVector.z;

        transform.position = rotatedVector;
        transform.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
    }
}
