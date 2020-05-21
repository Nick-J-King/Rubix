using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaceMap : DragWindow
{

    public FacePanel frontPanel;
    public FacePanel backPanel;
    public FacePanel leftPanel;
    public FacePanel rightPanel;
    public FacePanel upPanel;
    public FacePanel downPanel;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
        // Y axis

    // nSlice = 0 is Top. nSlice = 4 is Bottom.
    public void CycleSliceFromTop(int nSlice, RotationDirection rotationDirection)
    {
        GameObject[] a = new GameObject[20];

        a[0] = frontPanel.pFacelets[0, 4 - nSlice];
        a[1] = frontPanel.pFacelets[1, 4 - nSlice];
        a[2] = frontPanel.pFacelets[2, 4 - nSlice];
        a[3] = frontPanel.pFacelets[3, 4 - nSlice];
        a[4] = frontPanel.pFacelets[4, 4 - nSlice];

        a[5] = rightPanel.pFacelets[0, 4 - nSlice];
        a[6] = rightPanel.pFacelets[1, 4 - nSlice];
        a[7] = rightPanel.pFacelets[2, 4 - nSlice];
        a[8] = rightPanel.pFacelets[3, 4 - nSlice];
        a[9] = rightPanel.pFacelets[4, 4 - nSlice];

        a[10] = backPanel.pFacelets[4, nSlice];
        a[11] = backPanel.pFacelets[3, nSlice];
        a[12] = backPanel.pFacelets[2, nSlice];
        a[13] = backPanel.pFacelets[1, nSlice];
        a[14] = backPanel.pFacelets[0, nSlice];

        a[15] = leftPanel.pFacelets[0, 4 - nSlice];
        a[16] = leftPanel.pFacelets[1, 4 - nSlice];
        a[17] = leftPanel.pFacelets[2, 4 - nSlice];
        a[18] = leftPanel.pFacelets[3, 4 - nSlice];
        a[19] = leftPanel.pFacelets[4, 4 - nSlice];

        if (rotationDirection == RotationDirection.normal)
            CycleFacelets20(a);
        else
            CycleFacelets20A(a);
    }

    // X axis

    // nSlice = 0 is Right. nSlice = 4 is Left.
    public void CycleSliceFromRight(int nSlice, RotationDirection rotationDirection)
    {
        GameObject[] a = new GameObject[20];

        a[0] = frontPanel.pFacelets[4 - nSlice, 0];
        a[1] = frontPanel.pFacelets[4 - nSlice, 1];
        a[2] = frontPanel.pFacelets[4 - nSlice, 2];
        a[3] = frontPanel.pFacelets[4 - nSlice, 3];
        a[4] = frontPanel.pFacelets[4 - nSlice, 4];

        a[5] = upPanel.pFacelets[4 - nSlice, 0];
        a[6] = upPanel.pFacelets[4 - nSlice, 1];
        a[7] = upPanel.pFacelets[4 - nSlice, 2];
        a[8] = upPanel.pFacelets[4 - nSlice, 3];
        a[9] = upPanel.pFacelets[4 - nSlice, 4];

        a[10] = backPanel.pFacelets[4 - nSlice, 0];
        a[11] = backPanel.pFacelets[4 - nSlice, 1];
        a[12] = backPanel.pFacelets[4 - nSlice, 2];
        a[13] = backPanel.pFacelets[4 - nSlice, 3];
        a[14] = backPanel.pFacelets[4 - nSlice, 4];

        a[15] = downPanel.pFacelets[4 - nSlice, 0];
        a[16] = downPanel.pFacelets[4 - nSlice, 1];
        a[17] = downPanel.pFacelets[4 - nSlice, 2];
        a[18] = downPanel.pFacelets[4 - nSlice, 3];
        a[19] = downPanel.pFacelets[4 - nSlice, 4];

        if (rotationDirection == RotationDirection.normal)
            CycleFacelets20A(a);
        else
            CycleFacelets20(a);
    }

    // Z axis

    // nSlice = 0 is Front. nSlice = 4 is Back.
    public void CycleSliceFromFront(int nSlice, RotationDirection direction)
    {
        GameObject[] a = new GameObject[20];

        a[0] = downPanel.pFacelets[0, 4 - nSlice];
        a[1] = downPanel.pFacelets[1, 4 - nSlice];
        a[2] = downPanel.pFacelets[2, 4 - nSlice];
        a[3] = downPanel.pFacelets[3, 4 - nSlice];
        a[4] = downPanel.pFacelets[4, 4 - nSlice];

        a[5] = rightPanel.pFacelets[nSlice, 0];
        a[6] = rightPanel.pFacelets[nSlice, 1];
        a[7] = rightPanel.pFacelets[nSlice, 2];
        a[8] = rightPanel.pFacelets[nSlice, 3];
        a[9] = rightPanel.pFacelets[nSlice, 4];

        a[10] = upPanel.pFacelets[4, nSlice];
        a[11] = upPanel.pFacelets[3, nSlice];
        a[12] = upPanel.pFacelets[2, nSlice];
        a[13] = upPanel.pFacelets[1, nSlice];
        a[14] = upPanel.pFacelets[0, nSlice];

        a[15] = leftPanel.pFacelets[4 - nSlice, 4];
        a[16] = leftPanel.pFacelets[4 - nSlice, 3];
        a[17] = leftPanel.pFacelets[4 - nSlice, 2];
        a[18] = leftPanel.pFacelets[4 - nSlice, 1];
        a[19] = leftPanel.pFacelets[4 - nSlice, 0];

        if (direction == RotationDirection.normal)
            CycleFacelets20A(a);
        else
            CycleFacelets20(a);
    }



    public void RotateFaceCW90(FacePanel face, RotationDirection direction)
    {
        if (direction == RotationDirection.reverse)
        {
            RotateFaceACW90(face, RotationDirection.normal);
            return;
        }

        GameObject[] a = new GameObject[4];

        // The outer edge.

        a[0] = face.pFacelets[0, 0];
        a[1] = face.pFacelets[4, 0];
        a[2] = face.pFacelets[4, 4];
        a[3] = face.pFacelets[0, 4];
        CycleFacelets4(a);

        a[0] = face.pFacelets[1, 0];
        a[1] = face.pFacelets[4, 1];
        a[2] = face.pFacelets[3, 4];
        a[3] = face.pFacelets[0, 3];
        CycleFacelets4(a);

        a[0] = face.pFacelets[2, 0];
        a[1] = face.pFacelets[4, 2];
        a[2] = face.pFacelets[2, 4];
        a[3] = face.pFacelets[0, 2];
        CycleFacelets4(a);

        a[0] = face.pFacelets[3, 0];
        a[1] = face.pFacelets[4, 3];
        a[2] = face.pFacelets[1, 4];
        a[3] = face.pFacelets[0, 1];
        CycleFacelets4(a);

        // The inner square

        a[0] = face.pFacelets[1, 1];
        a[1] = face.pFacelets[3, 1];
        a[2] = face.pFacelets[3, 3];
        a[3] = face.pFacelets[1, 3];
        CycleFacelets4(a);

        a[0] = face.pFacelets[2, 1];
        a[1] = face.pFacelets[3, 2];
        a[2] = face.pFacelets[2, 3];
        a[3] = face.pFacelets[1, 2];
        CycleFacelets4(a);

        // Now, rotate the facelets about their centres.
        
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                face.pFacelets[x,y].transform.Rotate(0.0f, 0.0f, -90.0f);
            }
        }
        
    }

    public void RotateFaceACW90(FacePanel face, RotationDirection direction)
    {
        if (direction == RotationDirection.reverse)
        {
            RotateFaceCW90(face, RotationDirection.normal);
            return;
        }

        GameObject[] a = new GameObject[4];

        // The outer edge.

        a[0] = face.pFacelets[0, 0];
        a[1] = face.pFacelets[4, 0];
        a[2] = face.pFacelets[4, 4];
        a[3] = face.pFacelets[0, 4];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[1, 0];
        a[1] = face.pFacelets[4, 1];
        a[2] = face.pFacelets[3, 4];
        a[3] = face.pFacelets[0, 3];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[2, 0];
        a[1] = face.pFacelets[4, 2];
        a[2] = face.pFacelets[2, 4];
        a[3] = face.pFacelets[0, 2];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[3, 0];
        a[1] = face.pFacelets[4, 3];
        a[2] = face.pFacelets[1, 4];
        a[3] = face.pFacelets[0, 1];
        CycleFacelets4A(a);

        // The inner square

        a[0] = face.pFacelets[1, 1];
        a[1] = face.pFacelets[3, 1];
        a[2] = face.pFacelets[3, 3];
        a[3] = face.pFacelets[1, 3];
        CycleFacelets4A(a);

        a[0] = face.pFacelets[2, 1];
        a[1] = face.pFacelets[3, 2];
        a[2] = face.pFacelets[2, 3];
        a[3] = face.pFacelets[1, 2];
        CycleFacelets4A(a);

        // Now, rotate the facelets about their centres.
        
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                face.pFacelets[x, y].transform.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
        
    }

    public void CycleFacelets4(GameObject[] f)
    {
        Image[] imgs = new Image[4];

        for (int i = 0; i < 4; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c0 = imgs[0].color;
        Sprite s0 = imgs[0].sprite;

        for (int i = 0; i < 3; i++)
        {
            imgs[i].color = imgs[i + 1].color;
            imgs[i].sprite = imgs[i + 1].sprite;
        }
        imgs[3].color = c0;
        imgs[3].sprite = s0;
    }

    public void CycleFacelets4A(GameObject[] f)
    {
        Image[] imgs = new Image[4];

        for (int i = 0; i < 4; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c3 = imgs[3].color;
        Sprite s3 = imgs[3].sprite;

        for (int i = 2; i >= 0; i--)
        {
            imgs[i + 1].color = imgs[i].color;
            imgs[i + 1].sprite = imgs[i].sprite;
        }
        imgs[0].color = c3;
        imgs[0].sprite = s3;
    }

    public void CycleFacelets20(GameObject[] f)
    {
        Image[] imgs = new Image[20];

        for (int i = 0; i < 20; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c0 = imgs[0].color;
        Sprite s0 = imgs[0].sprite;

        for (int i = 0; i < 19; i++)
        {
            imgs[i].color = imgs[i + 1].color;
            imgs[i].sprite = imgs[i + 1].sprite;
        }
        imgs[19].color = c0;
        imgs[19].sprite = s0;
    }

    public void CycleFacelets20A(GameObject[] f)
    {
        Image[] imgs = new Image[20];

        for (int i = 0; i < 20; i++)
        {
            imgs[i] = f[i].GetComponent<Image>();
        }

        Color c19 = imgs[19].color;
        Sprite s19 = imgs[19].sprite;

        for (int i = 18; i >= 0; i--)
        {
            imgs[i + 1].color = imgs[i].color;
            imgs[i + 1].sprite = imgs[i].sprite;
        }
        imgs[0].color = c19;
        imgs[0].sprite = s19;
    }


}
