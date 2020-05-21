using UnityEngine;


public class MyCube : MonoBehaviour
{
    public GameObject cubeRoot;
    public GameObject cubePlaceholder;

    // Materials.
    public Material faceMaterialBlue;
    public Material faceMaterialGreen;

    public Material faceMaterialYellow;
    public Material faceMaterialWhite;

    public Material faceMaterialRed;
    public Material faceMaterialOrange;

    public Material faceMaterialBlack;  // For the "innards"

    // Animation
    public bool isAnimating;
    public float currentAngle;
    public float finalAngle;
    public float deltaAngle;
    public RotationDirection rotationDirection;
    public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
    public CubeSlices cubeSlices;   // Which slices we are currently rotating.


    // PRIVATE members --------------------------

    private GameObject[,,] mfCubelets;

    enum CubeColours { Top = 0, Bottom = 1, Front = 2, Back = 3, Left = 4, Right = 5 };


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


    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }


    // Use this for initialization
    public void Initialise()
    {
        cubePlaceholder.SetActive(false);

        isAnimating = false;
        mfCubelets = new GameObject[5, 5, 5];

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (IsOuterCubelet(x,y,z))
                    { 
                        mfCubelets[x, y, z] = CreateCubelet(x, y, z);
                    }
                    else
                    {
                        mfCubelets[x, y, z] = null;
                    }
                }
            }
        }
    }


    public GameObject CreateCubelet(int x, int y, int z)
    {
        string codeNumber = string.Format("{0}{1}{2}", x, y, z);

        float xTrans = (x - 2) * 1.04f;
        float yTrans = (y - 2) * 1.04f;
        float zTrans = (z - 2) * 1.04f;

        string codeName = "Cubelet" + codeNumber;

        GameObject cubelet = new GameObject(codeName);

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
        }
        else
        {
            mrTop.material = faceMaterialBlack;
        }

        if (y == 0)
        {
            mrBottom.material = faceMaterialGreen;
        }
        else
        {
            mrBottom.material = faceMaterialBlack;
        }

        if (z == 0)
        {
            mrFront.material = faceMaterialYellow;
        }
        else
        {
            mrFront.material = faceMaterialBlack;
        }

        if (z == 4)
        {
            mrBack.material = faceMaterialWhite;
        }
        else
        {
            mrBack.material = faceMaterialBlack;
        }

        if (x == 0)
        {
            mrLeft.material = faceMaterialRed;
        }
        else
        {
            mrLeft.material = faceMaterialBlack;
        }

        if (x == 4)
        {
            mrRight.material = faceMaterialOrange;
        }
        else
        {
            mrRight.material = faceMaterialBlack;
        }


        // Top --------------------

        Mesh mTop = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(-0.5f, 0.5f, -0.5f),
                new Vector3(-0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, 0.5f, -0.5f)
            },

            uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0)
            },

            triangles = new int[]
            {
                0,1,2, 0,2,3
            }
        };

        mfTop.mesh = mTop;
        mTop.RecalculateBounds();
        mTop.RecalculateNormals();


        // Bottom -----------------

        Mesh mBottom = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, 0.5f),
                new Vector3(-0.5f, -0.5f, 0.5f)
            },

            uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0)
            },

            triangles = new int[]
            {
                0,1,2, 0,2,3
            }
        };

        mfBottom.mesh = mBottom;
        mBottom.RecalculateBounds();
        mBottom.RecalculateNormals();


        // Front ------------------

        Mesh mFront = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, -0.5f),
                new Vector3(-0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, -0.5f)
            },

            uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0)
            },

            triangles = new int[]
            {
                0,1,2, 0,2,3
            }
        };

        mfFront.mesh = mFront;
        mFront.RecalculateBounds();
        mFront.RecalculateNormals();


        // Back -------------------

        Mesh mBack = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f),
                new Vector3(0.5f, 0.5f, 0.5f),
                new Vector3(-0.5f, 0.5f, 0.5f)
            },

            uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0)
            },

            triangles = new int[]
            {
                0,1,2, 0,2,3
            }
        };

        mfBack.mesh = mBack;
        mBack.RecalculateBounds();
        mBack.RecalculateNormals();


        // Left -------------------

        Mesh mLeft = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, -0.5f),
                new Vector3(-0.5f, -0.5f, 0.5f),
                new Vector3(-0.5f, 0.5f, 0.5f),
                new Vector3(-0.5f, 0.5f, -0.5f)
            },

            uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0)
            },

            triangles = new int[]
            {
                0,1,2, 0,2,3
            }
        };

        mfLeft.mesh = mLeft;
        mLeft.RecalculateBounds();
        mLeft.RecalculateNormals();


        // Right ------------------

        Mesh mRight = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f)
             },

            uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0)
             },

            triangles = new int[]
            {
                0,1,2, 0,2,3
            }
        };

        mfRight.mesh = mRight;
        mRight.RecalculateBounds();
        mRight.RecalculateNormals();

        cubelet.AddComponent<BoxCollider>();

        cubelet.tag = "Cubelet";
        cubelet.layer = 8;  //"Clickable";

        return cubelet;
    }


    // Update is called once per frame
    void Update()
    {
        Animate();
    }


    public void Animate()
    {
        if (!isAnimating)
        {
            return;
        }


        switch (cubeAxis)
        {
            case CubeAxis.x:

                if (currentAngle >= finalAngle)
                {
                    isAnimating = false;

                    // Adjust the cubelet array now the rotation has finished.
                    RotateCubeletArrayAboutXAxis(cubeSlices, rotationDirection);   // for now, just 90 degrees anticlockwise !!!
                    return;
                }

                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutXAxis(mfCubelets[0, y, z], deltaAngle);

                        if (IsOuterCubelet(y,z))
                        {
                            if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(mfCubelets[1, y, z], deltaAngle);


                            if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(mfCubelets[2, y, z], deltaAngle);


                            if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(mfCubelets[3, y, z], deltaAngle);
                        }
                        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutXAxis(mfCubelets[4, y, z], deltaAngle);
                    }
                }

                break;

            case CubeAxis.y:

                if (currentAngle >= finalAngle)
                {
                    isAnimating = false;

                    // Adjust the cubelet array now the rotation has finished.
                    RotateCubeletArrayAboutYAxis(cubeSlices, rotationDirection);
                    return;
                }

                for (int x = 0; x < 5; x++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutYAxis(mfCubelets[x, 0, z], deltaAngle);

                        if (IsOuterCubelet(x,z))
                        {
                            if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(mfCubelets[x, 1, z], deltaAngle);


                            if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(mfCubelets[x, 2, z], deltaAngle);


                            if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                                 RotateCubeletAboutYAxis(mfCubelets[x, 3, z], deltaAngle);
                        }

                        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutYAxis(mfCubelets[x, 4, z], deltaAngle);
                    }
                }
                break;

            case CubeAxis.z:

                if (currentAngle >= finalAngle)
                {
                    isAnimating = false;

                    // Adjust the cubelet array now the rotation has finished.
                    RotateCubeletArrayAboutZAxis(cubeSlices, rotationDirection);
                    return;
                }

                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutZAxis(mfCubelets[x, y, 0], deltaAngle);

                        if (IsOuterCubelet(x,y))
                        {
                            if (cubeSlices == CubeSlices.s1 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(mfCubelets[x, y, 1], deltaAngle);


                            if (cubeSlices == CubeSlices.s2 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(mfCubelets[x, y, 2], deltaAngle);


                            if (cubeSlices == CubeSlices.s3 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(mfCubelets[x, y, 3], deltaAngle);
                        }

                        if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                            RotateCubeletAboutZAxis(mfCubelets[x, y, 4], deltaAngle);
                    }
                }
                break;

        }

        if (rotationDirection == RotationDirection.normal)
            currentAngle += deltaAngle;
        else
            currentAngle -= deltaAngle;
    }


    public void DoAnim(CubeAxis axis, CubeSlices slices, RotationDirection direction)
    {
        if (isAnimating)
        {
            return;
        }

        isAnimating = true;
        currentAngle = 0.0f;
        finalAngle = 90.0f;

        rotationDirection = direction;
        if (direction == RotationDirection.normal)
            deltaAngle = 5.0f;
        else
            deltaAngle = -5.0f;

        cubeAxis = axis;
        cubeSlices = slices;
    }

    public void DoAnimX(CubeSlices slices, RotationDirection direction)
    {
        DoAnim(CubeAxis.x, slices, direction);
    }


    public void DoAnimY(CubeSlices slices, RotationDirection direction)
    {
        DoAnim(CubeAxis.y, slices, direction);
    }


    public void DoAnimZ(CubeSlices slices, RotationDirection direction)
    {
        DoAnim(CubeAxis.z, slices, direction);
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

        GameObject t = mfCubelets[c0.x, c0.y, c0.z];
        mfCubelets[c0.x, c0.y, c0.z] = mfCubelets[c1.x, c1.y, c1.z];
        mfCubelets[c1.x, c1.y, c1.z] = mfCubelets[c2.x, c2.y, c2.z];
        mfCubelets[c2.x, c2.y, c2.z] = mfCubelets[c3.x, c3.y, c3.z];
        mfCubelets[c3.x, c3.y, c3.z] = t;
    }


    void Cycle4CubleletsR(Vector3Int c0, Vector3Int c1, Vector3Int c2, Vector3Int c3, RotationDirection direction)
    {
        if (direction == RotationDirection.reverse)
        {
            Cycle4Cublelets(c0, c1, c2, c3, RotationDirection.normal);
            return;
        }

        GameObject t = mfCubelets[c3.x, c3.y, c3.z];
        mfCubelets[c3.x, c3.y, c3.z] = mfCubelets[c2.x, c2.y, c2.z];
        mfCubelets[c2.x, c2.y, c2.z] = mfCubelets[c1.x, c1.y, c1.z];
        mfCubelets[c1.x, c1.y, c1.z] = mfCubelets[c0.x, c0.y, c0.z];
        mfCubelets[c0.x, c0.y, c0.z] = t;
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
