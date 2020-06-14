using UnityEngine;
using Rubix.Animation;
using Rubix.Data;


namespace Rubix.GUI
{ 
    // The full data for a Cubelet.
    // Includes the GameObject itself, and the Textures on each face.
    // This allows the Textures to be switched on / off easily.
    public class CubeletData
    {
        public GameObject cubelet;

        public Texture textureNumberUp;
        public Texture textureNumberDown;
        public Texture textureNumberLeft;
        public Texture textureNumberRight;
        public Texture textureNumberFront;
        public Texture textureNumberBack;
    }


    // The 5 x 5 x 5 Rubik's Cube.
    public class MyCube : MonoBehaviour
    {
        public GameObject cubeRoot;         // This "empty" GameObject is the parent of all the little Cubelets.
        public GameObject innerSphere;      // This is the "core" of the Cube.

        // Materials for each face.
        public Material faceMaterialBlue;
        public Material faceMaterialGreen;

        public Material faceMaterialYellow;
        public Material faceMaterialWhite;

        public Material faceMaterialRed;
        public Material faceMaterialOrange;

        public Material faceMaterialBlack;  // For the "innards".

        public Texture texturePlain;

        // Textures to be applied to each face.
        readonly Texture[,] _cubeFaceletTextures = new Texture[5, 5];
            // Loaded up from Resources

        TextureType _textureType = TextureType.number;

        //-------------------------------------------------
        //
        // Animation stuff...

        public bool isAnimating = false;

        CubeAxis _cubeAxis;                      // Which axis we are currently rotating about.
        CubeSlices _cubeSlices;                  // Which slices we are currently rotating.
        RotationDirection _rotationDirection;    // "normal" or "reverse" rotation.

        //-------------------------------------------------

        readonly CubeletData[,,] _cubeletData  = new CubeletData[5, 5, 5];
            // Pointers from the array indices to the current Cubelets.
            // As rotations are performed, these get shuffled around.

        readonly CubeletData[,,] _origCubeletData  = new CubeletData[5, 5, 5];
            // Pointers from the array indices to the original Cubelets.
            // As rotations are performed, these ones stay put.

        readonly TransformData[,,] _origTransformData = new TransformData[5, 5, 5];
            // A quick record of the original Cubelet positions by array indices.

        TransformData _origSphereTransformData = new TransformData();
            // A quick record of the original position of the inner "core".


        // Handy shared data...

        readonly int[] stdTriangles = new int[] { 0, 1, 2, 0, 2, 3 };

        readonly Vector2[] stdUV = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        readonly Vector3 vMMM = new  Vector3(-0.5f, -0.5f, -0.5f);
        readonly Vector3 vMMP = new  Vector3(-0.5f, -0.5f, 0.5f);
        readonly Vector3 vMPM = new  Vector3(-0.5f, 0.5f, -0.5f);
        readonly Vector3 vMPP = new  Vector3(-0.5f, 0.5f, 0.5f);
        readonly Vector3 vPMM = new  Vector3(0.5f, -0.5f, -0.5f);
        readonly Vector3 vPMP = new  Vector3(0.5f, -0.5f, 0.5f);
        readonly Vector3 vPPM = new  Vector3(0.5f, 0.5f, -0.5f);
        readonly Vector3 vPPP = new  Vector3(0.5f, 0.5f, 0.5f);


