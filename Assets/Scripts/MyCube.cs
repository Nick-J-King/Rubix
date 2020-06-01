using UnityEngine;


public class CubeletData
{
    public GameObject cubelet;

    public Texture textureNumberUp;
    public Texture textureNumberDown;
    public Texture textureNumberLeft;
    public Texture textureNumberRight;
    public Texture textureNumberFront;
    public Texture textureNumberBack;
    //public Sprite spritePlain;
}


public class MyCube : MonoBehaviour
{
    public GameObject cubeRoot;
    public GameObject innerSphere;
    public GameObject cubePlaceholder;

    // Materials.
    public Material faceMaterialBlue;
    public Material faceMaterialGreen;

    public Material faceMaterialYellow;
    public Material faceMaterialWhite;

    public Material faceMaterialRed;
    public Material faceMaterialOrange;

    public Material faceMaterialBlack;  // For the "innards".

    // Textures for each face.
    readonly Texture[,] cubeFaceletTextures = new Texture[5, 5];
        // Loaded up from Resources

    bool showTexture = true;

    //-------------------------------------------------
    //
    // Animation stuff...

    public bool isAnimating = false;

    CubeAxis cubeAxis;                      // Which axis we are currently rotating about.
    CubeSlices cubeSlices;                  // Which slices we are currently rotating.
    RotationDirection rotationDirection;    // "normal" or "reverse"

    //-------------------------------------------------

    public CubeletData[,,] cubeletData  = new CubeletData[5, 5, 5];                // Pointers from the array indices to the current cubelets.

    public GameObject[,,] mfOrigCubelets = new GameObject[5, 5, 5];             // Pointers from the array indices to the original cubelets.
    public TransformData[,,] mfOrigTransformData = new TransformData[5, 5, 5];  // A quick record of the original positions by array indices.

    public TransformData mfOrigSphereTransformData = new TransformData();


