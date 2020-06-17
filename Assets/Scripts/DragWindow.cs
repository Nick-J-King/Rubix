using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Rubix.Animation;


namespace Rubix.UI
{ 
    public class DragWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public RectTransform dragRectTransform; // Rect transform of panel being dragged.
        public RectTransform canvasRectTransform;          // Rect transform of canvas for reference.

        public bool isDragging = false;     // Whether we are currently dragging...

        Vector2 _localOrigPosition;

        Vector2 _localStartPoint;
        Vector2 _localStartPosition;


        public virtual void Start()
        {
            isDragging = false;
            _localOrigPosition = transform.localPosition;
        }


        public virtual void Update()
        {
            if (!isDragging)
                return;

            // Convert eventData position to canvas rt position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Mouse.current.position.ReadValue(), null, out Vector2 localPoint);

            dragRectTransform.localPosition = localPoint - _localStartPoint + _localStartPosition;
        }


        public void ScaleUp(float factor, float step, float min, float max)
        {
            GameObject go = gameObject;
            MovePivot();

            float ls = go.transform.localScale.x;
            ls = AnimationData.ClampWithStep(factor, min, max, ls, step);

            go.transform.localScale = new Vector3(ls, ls, 1.0f);
        }


        public static void SetPivot(RectTransform target, Vector2 pivot)
        {
            if (!target) return;
            var offset = pivot - target.pivot;
            offset.Scale(target.rect.size);
            var wordlPos = target.position + target.TransformVector(offset);
            target.pivot = pivot;
            target.position = wordlPos;

            Debug.Log("DW SetPivot: (" + pivot.x + ", " + pivot.y + ")");
        }


        public void MovePivot()
        { 
            //Vector2 screenPoint = target.screenPosition;
            Vector2 screenPoint = Mouse.current.position.ReadValue();
            RectTransform objectRect = gameObject.GetComponent<RectTransform>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(objectRect, screenPoint, null, out Vector2 localPoint2);

            Vector3 [] corners = new Vector3[4];

            objectRect.GetLocalCorners(corners);

            var xDelta = corners[2].x - corners[0].x;
            var yDelta = corners[1].y - corners[0].y;
            var x = (localPoint2.x - corners[0].x) / xDelta;
            var y = (localPoint2.y - corners[0].y) / yDelta;

            SetPivot(objectRect, new Vector2(x,y));
        }


        public void ToggleViewable()
        {
            SetViewable(!gameObject.activeInHierarchy);
        }


        public void SetViewable(bool viewable)
        {
            gameObject.SetActive(viewable);
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            isDragging = true;

            // Convert eventData position to canvas rt position.
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, null, out _localStartPoint);

            // Get rt for the start position, so we can do our proper deltas..
            _localStartPosition = dragRectTransform.localPosition;
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log(Time.frameCount + ": OnPointerUp");
            isDragging = false;
        }


        public void ResetPosition()
        {
            dragRectTransform.localPosition = _localOrigPosition;
        }


        public void ResetPositionAndScale()
        {
            dragRectTransform.localPosition = _localOrigPosition;
            dragRectTransform.localScale = Vector3.one;
        }
    }
}