        // Load up the 25 textures to be used on the cubelet faces.
        void Awake()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    _cubeFaceletTextures[x, y] = Resources.Load<Texture>($"Textures/Facelet{x}{y}t");
                }
            }
        }


        // Create the Cubelets of the Cube,
        // and record the original copy and transforms for quick reset.
        void Start()
        {
            _origSphereTransformData = new TransformData(innerSphere.transform);

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (IsOuterCubelet(x, y, z))
                        {
                            CubeletData cData = CreateCubelet(x, y, z);
                            _cubeletData[x, y, z] = cData;

                            _origCubeletData[x, y, z] = cData;

                            // Copy the original configuration to allow quick reset.
                            _origTransformData[x, y, z] = new TransformData(cData.cubelet.transform);
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


        public void ScaleUp(float factor, float step, float min, float max)
        {
            GameObject go = gameObject;

            float ls = go.transform.localScale.x;

            ls = AnimationData.ClampWithStep(factor, min, max, ls, step);

            go.transform.localScale = new Vector3(ls, ls, ls);
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
                            rb = _cubeletData[x, y, z].cubelet.GetComponent<Rigidbody>();
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

            _origSphereTransformData.ApplyTo(innerSphere.transform);

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (IsOuterCubelet(x, y, z))
                        {
                            _cubeletData[x, y, z] = _origCubeletData[x, y, z];

                            _origTransformData[x, y, z].ApplyTo(_cubeletData[x, y, z].cubelet.transform);

                            rb = _cubeletData[x, y, z].cubelet.GetComponent<Rigidbody>();
                            rb.useGravity = false;
                            rb.isKinematic = true;
                        }
                    }
                }
            }

            isAnimating = false;
        }


        public void CycleTextures()
        {
            _textureType = AnimationData.CycleTextureType(_textureType);

            GameObject cubeletFaceUp, cubeletFaceDown, cubeletFaceFront, cubeletFaceBack, cubeletFaceLeft, cubeletFaceRight;
            Texture textureUp, textureDown, textureFront, textureBack, textureLeft, textureRight;

            if (_textureType == TextureType.plain)
            {
                textureUp = texturePlain;
                textureDown = texturePlain;
                textureFront = texturePlain;
                textureBack = texturePlain;
                textureLeft = texturePlain;
                textureRight = texturePlain;
            }
            else // if (_textureType == TextureType.none)
            {
                textureUp = null;
                textureDown = null;
                textureFront = null;
                textureBack = null;
                textureLeft = null;
                textureRight = null;
            }

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        if (IsOuterCubelet(x, y, z))
                        {
                            CubeletData cData = _cubeletData[x, y, z];

                            cubeletFaceUp = cData.cubelet.transform.GetChild(0).gameObject;
                            cubeletFaceDown = cData.cubelet.transform.GetChild(1).gameObject;
                            cubeletFaceFront = cData.cubelet.transform.GetChild(2).gameObject;
                            cubeletFaceBack = cData.cubelet.transform.GetChild(3).gameObject;
                            cubeletFaceLeft = cData.cubelet.transform.GetChild(4).gameObject;
                            cubeletFaceRight = cData.cubelet.transform.GetChild(5).gameObject;

                            if (_textureType == TextureType.number)
                            { 
                                textureUp = cData.textureNumberUp;
                                textureDown = cData.textureNumberDown;
                                textureFront = cData.textureNumberFront;
                                textureBack = cData.textureNumberBack;
                                textureLeft = cData.textureNumberLeft;
                                textureRight = cData.textureNumberRight;
                            }

                            cubeletFaceUp.GetComponent<MeshRenderer>().materials[0].mainTexture = textureUp;
                            cubeletFaceDown.GetComponent<MeshRenderer>().materials[0].mainTexture = textureDown;
                            cubeletFaceFront.GetComponent<MeshRenderer>().materials[0].mainTexture = textureFront;
                            cubeletFaceBack.GetComponent<MeshRenderer>().materials[0].mainTexture = textureBack;
                            cubeletFaceLeft.GetComponent<MeshRenderer>().materials[0].mainTexture = textureLeft;
                            cubeletFaceRight.GetComponent<MeshRenderer>().materials[0].mainTexture = textureRight;
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

            CubeletData cData = new CubeletData();

            GameObject cubelet = new GameObject(codeName);

            cData.cubelet = cubelet;

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

            MeshFilter mfTop = cubeletTop.AddComponent<MeshFilter>();
            MeshFilter mfBottom = cubeletBottom.AddComponent<MeshFilter>();
            MeshFilter mfFront = cubeletFront.AddComponent<MeshFilter>();
            MeshFilter mfBack = cubeletBack.AddComponent<MeshFilter>();
            MeshFilter mfLeft = cubeletLeft.AddComponent<MeshFilter>();
            MeshFilter mfRight = cubeletRight.AddComponent<MeshFilter>();

            MeshRenderer mrTop = cubeletTop.AddComponent<MeshRenderer>();
            MeshRenderer mrBottom = cubeletBottom.AddComponent<MeshRenderer>();
            MeshRenderer mrFront = cubeletFront.AddComponent<MeshRenderer>();
            MeshRenderer mrBack = cubeletBack.AddComponent<MeshRenderer>();
            MeshRenderer mrLeft = cubeletLeft.AddComponent<MeshRenderer>();
            MeshRenderer mrRight = cubeletRight.AddComponent<MeshRenderer>();

            if (y == 4)
            {
                mrTop.material = faceMaterialBlue;
                mrTop.materials[0].mainTexture = _cubeFaceletTextures[x, z];
            }
            else
            {
                mrTop.material = faceMaterialBlack;
            }

            if (y == 0)
            {
                mrBottom.material = faceMaterialGreen;
                mrBottom.materials[0].mainTexture = _cubeFaceletTextures[x, 4 - z];
            }
            else
            {
                mrBottom.material = faceMaterialBlack;
            }

            if (z == 0)
            {
                mrFront.material = faceMaterialYellow;
                mrFront.materials[0].mainTexture = _cubeFaceletTextures[x, y];

            }
            else
            {
                mrFront.material = faceMaterialBlack;
            }

            if (z == 4)
            {
                mrBack.material = faceMaterialWhite;
                mrBack.materials[0].mainTexture = _cubeFaceletTextures[4 - x, y];   // NOTE: On map, the FacePanel is thereby rotated 180 degrees.
            }
            else
            {
                mrBack.material = faceMaterialBlack;
            }

            if (x == 0)
            {
                mrLeft.material = faceMaterialRed;
                mrLeft.materials[0].mainTexture = _cubeFaceletTextures[4 - z, y];
            }
            else
            {
                mrLeft.material = faceMaterialBlack;
            }

            if (x == 4)
            {
                mrRight.material = faceMaterialOrange;
                mrRight.materials[0].mainTexture = _cubeFaceletTextures[z, y];  // OK!
            }
            else
            {
                mrRight.material = faceMaterialBlack;
            }

            cData.textureNumberBack = mrBack.materials[0].mainTexture;
            cData.textureNumberFront = mrFront.materials[0].mainTexture;
            cData.textureNumberLeft = mrLeft.materials[0].mainTexture;
            cData.textureNumberRight = mrRight.materials[0].mainTexture;
            cData.textureNumberUp = mrTop.materials[0].mainTexture;
            cData.textureNumberDown = mrBottom.materials[0].mainTexture;


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

            return cData;
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
            _cubeAxis = animationSpecification.cubeAxis;
            _cubeSlices = animationSpecification.cubeSlices;
            _rotationDirection = animationSpecification.rotationDirection;

            isAnimating = true;
        }


        // Perform a step in the animation.
        // Advance the rotation of the active slices on the active axis in the active direction by delta angle.
        // NOTE: We don't touch the "internal" cubelets - they are not represented.
        // NOTE: The finishing step is done separately...
        public void DoAnimation(float deltaAngle)
        {
            switch (_cubeAxis)
            {
                case CubeAxis.x:

                    for (int y = 0; y < 5; y++)
                    {
                        for (int z = 0; z < 5; z++)
                        {
                            if (_cubeSlices == CubeSlices.s0 || _cubeSlices == CubeSlices.s01 || _cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(_cubeletData[0, y, z].cubelet, deltaAngle);

                            if (IsOuterCubelet(y, z))
                            {
                                if (_cubeSlices == CubeSlices.s1 || _cubeSlices == CubeSlices.s01 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutXAxis(_cubeletData[1, y, z].cubelet, deltaAngle);

                                if (_cubeSlices == CubeSlices.s2 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutXAxis(_cubeletData[2, y, z].cubelet, deltaAngle);

                                if (_cubeSlices == CubeSlices.s3 || _cubeSlices == CubeSlices.s34 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutXAxis(_cubeletData[3, y, z].cubelet, deltaAngle);
                            }

                            if (_cubeSlices == CubeSlices.s4 || _cubeSlices == CubeSlices.s34 || _cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutXAxis(_cubeletData[4, y, z].cubelet, deltaAngle);
                        }
                    }
                    break;

                case CubeAxis.y:

                    for (int x = 0; x < 5; x++)
                    {
                        for (int z = 0; z < 5; z++)
                        {
                            if (_cubeSlices == CubeSlices.s0 || _cubeSlices == CubeSlices.s01 || _cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(_cubeletData[x, 0, z].cubelet, deltaAngle);

                            if (IsOuterCubelet(x, z))
                            {
                                if (_cubeSlices == CubeSlices.s1 || _cubeSlices == CubeSlices.s01 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutYAxis(_cubeletData[x, 1, z].cubelet, deltaAngle);

                                if (_cubeSlices == CubeSlices.s2 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutYAxis(_cubeletData[x, 2, z].cubelet, deltaAngle);

                                if (_cubeSlices == CubeSlices.s3 || _cubeSlices == CubeSlices.s34 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutYAxis(_cubeletData[x, 3, z].cubelet, deltaAngle);
                            }

                            if (_cubeSlices == CubeSlices.s4 || _cubeSlices == CubeSlices.s34 || _cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutYAxis(_cubeletData[x, 4, z].cubelet, deltaAngle);
                        }
                    }
                    break;

                case CubeAxis.z:

                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (_cubeSlices == CubeSlices.s0 || _cubeSlices == CubeSlices.s01 || _cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(_cubeletData[x, y, 0].cubelet, deltaAngle);

                            if (IsOuterCubelet(x, y))
                            {
                                if (_cubeSlices == CubeSlices.s1 || _cubeSlices == CubeSlices.s01 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutZAxis(_cubeletData[x, y, 1].cubelet, deltaAngle);

                                if (_cubeSlices == CubeSlices.s2 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutZAxis(_cubeletData[x, y, 2].cubelet, deltaAngle);

                                if (_cubeSlices == CubeSlices.s3 || _cubeSlices == CubeSlices.s34 || _cubeSlices == CubeSlices.s01234)
                                    RotateCubeletAboutZAxis(_cubeletData[x, y, 3].cubelet, deltaAngle);
                            }

                            if (_cubeSlices == CubeSlices.s4 || _cubeSlices == CubeSlices.s34 || _cubeSlices == CubeSlices.s01234)
                                RotateCubeletAboutZAxis(_cubeletData[x, y, 4].cubelet, deltaAngle);
                        }
                    }
                    break;
            }
        }


        // The controller tells us to finish the current animation.
        // Adjust the actual arrangement of Cubelets in the 3D array.
        public void FinishAnimation()
        {
            switch (_cubeAxis)
            {
                case CubeAxis.x:

                    RotateCubeletArrayAboutXAxis(_cubeSlices, _rotationDirection);
                    break;

                case CubeAxis.y:

                    RotateCubeletArrayAboutYAxis(_cubeSlices, _rotationDirection);
                    break;

                case CubeAxis.z:

                    RotateCubeletArrayAboutZAxis(_cubeSlices, _rotationDirection);
                    break;

            }

            isAnimating = false;    // DONE!
        }


        //-----------------------------------------------------
        //-----------------------------------------------------


        void RotateCubeletArrayAboutXAxis(CubeSlices cubeSlicesIn, RotationDirection direction)
        {
            if (cubeSlicesIn == CubeSlices.s0 || cubeSlicesIn == CubeSlices.s01 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutXAxisSlice(0, direction);
            if (cubeSlicesIn == CubeSlices.s1 || cubeSlicesIn == CubeSlices.s01 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutXAxisSlice(1, direction);

            if (cubeSlicesIn == CubeSlices.s2 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutXAxisSlice(2, direction);

            if (cubeSlicesIn == CubeSlices.s3 || cubeSlicesIn == CubeSlices.s34 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutXAxisSlice(3, direction);
            if (cubeSlicesIn == CubeSlices.s4 || cubeSlicesIn == CubeSlices.s34 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutXAxisSlice(4, direction);
        }


        void RotateCubeletArrayAboutYAxis(CubeSlices cubeSlicesIn, RotationDirection direction)
        {
            if (cubeSlicesIn == CubeSlices.s0 || cubeSlicesIn == CubeSlices.s01 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutYAxisSlice(0, direction);
            if (cubeSlicesIn == CubeSlices.s1 || cubeSlicesIn == CubeSlices.s01 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutYAxisSlice(1, direction);

            if (cubeSlicesIn == CubeSlices.s2 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutYAxisSlice(2, direction);

            if (cubeSlicesIn == CubeSlices.s3 || cubeSlicesIn == CubeSlices.s34 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutYAxisSlice(3, direction);
            if (cubeSlicesIn == CubeSlices.s4 || cubeSlicesIn == CubeSlices.s34 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutYAxisSlice(4, direction);
        }


        void RotateCubeletArrayAboutZAxis(CubeSlices cubeSlicesIn, RotationDirection direction)
        {
            if (cubeSlicesIn == CubeSlices.s0 || cubeSlicesIn == CubeSlices.s01 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutZAxisSlice(0, direction);
            if (cubeSlicesIn == CubeSlices.s1 || cubeSlicesIn == CubeSlices.s01 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutZAxisSlice(1, direction);

            if (cubeSlicesIn == CubeSlices.s2 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutZAxisSlice(2, direction);

            if (cubeSlicesIn == CubeSlices.s3 || cubeSlicesIn == CubeSlices.s34 || cubeSlicesIn == CubeSlices.s01234)
                RotateCubeletArrayAboutZAxisSlice(3, direction);
            if (cubeSlicesIn == CubeSlices.s4 || cubeSlicesIn == CubeSlices.s34 || cubeSlicesIn == CubeSlices.s01234)
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
            Cycle4Cublelets(new Vector3Int(0, ySlice, 0), new Vector3Int(4, ySlice, 0), new Vector3Int(4, ySlice, 4), new Vector3Int(0, ySlice, 4), direction);
            Cycle4Cublelets(new Vector3Int(0, ySlice, 1), new Vector3Int(3, ySlice, 0), new Vector3Int(4, ySlice, 3), new Vector3Int(1, ySlice, 4), direction);
            Cycle4Cublelets(new Vector3Int(0, ySlice, 2), new Vector3Int(2, ySlice, 0), new Vector3Int(4, ySlice, 2), new Vector3Int(2, ySlice, 4), direction);
            Cycle4Cublelets(new Vector3Int(0, ySlice, 3), new Vector3Int(1, ySlice, 0), new Vector3Int(4, ySlice, 1), new Vector3Int(3, ySlice, 4), direction);

            if (ySlice == 0 || ySlice == 4)
            {
                Cycle4Cublelets(new Vector3Int(1, ySlice, 1), new Vector3Int(3, ySlice, 1), new Vector3Int(3, ySlice, 3), new Vector3Int(1, ySlice, 3), direction);
                Cycle4Cublelets(new Vector3Int(1, ySlice, 2), new Vector3Int(2, ySlice, 1), new Vector3Int(3, ySlice, 2), new Vector3Int(2, ySlice, 3), direction);
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


        // Cycle the cubelets in the array.

        void Cycle4Cublelets(Vector3Int c0, Vector3Int c1, Vector3Int c2, Vector3Int c3, RotationDirection direction)
        {
            if (direction == RotationDirection.reverse)
            {
                Cycle4CubleletsReverse(c0, c1, c2, c3, RotationDirection.normal);
                return;
            }

            CubeletData cd = _cubeletData[c0.x, c0.y, c0.z];
            _cubeletData[c0.x, c0.y, c0.z] = _cubeletData[c1.x, c1.y, c1.z];
            _cubeletData[c1.x, c1.y, c1.z] = _cubeletData[c2.x, c2.y, c2.z];
            _cubeletData[c2.x, c2.y, c2.z] = _cubeletData[c3.x, c3.y, c3.z];
            _cubeletData[c3.x, c3.y, c3.z] = cd;
        }


        void Cycle4CubleletsReverse(Vector3Int c0, Vector3Int c1, Vector3Int c2, Vector3Int c3, RotationDirection direction)
        {
            if (direction == RotationDirection.reverse)
            {
                Cycle4Cublelets(c0, c1, c2, c3, RotationDirection.normal);
                return;
            }

            CubeletData cd = _cubeletData[c3.x, c3.y, c3.z];
            _cubeletData[c3.x, c3.y, c3.z] = _cubeletData[c2.x, c2.y, c2.z];
            _cubeletData[c2.x, c2.y, c2.z] = _cubeletData[c1.x, c1.y, c1.z];
            _cubeletData[c1.x, c1.y, c1.z] = _cubeletData[c0.x, c0.y, c0.z];
            _cubeletData[c0.x, c0.y, c0.z] = cd;
        }


        // Rotate the cubelet in space.

        void RotateCubeletAboutXAxis(GameObject cubelet, float angle)
        {
            cubelet.transform.RotateAround(Vector3.zero, Vector3.right, angle);
        }


        void RotateCubeletAboutYAxis(GameObject cubelet, float angle)
        {
            cubelet.transform.RotateAround(Vector3.zero, Vector3.up, angle);
        }


        void RotateCubeletAboutZAxis(GameObject cubelet, float angle)
        {
            cubelet.transform.RotateAround(Vector3.zero, Vector3.forward, angle);
        }
    }
}
