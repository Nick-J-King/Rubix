using UnityEngine;
using UnityEngine.UI;
using Rubix.Data;


namespace Rubix.UI
{ 
    public class MovesPanel : DragWindow
    {
        public GameObject contentObj;
        public GameObject scroller;
        public GameObject prefab;
        public RectTransform contentRect;
        public Text titleText;


        ScrollRect sr;
        int _numMoves;

        public override void Start()
        {
            base.Start();
            sr = scroller.GetComponent<ScrollRect>();

            _numMoves = 0;
            SetTitle();
        }


        public override void Update()
        {
            base.Update();
        }


        public void ClearMoves()
        {
            for (int i = contentRect.childCount - 1; i >= 0; --i) {
                GameObject.Destroy(contentRect.GetChild(i).gameObject);
            }
            contentRect.DetachChildren();

            _numMoves = 0;
            SetTitle();
        }


        void SetTitle()
        {
            if (_numMoves == 0)
                titleText.text = "Moves";
            else
                titleText.text = "Moves: " + _numMoves;
        }


        public void GoFirst()
        {
            sr.normalizedPosition = new Vector2(0, 1);

            // Unwind to start!
            Debug.Log("GoFirst");
        }


        public void GoPrevious()
        {
            // Unwind last move!
            Debug.Log("GoPrevious");
        }


        public void GoNext()
        {
            // Play next move!
            Debug.Log("GoNext");
        }


        public void GoLast()
        {
            // Replay to end!
            Debug.Log("GoLast");
            sr.normalizedPosition = new Vector2(0, 0);
        }


        public void ClickMove()
        {
            Debug.Log($"Click !");
        }


        public void AddMove(AnimationSpecification animationSpecification)
        {
            RotationDirection rotationDirection = animationSpecification.rotationDirection;
            CubeAxis cubeAxis = animationSpecification.cubeAxis;
            CubeSlices cubeSlices = animationSpecification.cubeSlices;
            MoveType moveType = animationSpecification.moveType;

            string s = "";

            switch (cubeAxis)
            {
                case CubeAxis.x:
                    s = "x";
                    break;
                case CubeAxis.y:
                    s = "y";
                    break;
                case CubeAxis.z:
                    s = "z";
                    break;
            }

            switch (cubeSlices)
            {
                case CubeSlices.s0:
                    s += "0";
                    break;
                case CubeSlices.s01:
                    s += "01";
                    break;
                case CubeSlices.s1:
                    s += "1";
                    break;
                case CubeSlices.s2:
                    s += "2";
                    break;
                case CubeSlices.s3:
                    s += "3";
                    break;
                case CubeSlices.s34:
                    s += "34";
                    break;
                case CubeSlices.s4:
                    s += "4";
                    break;
                case CubeSlices.s01234:
                    s += "01234";
                    break;
            }

            if (rotationDirection == RotationDirection.reverse)
                s += "R";
            if (moveType == MoveType.doubleMove)
                s += "D";

            GameObject g1 = Instantiate(prefab); 
            g1.gameObject.transform.SetParent(contentRect, false);

            g1.SetActive(true);

            var g1m = g1.GetComponent<MyMove>();
            g1m.text.text = "  " + s;

            Canvas.ForceUpdateCanvases();

            contentObj.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical() ;
            contentObj.GetComponent<ContentSizeFitter>().SetLayoutVertical() ;

            sr.content.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical() ;
            sr.content.GetComponent<ContentSizeFitter>().SetLayoutVertical() ;

            sr.normalizedPosition = new Vector2(0, 0);

            _numMoves++;
            SetTitle();
        }
    }
}