    void Awake()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                cubeFaceletTextures[x, y] = Resources.Load<Texture>($"Textures/Facelet{x}{y}t");
            }
        }
    }


    void Start()
    {
        cubePlaceholder.SetActive(false);

        mfOrigSphereTransformData = new TransformData(innerSphere.transform);

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (IsOuterCubelet(x, y, z))
                    {
                        cubeletData[x, y, z] = CreateCubelet(x, y, z);
                        mfOrigCubelets[x, y, z] = cubeletData[x, y, z].cubelet;
                        mfOrigTransformData[x, y, z] = new TransformData(cubeletData[x, y, z].cubelet.transform);
                    }
                    else
                    {
                        cubeletData[x, y, z] = null;
                        mfOrigCubelets[x, y, z] = null;
                        mfOrigTransformData[x, y, z] = null;
                    }
                }
            }
        }
    }


    bool IsOuterCubelet(int x, int y, int z)
    {
        if (x == 0 || x == 4)
            return true;
        if (y == 0 || y == 4)
            return true;
        if (z == 0 || z == 4)
            return true;
        return false;
    }


    bool IsOuterCubelet(int x, int y)
    {
        if (x == 0 || x == 4)
            return true;
        if (y == 0 || y == 4)
            return true;
        return false;
    }


    public void ResetScale()
    {
        transform.localScale = Vector3.one;
    }


    // FUN! Turn on gravity and physics!
    public void DoMyDestroy()
    {
        Rigidbody rb;

        rb = innerSphere.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (IsOuterCubelet(x, y, z))
                    {
                        rb = cubeletData[x, y, z].cubelet.GetComponent<Rigidbody>();
                        rb.useGravity = true;
                        rb.isKinematic = false;
                    }
                }
            }
        }
    }


    public void ResetCube()
    {
        Rigidbody rb;

        rb = innerSphere.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        mfOrigSphereTransformData.ApplyTo(innerSphere.transform);

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (IsOuterCubelet(x, y, z))
                    {
                        cubeletData[x, y, z].cubelet = mfOrigCubelets[x, y, z];

                        rb = cubeletData[x, y, z].cubelet.GetComponent<Rigidbody>();
                        rb.useGravity = false;
                        rb.isKinematic = true;

                        mfOrigTransformData[x, y, z].ApplyTo(cubeletData[x, y, z].cubelet.transform);
                    }
                }
            }
        }

        isAnimating = false;
    }


    public void ToggleTextures()
    {
        showTexture = !showTexture;

        if (showTexture)
        { 
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (IsOuterCubelet(x, y, z))
                        {
                            GameObject cubeletFace;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(0).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = cubeletData[x, y, z].textureNumberUp;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(1).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = cubeletData[x, y, z].textureNumberDown;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(2).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = cubeletData[x, y, z].textureNumberFront;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(3).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = cubeletData[x, y, z].textureNumberBack;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(4).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = cubeletData[x, y, z].textureNumberLeft;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(5).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = cubeletData[x, y, z].textureNumberRight;
                        }
                    }
                }
            }
        }
        else
        { 
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (IsOuterCubelet(x, y, z))
                        {
                            GameObject cubeletFace;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(0).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = null;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(1).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = null;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(2).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = null;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(3).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = null;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(4).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = null;

                            cubeletFace = cubeletData[x, y, z].cubelet.transform.GetChild(5).gameObject;
                            cubeletFace.GetComponent<MeshRenderer>().materials[0].mainTexture = null;
                        }
                    }
                }
            }
        }
    }


    public CubeletData CreateCubelet(int x, int y, int z)
    {
        string codeNumber = string.Format("{0}{1}{2}", x, y, z);

        float xTrans = (x - 2) * 1.0f;
        float yTrans = (y - 2) * 1.0f;
        float zTrans = (z - 2) * 1.0f;

        string codeName = "Cubelet" + codeNumber;

        CubeletData cd = new CubeletData();

        GameObject cubelet = new GameObject(codeName);

        cd.cubelet = cubelet;

        GameObject cubeletTop = new GameObject(codeName + "Top");
        GameObject cubeletBottom = new GameObject(codeName + "Bottom");
        GameObject cubeletFront = new GameObject(codeName + "Front");
        GameObject cubeletBack = new GameObject(codeName + "Back");
        GameObject cubeletLeft = new GameObject(codeName + "Left");
        GameObject cubeletRight = new GameObject(codeName + "Right");

        cubelet.transform.parent = cubeRoot.transform;

        cubeletTop.transform.parent = cubelet.transform;
        cubeletBottom.transform.parent = cubelet.transform;
        cubeletFront.transform.parent = cubelet.transform;
        cubeletBack.transform.parent = cubelet.transform;
        cubeletLeft.transform.parent = cubelet.transform;
        cubeletRight.transform.parent = cubelet.transform;

        cubelet.transform.Translate(xTrans, yTrans, zTrans);

        System.Type filterType = typeof(MeshFilter);
        MeshFilter mfTop = cubeletTop.AddComponent(filterType) as MeshFilter;
        MeshFilter mfBottom = cubeletBottom.AddComponent(filterType) as MeshFilter;
        MeshFilter mfFront = cubeletFront.AddComponent(filterType) as MeshFilter;
        MeshFilter mfBack = cubeletBack.AddComponent(filterType) as MeshFilter;
        MeshFilter mfLeft = cubeletLeft.AddComponent(filterType) as MeshFilter;
        MeshFilter mfRight = cubeletRight.AddComponent(filterType) as MeshFilter;

        System.Type rendererType = typeof(MeshRenderer);
        MeshRenderer mrTop = cubeletTop.AddComponent(rendererType) as MeshRenderer;
        MeshRenderer mrBottom = cubeletBottom.AddComponent(rendererType) as MeshRenderer;
        MeshRenderer mrFront = cubeletFront.AddComponent(rendererType) as MeshRenderer;
        MeshRenderer mrBack = cubeletBack.AddComponent(rendererType) as MeshRenderer;
        MeshRenderer mrLeft = cubeletLeft.AddComponent(rendererType) as MeshRenderer;
        MeshRenderer mrRight = cubeletRight.AddComponent(rendererType) as MeshRenderer;

        if (y == 4)
        {
            mrTop.material = faceMaterialBlue;
            mrTop.materials[0].mainTexture = cubeFaceletTextures[x, z];
        }
        else
        {
            mrTop.material = faceMaterialBlack;
        }

        if (y == 0)
        {
            mrBottom.material = faceMaterialGreen;
            mrBottom.materials[0].mainTexture = cubeFaceletTextures[x, 4 - z];
        }
        else
        {
            mrBottom.material = faceMaterialBlack;
        }

        if (z == 0)
        {
            mrFront.material = faceMaterialYellow;
            mrFront.materials[0].mainTexture = cubeFaceletTextures[x, y];

        }
        else
        {
            mrFront.material = faceMaterialBlack;
        }

        if (z == 4)
        {
            mrBack.material = faceMaterialWhite;
            mrBack.materials[0].mainTexture = cubeFaceletTextures[4 - x, y];   // NOTE: On map, the FacePanel is thereby rotated 180 degrees.
        }
        else
        {
            mrBack.material = faceMaterialBlack;
        }

        if (x == 0)
        {
            mrLeft.material = faceMaterialRed;
            mrLeft.materials[0].mainTexture = cubeFaceletTextures[4 - z, y];
        }
        else
        {
            mrLeft.material = faceMaterialBlack;
        }

        if (x == 4)
        {
            mrRight.material = faceMaterialOrange;
            mrRight.materials[0].mainTexture = cubeFaceletTextures[z, y];  // OK!
        }
        else
        {
            mrRight.material = faceMaterialBlack;
        }

        cd.textureNumberBack = mrBack.materials[0].mainTexture;
        cd.textureNumberFront = mrFront.materials[0].mainTexture;
        cd.textureNumberLeft = mrLeft.materials[0].mainTexture;
        cd.textureNumberRight = mrRight.materials[0].mainTexture;
        cd.textureNumberUp = mrTop.materials[0].mainTexture;
        cd.textureNumberDown = mrBottom.materials[0].mainTexture;

        int[] stdTriangles = new int[] { 0, 1, 2, 0, 2, 3 };

        Vector2[] stdUV = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        Vector3 vMMM = new  Vector3(-0.5f, -0.5f, -0.5f);
        Vector3 vMMP = new  Vector3(-0.5f, -0.5f, 0.5f);
        Vector3 vMPM = new  Vector3(-0.5f, 0.5f, -0.5f);
        Vector3 vMPP = new  Vector3(-0.5f, 0.5f, 0.5f);
        Vector3 vPMM = new  Vector3(0.5f, -0.5f, -0.5f);
        Vector3 vPMP = new  Vector3(0.5f, -0.5f, 0.5f);
        Vector3 vPPM = new  Vector3(0.5f, 0.5f, -0.5f);
        Vector3 vPPP = new  Vector3(0.5f, 0.5f, 0.5f);

        // x axis points right. y axis points up. z axis points into the screen.

        // Top --------------------

        mfTop.mesh = new Mesh
        {
            vertices = new Vector3[] { vMPM, vMPP, vPPP, vPPM },
            uv = stdUV,
            triangles = stdTriangles
        };

        RecalculateMesh(mfTop);

        // Bottom -----------------

        mfBottom.mesh = new Mesh
        {
            vertices = new Vector3[] { vMMP, vMMM, vPMM, vPMP },
            uv = stdUV,
            triangles = stdTriangles
        };

        RecalculateMesh(mfBottom);

        // Front ------------------

        mfFront.mesh = new Mesh
        {
            vertices = new Vector3[] { vMMM, vMPM, vPPM, vPMM },
            uv = stdUV,
            triangles = stdTriangles
        };

        RecalculateMesh(mfFront);

        // Back -------------------

        mfBack.mesh = new Mesh
        {
            vertices = new Vector3[] { vPMP, vPPP, vMPP, vMMP },
            uv = stdUV,
            triangles = stdTriangles
        };

        RecalculateMesh(mfBack);

        // Left -------------------

        mfLeft.mesh = new Mesh
        {
            vertices = new Vector3[] { vMMP, vMPP, vMPM, vMMM },
            uv = stdUV,
            triangles = stdTriangles
        };

        RecalculateMesh(mfLeft);

        // Right ------------------

        mfRight.mesh = new Mesh
        {
            vertices = new Vector3[] { vPMM, vPPM, vPPP, vPMP },
            uv = stdUV,
            triangles = stdTriangles
        };

        RecalculateMesh(mfRight);

        // Now, set up the extra cubelet stuff.
        cubelet.AddComponent<BoxCollider>();

        Rigidbody rb = cubelet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        cubelet.tag = "Cubelet";
        cubelet.layer = 8;  // "Clickable"

        return cd;
    }


    void RecalculateMesh(MeshFilter mf)
    {
        mf.mesh.RecalculateBounds();
        mf.mesh.RecalculateNormals();

    }


    // Specify the animation to do.
    // Initialise...
    public void SpecifyAnimation(AnimationSpecification animationSpecification)
    {
        cubeAxis = animationSpecification.cubeAxis;
        cubeSlices = animationSpecification.cubeSlices;
        rotationDirection = animationSpecification.rotationDirection;

        isAnimating = true;
    }


    // Perform a step in the animation.
    // Advance the rotation of the active slices on the active axis in the active direction by delta angle.
    // NOTE: We don't touch the "internal" cubelets - they are not represented.
    // NOTE: The finishing step is done separately...
    public void DoAnimation(float deltaAngle)
    {
        switch (cubeAxis)
        {
            case CubeAxis.x:

                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutXAxis(cubeletData[0, y, z].cubelet, deltaAngle);

                        if (IsOuterCubelet(y, z))
                        {
                            if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(cubeletData[1, y, z].cubelet, deltaAngle);

                            if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(cubeletData[2, y, z].cubelet, deltaAngle);

                            if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(cubeletData[3, y, z].cubelet, deltaAngle);
                        }

                        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutXAxis(cubeletData[4, y, z].cubelet, deltaAngle);
                    }
                }
                break;

            case CubeAxis.y:

                for (int x = 0; x < 5; x++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutYAxis(cubeletData[x, 0, z].cubelet, deltaAngle);

                        if (IsOuterCubelet(x, z))
                        {
                            if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(cubeletData[x, 1, z].cubelet, deltaAngle);

                            if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(cubeletData[x, 2, z].cubelet, deltaAngle);

                            if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(cubeletData[x, 3, z].cubelet, deltaAngle);
                        }

                        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutYAxis(cubeletData[x, 4, z].cubelet, deltaAngle);
                    }
                }
                break;

            case CubeAxis.z:

                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutZAxis(cubeletData[x, y, 0].cubelet, deltaAngle);

                        if (IsOuterCubelet(x, y))
                        {
                            if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(cubeletData[x, y, 1].cubelet, deltaAngle);

                            if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(cubeletData[x, y, 2].cubelet, deltaAngle);

                            if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(cubeletData[x, y, 3].cubelet, deltaAngle);
                        }

                        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutZAxis(cubeletData[x, y, 4].cubelet, deltaAngle);
                    }
                }
                break;
        }
    }


    // The controller tells us to finish the current animation.
    // Adjust the actual arrangement of cubelets.
    public void FinishAnimation()
    {
        switch (cubeAxis)
        {
            case CubeAxis.x:

                RotateCubeletArrayAboutXAxis(cubeSlices, rotationDirection);
                break;

            case CubeAxis.y:

                RotateCubeletArrayAboutYAxis(cubeSlices, rotationDirection);
                break;

            case CubeAxis.z:

                RotateCubeletArrayAboutZAxis(cubeSlices, rotationDirection);
                break;

        }

        isAnimating = false;    // DONE!
    }


    //-----------------------------------------------------
    //-----------------------------------------------------


    void RotateCubeletArrayAboutXAxis(CubeSlices cubeSlicesIn, RotationDirection direction)
    {
        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutXAxisSlice(0, direction);
        if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutXAxisSlice(1, direction);

        if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutXAxisSlice(2, direction);

        if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutXAxisSlice(3, direction);
        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutXAxisSlice(4, direction);
    }


    void RotateCubeletArrayAboutYAxis(CubeSlices cubeSlicesIn, RotationDirection direction)
    {
        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutYAxisSlice(0, direction);
        if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutYAxisSlice(1, direction);

        if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutYAxisSlice(2, direction);

        if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutYAxisSlice(3, direction);
        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutYAxisSlice(4, direction);
    }


    void RotateCubeletArrayAboutZAxis(CubeSlices cubeSlicesIn, RotationDirection direction)
    {
        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutZAxisSlice(0, direction);
        if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutZAxisSlice(1, direction);

        if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutZAxisSlice(2, direction);

        if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutZAxisSlice(3, direction);
        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
            RotateCubeletArrayAboutZAxisSlice(4, direction);
    }


    // Rotate the array of cublets themselves!
    void RotateCubeletArrayAboutXAxisSlice(int xSlice, RotationDirection direction)
    {
        Cycle4Cublelets(new Vector3Int(xSlice, 0, 0), new Vector3Int(xSlice, 0, 4), new Vector3Int(xSlice, 4, 4), new Vector3Int(xSlice, 4, 0), direction);
        Cycle4Cublelets(new Vector3Int(xSlice, 0, 1), new Vector3Int(xSlice, 1, 4), new Vector3Int(xSlice, 4, 3), new Vector3Int(xSlice, 3, 0), direction);
        Cycle4Cublelets(new Vector3Int(xSlice, 0, 2), new Vector3Int(xSlice, 2, 4), new Vector3Int(xSlice, 4, 2), new Vector3Int(xSlice, 2, 0), direction);
        Cycle4Cublelets(new Vector3Int(xSlice, 0, 3), new Vector3Int(xSlice, 3, 4), new Vector3Int(xSlice, 4, 1), new Vector3Int(xSlice, 1, 0), direction);

        if (xSlice == 0 || xSlice == 4)
        {
            Cycle4Cublelets(new Vector3Int(xSlice, 1, 1), new Vector3Int(xSlice, 1, 3), new Vector3Int(xSlice, 3, 3), new Vector3Int(xSlice, 3, 1), direction);
            Cycle4Cublelets(new Vector3Int(xSlice, 1, 2), new Vector3Int(xSlice, 2, 3), new Vector3Int(xSlice, 3, 2), new Vector3Int(xSlice, 2, 1), direction);
        }
    }

    // Rotate the array of cublets themselves!
    void RotateCubeletArrayAboutYAxisSlice(int ySlice, RotationDirection direction)
    {
        Cycle4CubleletsR(new Vector3Int(0, ySlice, 0), new Vector3Int(0, ySlice, 4), new Vector3Int(4, ySlice, 4), new Vector3Int(4, ySlice, 0), direction);
        Cycle4CubleletsR(new Vector3Int(0, ySlice, 1), new Vector3Int(1, ySlice, 4), new Vector3Int(4, ySlice, 3), new Vector3Int(3, ySlice, 0), direction);
        Cycle4CubleletsR(new Vector3Int(0, ySlice, 2), new Vector3Int(2, ySlice, 4), new Vector3Int(4, ySlice, 2), new Vector3Int(2, ySlice, 0), direction);
        Cycle4CubleletsR(new Vector3Int(0, ySlice, 3), new Vector3Int(3, ySlice, 4), new Vector3Int(4, ySlice, 1), new Vector3Int(1, ySlice, 0), direction);

        if (ySlice == 0 || ySlice == 4)
        {
            Cycle4CubleletsR(new Vector3Int(1, ySlice, 1), new Vector3Int(1, ySlice, 3), new Vector3Int(3, ySlice, 3), new Vector3Int(3, ySlice, 1), direction);
            Cycle4CubleletsR(new Vector3Int(1, ySlice, 2), new Vector3Int(2, ySlice, 3), new Vector3Int(3, ySlice, 2), new Vector3Int(2, ySlice, 1), direction);
        }
    }

    // Rotate the array of cublets themselves!
    void RotateCubeletArrayAboutZAxisSlice(int zSlice, RotationDirection direction)
    {
        Cycle4Cublelets(new Vector3Int(0, 0, zSlice), new Vector3Int(0, 4, zSlice), new Vector3Int(4, 4, zSlice), new Vector3Int(4, 0, zSlice), direction);
        Cycle4Cublelets(new Vector3Int(0, 1, zSlice), new Vector3Int(1, 4, zSlice), new Vector3Int(4, 3, zSlice), new Vector3Int(3, 0, zSlice), direction);
        Cycle4Cublelets(new Vector3Int(0, 2, zSlice), new Vector3Int(2, 4, zSlice), new Vector3Int(4, 2, zSlice), new Vector3Int(2, 0, zSlice), direction);
        Cycle4Cublelets(new Vector3Int(0, 3, zSlice), new Vector3Int(3, 4, zSlice), new Vector3Int(4, 1, zSlice), new Vector3Int(1, 0, zSlice), direction);

        if (zSlice == 0 || zSlice == 4)
        {
            Cycle4Cublelets(new Vector3Int(1, 1, zSlice), new Vector3Int(1, 3, zSlice), new Vector3Int(3, 3, zSlice), new Vector3Int(3, 1, zSlice), direction);
            Cycle4Cublelets(new Vector3Int(1, 2, zSlice), new Vector3Int(2, 3, zSlice), new Vector3Int(3, 2, zSlice), new Vector3Int(2, 1, zSlice), direction);
        }
    }


    // Cycle the cubelets.

    void Cycle4Cublelets(Vector3Int c0, Vector3Int c1, Vector3Int c2, Vector3Int c3, RotationDirection direction)
    {
        if (direction == RotationDirection.reverse)
        {
            Cycle4CubleletsR(c0, c1, c2, c3, RotationDirection.normal);
            return;
        }

        CubeletData cd = cubeletData[c0.x, c0.y, c0.z];
        cubeletData[c0.x, c0.y, c0.z] = cubeletData[c1.x, c1.y, c1.z];
        cubeletData[c1.x, c1.y, c1.z] = cubeletData[c2.x, c2.y, c2.z];
        cubeletData[c2.x, c2.y, c2.z] = cubeletData[c3.x, c3.y, c3.z];
        cubeletData[c3.x, c3.y, c3.z] = cd;
    }


    void Cycle4CubleletsR(Vector3Int c0, Vector3Int c1, Vector3Int c2, Vector3Int c3, RotationDirection direction)
    {
        if (direction == RotationDirection.reverse)
        {
            Cycle4Cublelets(c0, c1, c2, c3, RotationDirection.normal);
            return;
        }

        CubeletData cd = cubeletData[c3.x, c3.y, c3.z];
        cubeletData[c3.x, c3.y, c3.z] = cubeletData[c2.x, c2.y, c2.z];
        cubeletData[c2.x, c2.y, c2.z] = cubeletData[c1.x, c1.y, c1.z];
        cubeletData[c1.x, c1.y, c1.z] = cubeletData[c0.x, c0.y, c0.z];
        cubeletData[c0.x, c0.y, c0.z] = cd;
    }


    void RotateCubeletAboutXAxis(GameObject cubelet, float angle)
    {
        Vector3 xAxis = new Vector3(1.0f, 0.0f, 0.0f);
        Transform transform1 = cubelet.transform;

        float x = transform1.position.x;
        float y = transform1.position.y;
        float z = transform1.position.z;

        float c = Mathf.Cos(angle * Mathf.Deg2Rad);
        float s = Mathf.Sin(angle * Mathf.Deg2Rad);

        float yNew = c * y - s * z;
        float zNew = s * y + c * z;

        Vector3 position = new Vector3(x, yNew, zNew);

        cubelet.transform.Rotate(xAxis, angle, Space.World);
        cubelet.transform.position = position;
    }


    void RotateCubeletAboutYAxis(GameObject cubelet, float angle)
    {
        Vector3 yAxis = new Vector3(0.0f, 1.0f, 0.0f);
        Transform transform1 = cubelet.transform;

        float x = transform1.position.x;
        float y = transform1.position.y;
        float z = transform1.position.z;

        float c = Mathf.Cos(angle * Mathf.Deg2Rad);
        float s = Mathf.Sin(angle * Mathf.Deg2Rad);

        float xNew = c * x + s * z;
        float zNew = -s * x + c * z;

        Vector3 position = new Vector3(xNew, y, zNew);

        cubelet.transform.Rotate(yAxis, angle, Space.World);
        cubelet.transform.position = position;
    }


    void RotateCubeletAboutZAxis(GameObject cubelet, float angle)
    {
        Vector3 zAxis = new Vector3(0.0f, 0.0f, 1.0f);
        Transform transform1 = cubelet.transform;

        float x = transform1.position.x;
        float y = transform1.position.y;
        float z = transform1.position.z;

        float c = Mathf.Cos(angle * Mathf.Deg2Rad);
        float s = Mathf.Sin(angle * Mathf.Deg2Rad);

        float xNew = c * x - s * y;
        float yNew = s * x + c * y;

        Vector3 position = new Vector3(xNew, yNew, z);

        cubelet.transform.Rotate(zAxis, angle, Space.World);
        cubelet.transform.position = position;
    }
}
