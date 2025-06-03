using UnityEngine;
using UnityEngine.UI;
using Rubix.Data;


namespace Rubix.UI
{ 
    public class FaceMapPanel : DragWindow
    {
        // The panels for each face in this map.
        // Initialised in Unity IDE.
        public FacePanel frontPanel;
        public FacePanel backPanel;
        public FacePanel leftPanel;
        public FacePanel rightPanel;
        public FacePanel upPanel;
        public FacePanel downPanel;

        public Sprite spritePlain;

        // Sprites for use by the face panels.
        // Initialised in code.
        public Sprite [,] faceSprites;
        public Sprite [,] faceSpritesInverted;


        //-------------------------------------------------
        //
        // Animation stuff...
        public bool isAnimating;
        
        public RotationDirection rotationDirection;
        public CubeAxis cubeAxis;       // Which axis we are currently rotating about.
        public CubeSlices cubeSlices;   // Which slices we are currently rotating.

        //-------------------------------------------------

        TextureType _textureType = TextureType.number;


        // Load up the sprites for the 6 Face panels to use.
        void Awake()
        {
            faceSprites = new Sprite[5, 5];
            faceSpritesInverted = new Sprite[5, 5];

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    string codeNumber = string.Format("{0}{1}", x, y);

                    faceSprites[x,y] = Resources.Load<Sprite>("Sprites/Facelet" + codeNumber);
                    faceSpritesInverted[x, y] = InvertSprite(faceSprites[x, y]);
                }
            }
        }


        public void CycleMapTextures()
        {
            _textureType = AnimationData.CycleTextureType(_textureType);

            frontPanel.SetTexture(_textureType);
            backPanel.SetTexture(_textureType);
            leftPanel.SetTexture(_textureType);
            rightPanel.SetTexture(_textureType);
            upPanel.SetTexture(_textureType);
            downPanel.SetTexture(_textureType);
        }


        // Reset all the face panels in this map.
        public void ResetMap()
        {
            frontPanel.ResetFace(_textureType);
            backPanel.ResetFace(_textureType);
            leftPanel.ResetFace(_textureType);
            rightPanel.ResetFace(_textureType);
            upPanel.ResetFace(_textureType);
            downPanel.ResetFace(_textureType);

            isAnimating = false;
        }


        Sprite InvertSprite(Sprite originalSprite)
        {
            Texture2D originalTexture = originalSprite.texture;

            int width = originalTexture.width;
            int height = originalTexture.height;

            Texture2D invertedTexture = new Texture2D(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    invertedTexture.SetPixel(width - x - 1, height - y - 1, originalTexture.GetPixel(x, y));
                }
            }
            invertedTexture.Apply();

            Sprite invertedSprite = Sprite.Create(invertedTexture, new Rect(0, 0, width, height), Vector2.zero);
                // >>> Set ALL the parameters like the uninverted ones...

            return invertedSprite;
        }


        public void SpecifyMapAnimation(AnimationSpecification animationSpecification)
        {
            cubeAxis = animationSpecification.cubeAxis;
            cubeSlices = animationSpecification.cubeSlices;
            rotationDirection = animationSpecification.rotationDirection;

            isAnimating = true;
        }


        public void DoMapAnimation(float angleStep, bool doStep)
        {
            // X axis

            // All slices from left to right.
            if (cubeAxis == CubeAxis.x)
            {
                if (cubeSlices == CubeSlices.s01234)
                {
                    leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    leftPanel.transform.SetAsLastSibling();
                    rightPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromRight(0, rotationDirection);
                        CycleMapSliceFromRight(1, rotationDirection);
                        CycleMapSliceFromRight(2, rotationDirection);
                        CycleMapSliceFromRight(3, rotationDirection);
                        CycleMapSliceFromRight(4, rotationDirection);
                    }
                }

                // First slice from right.
                if (cubeSlices == CubeSlices.s4)
                {
                    rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    rightPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromRight(0, rotationDirection);
                    }
                }

                // First and second slice from right.
                if (cubeSlices == CubeSlices.s34)
                {
                    rightPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    rightPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromRight(0, rotationDirection);
                        CycleMapSliceFromRight(1, rotationDirection);
                    }
                }

                // Second slice from right.
                if (cubeSlices == CubeSlices.s3)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromRight(1, rotationDirection);
                    }
                }

                // Third (middle) slice from right.
                if (cubeSlices == CubeSlices.s2)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromRight(2, rotationDirection);
                    }
                }

                // Fourth slice from right.
                if (cubeSlices == CubeSlices.s1)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromRight(3, rotationDirection);
                    }
                }

                // Fourth and fifth slice from right.
                if (cubeSlices == CubeSlices.s01)
                {
                    leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    leftPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromRight(3, rotationDirection);
                        CycleMapSliceFromRight(4, rotationDirection);
                    }
                }

                // Fifth slice from right.
                if (cubeSlices == CubeSlices.s0)
                {
                    leftPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    leftPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromRight(4, rotationDirection);
                    }
                }
            }

            // Y axis

            // All slices from top to bottom.
            if (cubeAxis == CubeAxis.y)
            { 
                if (cubeSlices == CubeSlices.s01234)
                {
                    downPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    downPanel.transform.SetAsLastSibling();
                    upPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromTop(0, rotationDirection);
                        CycleMapSliceFromTop(1, rotationDirection);
                        CycleMapSliceFromTop(2, rotationDirection);
                        CycleMapSliceFromTop(3, rotationDirection);
                        CycleMapSliceFromTop(4, rotationDirection);
                    }
                }

                // First slice from top.
                if (cubeSlices == CubeSlices.s4)
                {
                    upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    upPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromTop(0, rotationDirection);
                    }
                }

                // First two slices from top.
                if (cubeSlices == CubeSlices.s34)
                {
                    upPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    upPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromTop(0, rotationDirection);
                        CycleMapSliceFromTop(1, rotationDirection);
                    }
                }

                // Second slice from top.
                if (cubeSlices == CubeSlices.s3)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromTop(1, rotationDirection);
                    }
                }

                // Third slice from top.
                if (cubeSlices == CubeSlices.s2)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromTop(2, rotationDirection);
                    }
                }

                // Fourth slice from top.
                if (cubeSlices == CubeSlices.s1)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromTop(3, rotationDirection);
                    }
                }

                // Fourth and Fifth slices from top.
                if (cubeSlices == CubeSlices.s01)
                {
                    downPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    downPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromTop(3, rotationDirection);
                        CycleMapSliceFromTop(4, rotationDirection);
                    }
                }

                // Fifth slice from top.
                if (cubeSlices == CubeSlices.s0)
                {
                    downPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    downPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromTop(4, rotationDirection);
                    }
                }
            }

            // Z axis

            // All slices from front to back.
            if (cubeAxis == CubeAxis.z)
            { 
                if (cubeSlices == CubeSlices.s01234)
                {
                    backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    backPanel.transform.SetAsLastSibling();
                    frontPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromFront(0, rotationDirection);
                        CycleMapSliceFromFront(1, rotationDirection);
                        CycleMapSliceFromFront(2, rotationDirection);
                        CycleMapSliceFromFront(3, rotationDirection);
                        CycleMapSliceFromFront(4, rotationDirection);
                    }
                }

                // First slice from front.
                if (cubeSlices == CubeSlices.s0)
                {
                    frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    frontPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromFront(0, rotationDirection);
                    }
                }

                // First and second slice from front.
                if (cubeSlices == CubeSlices.s01)
                {
                    frontPanel.transform.Rotate(0.0f, 0.0f, angleStep);
                    frontPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromFront(0, rotationDirection);
                        CycleMapSliceFromFront(1, rotationDirection);
                    }
                }

                // Second slice from front.
                if (cubeSlices == CubeSlices.s1)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromFront(1, rotationDirection);
                    }
                }

                // Third slice from front.
                if (cubeSlices == CubeSlices.s2)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromFront(2, rotationDirection);
                    }
                }

                // Fourth slice from front.
                if (cubeSlices == CubeSlices.s3)
                {
                    if (doStep)
                    {
                        CycleMapSliceFromFront(3, rotationDirection);
                    }
                }

                // Fourth and fifth slice from front.
                if (cubeSlices == CubeSlices.s34)
                {
                    backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    backPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromFront(3, rotationDirection);
                        CycleMapSliceFromFront(4, rotationDirection);
                    }
                }

                // Fifth slice from front.
                if (cubeSlices == CubeSlices.s4)
                {
                    backPanel.transform.Rotate(0.0f, 0.0f, -angleStep);
                    backPanel.transform.SetAsLastSibling();

                    if (doStep)
                    {
                        CycleMapSliceFromFront(4, rotationDirection);
                    }
                }
            }
        }

        // Perform the rotation on the facelet level,
        // and reset the panel rotation back to zero.
        // NOTE: If outer faces are not moved, there is nothing to do,
        //       because all the "steps" (5) have happened.
        public void FinishMapAnimation()
        {
            // X axis --------------------------------------

            // Slices from right to left.
            if (cubeAxis == CubeAxis.x)
            { 
                // First slice from right.
                if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                {
                    RotateMapFaceCW90(rightPanel, rotationDirection);
                    rightPanel.transform.localEulerAngles = Vector3.zero;
                }

                // Fifth slice from right.
                if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                {
                    RotateMapFaceACW90(leftPanel, rotationDirection);
                    leftPanel.transform.localEulerAngles = Vector3.zero;
                }
            }

            // Y axis --------------------------------------

            // Slices from top to bottom.
            if (cubeAxis == CubeAxis.y)
            { 
                // First slice from top.
                if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                {
                    RotateMapFaceCW90(upPanel, rotationDirection);
                    upPanel.transform.localEulerAngles = Vector3.zero;
                }

                // Last slice from top.
                if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                {
                    RotateMapFaceACW90(downPanel, rotationDirection);
                    downPanel.transform.localEulerAngles = Vector3.zero;
                }
            }

            // Z axis --------------------------------------

            // Slices from front to back.
            if (cubeAxis == CubeAxis.z)
            {
                // First slice from front.
                if (cubeSlices == CubeSlices.s0 || cubeSlices == CubeSlices.s01 || cubeSlices == CubeSlices.s01234)
                {
                    RotateMapFaceACW90(frontPanel, rotationDirection);
                    frontPanel.transform.localEulerAngles = Vector3.zero;
                }

                // Last slice from front.
                if (cubeSlices == CubeSlices.s4 || cubeSlices == CubeSlices.s34 || cubeSlices == CubeSlices.s01234)
                {
                    RotateMapFaceCW90(backPanel, rotationDirection);
                    backPanel.transform.localEulerAngles = Vector3.zero;
                }
            }

            isAnimating = false;
        }

        //----------------------------------------------------

        // X axis

        // nSlice = 0 is Right. nSlice = 4 is Left.
        public void CycleMapSliceFromRight(int nSlice, RotationDirection rotationDirection)
        {
            FaceletData[] a = new FaceletData[20];

            a[0] = frontPanel.faceletData[4 - nSlice, 0];
            a[1] = frontPanel.faceletData[4 - nSlice, 1];
            a[2] = frontPanel.faceletData[4 - nSlice, 2];
            a[3] = frontPanel.faceletData[4 - nSlice, 3];
            a[4] = frontPanel.faceletData[4 - nSlice, 4];

            a[5] = upPanel.faceletData[4 - nSlice, 0];
            a[6] = upPanel.faceletData[4 - nSlice, 1];
            a[7] = upPanel.faceletData[4 - nSlice, 2];
            a[8] = upPanel.faceletData[4 - nSlice, 3];
            a[9] = upPanel.faceletData[4 - nSlice, 4];

            a[10] = backPanel.faceletData[4 - nSlice, 0];
            a[11] = backPanel.faceletData[4 - nSlice, 1];
            a[12] = backPanel.faceletData[4 - nSlice, 2];
            a[13] = backPanel.faceletData[4 - nSlice, 3];
            a[14] = backPanel.faceletData[4 - nSlice, 4];

            a[15] = downPanel.faceletData[4 - nSlice, 0];
            a[16] = downPanel.faceletData[4 - nSlice, 1];
            a[17] = downPanel.faceletData[4 - nSlice, 2];
            a[18] = downPanel.faceletData[4 - nSlice, 3];
            a[19] = downPanel.faceletData[4 - nSlice, 4];

            if (rotationDirection == RotationDirection.normal)
                CycleFacelets20A(a);
            else
                CycleFacelets20(a);
        }

        // Y axis

        // nSlice = 0 is Top. nSlice = 4 is Bottom.
        public void CycleMapSliceFromTop(int nSlice, RotationDirection rotationDirection)
        {
            FaceletData[] a = new FaceletData[20];    // An array of the little "facelet" panels.

            a[0] = frontPanel.faceletData[0, 4 - nSlice];
            a[1] = frontPanel.faceletData[1, 4 - nSlice];
            a[2] = frontPanel.faceletData[2, 4 - nSlice];
            a[3] = frontPanel.faceletData[3, 4 - nSlice];
            a[4] = frontPanel.faceletData[4, 4 - nSlice];

            a[5] = rightPanel.faceletData[0, 4 - nSlice];
            a[6] = rightPanel.faceletData[1, 4 - nSlice];
            a[7] = rightPanel.faceletData[2, 4 - nSlice];
            a[8] = rightPanel.faceletData[3, 4 - nSlice];
            a[9] = rightPanel.faceletData[4, 4 - nSlice];

            a[10] = backPanel.faceletData[4, nSlice];
            a[11] = backPanel.faceletData[3, nSlice];
            a[12] = backPanel.faceletData[2, nSlice];
            a[13] = backPanel.faceletData[1, nSlice];
            a[14] = backPanel.faceletData[0, nSlice];

            a[15] = leftPanel.faceletData[0, 4 - nSlice];
            a[16] = leftPanel.faceletData[1, 4 - nSlice];
            a[17] = leftPanel.faceletData[2, 4 - nSlice];
            a[18] = leftPanel.faceletData[3, 4 - nSlice];
            a[19] = leftPanel.faceletData[4, 4 - nSlice];

            if (rotationDirection == RotationDirection.normal)
            {
                a[10].facelet.transform.Rotate(0.0f, 0.0f, 180.0f);
                a[15].facelet.transform.Rotate(0.0f, 0.0f, 180.0f);

                CycleFacelets20(a);
            }
            else
            { 
                a[14].facelet.transform.Rotate(0.0f, 0.0f, 180.0f);
                a[9].facelet.transform.Rotate(0.0f, 0.0f, 180.0f);

                CycleFacelets20A(a);
            }
        }

        // Z axis

        // nSlice = 0 is Front. nSlice = 4 is Back.
        public void CycleMapSliceFromFront(int nSlice, RotationDirection direction)
        {
            FaceletData[] a = new FaceletData[20];

            a[0] = downPanel.faceletData[0, 4 - nSlice];
            a[1] = downPanel.faceletData[1, 4 - nSlice];
            a[2] = downPanel.faceletData[2, 4 - nSlice];
            a[3] = downPanel.faceletData[3, 4 - nSlice];
            a[4] = downPanel.faceletData[4, 4 - nSlice];

            a[5] = rightPanel.faceletData[nSlice, 0];
            a[6] = rightPanel.faceletData[nSlice, 1];
            a[7] = rightPanel.faceletData[nSlice, 2];
            a[8] = rightPanel.faceletData[nSlice, 3];
            a[9] = rightPanel.faceletData[nSlice, 4];

            a[10] = upPanel.faceletData[4, nSlice];
            a[11] = upPanel.faceletData[3, nSlice];
            a[12] = upPanel.faceletData[2, nSlice];
            a[13] = upPanel.faceletData[1, nSlice];
            a[14] = upPanel.faceletData[0, nSlice];

            a[15] = leftPanel.faceletData[4 - nSlice, 4];
            a[16] = leftPanel.faceletData[4 - nSlice, 3];
            a[17] = leftPanel.faceletData[4 - nSlice, 2];
            a[18] = leftPanel.faceletData[4 - nSlice, 1];
            a[19] = leftPanel.faceletData[4 - nSlice, 0];

            if (direction == RotationDirection.normal)
            { 
                a[4].facelet.transform.Rotate(0.0f, 0.0f, 90.0f);
                a[9].facelet.transform.Rotate(0.0f, 0.0f, 90.0f);
                a[14].facelet.transform.Rotate(0.0f, 0.0f, 90.0f);
                a[19].facelet.transform.Rotate(0.0f, 0.0f, 90.0f);

                CycleFacelets20A(a);
            }
            else
            { 
                a[0].facelet.transform.Rotate(0.0f, 0.0f, -90.0f);
                a[5].facelet.transform.Rotate(0.0f, 0.0f, -90.0f);
                a[10].facelet.transform.Rotate(0.0f, 0.0f, -90.0f);
                a[15].facelet.transform.Rotate(0.0f, 0.0f, -90.0f);

                CycleFacelets20(a);
            }
        }


        public void RotateMapFaceCW90(FacePanel face, RotationDirection direction)
        {
            if (direction == RotationDirection.reverse)
            {
                RotateMapFaceACW90(face, RotationDirection.normal);
                return;
            }

            FaceletData[] a = new FaceletData[4];

            // The outer edge.

            a[0] = face.faceletData[0, 0];
            a[1] = face.faceletData[4, 0];
            a[2] = face.faceletData[4, 4];
            a[3] = face.faceletData[0, 4];
            CycleFacelets4(a);

            a[0] = face.faceletData[1, 0];
            a[1] = face.faceletData[4, 1];
            a[2] = face.faceletData[3, 4];
            a[3] = face.faceletData[0, 3];
            CycleFacelets4(a);

            a[0] = face.faceletData[2, 0];
            a[1] = face.faceletData[4, 2];
            a[2] = face.faceletData[2, 4];
            a[3] = face.faceletData[0, 2];
            CycleFacelets4(a);

            a[0] = face.faceletData[3, 0];
            a[1] = face.faceletData[4, 3];
            a[2] = face.faceletData[1, 4];
            a[3] = face.faceletData[0, 1];
            CycleFacelets4(a);

            // The inner square

            a[0] = face.faceletData[1, 1];
            a[1] = face.faceletData[3, 1];
            a[2] = face.faceletData[3, 3];
            a[3] = face.faceletData[1, 3];
            CycleFacelets4(a);

            a[0] = face.faceletData[2, 1];
            a[1] = face.faceletData[3, 2];
            a[2] = face.faceletData[2, 3];
            a[3] = face.faceletData[1, 2];
            CycleFacelets4(a);

            // Now, rotate the facelets about their centres.
        
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    face.faceletData[x,y].facelet.transform.Rotate(0.0f, 0.0f, -90.0f);
                }
            }
        }


        public void RotateMapFaceACW90(FacePanel face, RotationDirection direction)
        {
            if (direction == RotationDirection.reverse)
            {
                RotateMapFaceCW90(face, RotationDirection.normal);
                return;
            }

            FaceletData[] a = new FaceletData[4];

            // The outer edge.

            a[0] = face.faceletData[0, 0];
            a[1] = face.faceletData[4, 0];
            a[2] = face.faceletData[4, 4];
            a[3] = face.faceletData[0, 4];
            CycleFacelets4A(a);

            a[0] = face.faceletData[1, 0];
            a[1] = face.faceletData[4, 1];
            a[2] = face.faceletData[3, 4];
            a[3] = face.faceletData[0, 3];
            CycleFacelets4A(a);

            a[0] = face.faceletData[2, 0];
            a[1] = face.faceletData[4, 2];
            a[2] = face.faceletData[2, 4];
            a[3] = face.faceletData[0, 2];
            CycleFacelets4A(a);

            a[0] = face.faceletData[3, 0];
            a[1] = face.faceletData[4, 3];
            a[2] = face.faceletData[1, 4];
            a[3] = face.faceletData[0, 1];
            CycleFacelets4A(a);

            // The inner square

            a[0] = face.faceletData[1, 1];
            a[1] = face.faceletData[3, 1];
            a[2] = face.faceletData[3, 3];
            a[3] = face.faceletData[1, 3];
            CycleFacelets4A(a);

            a[0] = face.faceletData[2, 1];
            a[1] = face.faceletData[3, 2];
            a[2] = face.faceletData[2, 3];
            a[3] = face.faceletData[1, 2];
            CycleFacelets4A(a);

            // Now, rotate the facelets about their centres.
        
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    face.faceletData[x, y].facelet.transform.Rotate(0.0f, 0.0f, 90.0f);
                }
            }
        }


        // Low level facelet cycling code...

        public void CycleFacelets4(FaceletData[] fd)
        {
            Image[] imgs = new Image[4];

            for (int i = 0; i < 4; i++)
            {
                imgs[i] = fd[i].facelet.GetComponent<Image>();
            }

            Color c0 = imgs[0].color;
            Sprite s0 = imgs[0].sprite;
            TransformData t0 = new TransformData(fd[0].facelet.transform);
            Sprite n0 = fd[0].spriteNumber;

            for (int i = 0; i < 3; i++)
            {
                imgs[i].color = imgs[i + 1].color;
                imgs[i].sprite = imgs[i + 1].sprite;
                TransformData t = new TransformData(fd[i + 1].facelet.transform);
                t.ApplyRotation(fd[i].facelet.transform);
                fd[i].spriteNumber = fd[i + 1].spriteNumber;

            }
            imgs[3].color = c0;
            imgs[3].sprite = s0;
            t0.ApplyRotation(fd[3].facelet.transform);
            fd[3].spriteNumber = n0;
        }


        public void CycleFacelets4A(FaceletData[] fd)
        {
            Image[] imgs = new Image[4];

            for (int i = 0; i < 4; i++)
            {
                imgs[i] = fd[i].facelet.GetComponent<Image>();
            }

            Color c3 = imgs[3].color;
            Sprite s3 = imgs[3].sprite;
            TransformData t3 = new TransformData(fd[3].facelet.transform);
            Sprite n3 = fd[3].spriteNumber;

            for (int i = 2; i >= 0; i--)
            {
                imgs[i + 1].color = imgs[i].color;
                imgs[i + 1].sprite = imgs[i].sprite;
                TransformData t = new TransformData(fd[i].facelet.transform);
                t.ApplyRotation(fd[i + 1].facelet.transform);
                fd[i + 1].spriteNumber = fd[i].spriteNumber;
            }
            imgs[0].color = c3;
            imgs[0].sprite = s3;
            t3.ApplyRotation(fd[0].facelet.transform);
            fd[0].spriteNumber = n3;
        }


        public void CycleFacelets20(FaceletData[] fd)
        {
            Image[] imgs = new Image[20];

            for (int i = 0; i < 20; i++)
            {
                imgs[i] = fd[i].facelet.GetComponent<Image>();
            }

            Color c0 = imgs[0].color;
            Sprite s0 = imgs[0].sprite;
            TransformData t0 = new TransformData(fd[0].facelet.transform);
            Sprite n0 = fd[0].spriteNumber;

            for (int i = 0; i < 19; i++)
            {
                imgs[i].color = imgs[i + 1].color;
                imgs[i].sprite = imgs[i + 1].sprite;
                TransformData t = new TransformData(fd[i + 1].facelet.transform);
                t.ApplyRotation(fd[i].facelet.transform);
                fd[i].spriteNumber = fd[i + 1].spriteNumber;
            }
            imgs[19].color = c0;
            imgs[19].sprite = s0;
            t0.ApplyRotation(fd[19].facelet.transform);
            fd[19].spriteNumber = n0;
        }


        public void CycleFacelets20A(FaceletData[] fd)
        {
            Image[] imgs = new Image[20];

            for (int i = 0; i < 20; i++)
            {
                imgs[i] = fd[i].facelet.GetComponent<Image>();
            }

            Color c19 = imgs[19].color;
            Sprite s19 = imgs[19].sprite;
            TransformData t19 = new TransformData(fd[19].facelet.transform);
            Sprite n19 = fd[19].spriteNumber;

            for (int i = 18; i >= 0; i--)
            {
                imgs[i + 1].color = imgs[i].color;
                imgs[i + 1].sprite = imgs[i].sprite;
                TransformData t = new TransformData(fd[i].facelet.transform);
                t.ApplyRotation(fd[i + 1].facelet.transform);
                fd[i + 1].spriteNumber = fd[i].spriteNumber;
            }
            imgs[0].color = c19;
            imgs[0].sprite = s19;
            t19.ApplyRotation(fd[0].facelet.transform);
            fd[0].spriteNumber = n19;
        }
    }
}
