using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Rubix.Animation;


namespace Rubix.UI
{ 
    public class DragWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public RectTransform dragRectTransform;     // Rect transform of panel being dragged.
        public RectTransform canvasRectTransform;   // Rect transform of canvas for reference.

        public bool isDragging = false;     // Whether we are currently dragging...

        Vector2 _localOrigPosition;

        Vector2 _dragFromMousePosition;
        Vector2 _dragToMousePosition;


        public virtual void Start()
        {
            isDragging = false;
             _localOrigPosition = dragRectTransform.localPosition;
        }


        public virtual void Update()
        {
            if (!isDragging)
                return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Mouse.current.position.ReadValue(), null, out _dragToMousePosition);

            if (_dragToMousePosition == _dragFromMousePosition)
                return;

            Vector2 moveBy = _dragToMousePosition - _dragFromMousePosition;

            dragRectTransform.Translate(moveBy);

            _dragFromMousePosition = _dragToMousePosition;
        }


        public void ScaleUp(float factor, float step, float min, float max)
        {
            MovePivot();

            float ls = transform.localScale.x;
            ls = AnimationData.ClampWithStep(factor, min, max, ls, step);

            transform.localScale = new Vector3(ls, ls, 1.0f);
        }


        void MovePivot()
        { 
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


        // Set the pivot without moving the RectTransform.
        static void SetPivot(RectTransform target, Vector2 pivot)
        {
            if (!target) return;

            var offset = pivot - target.pivot;

            offset.Scale(target.rect.size);

            var worldPos = target.position + target.TransformVector(offset);
            target.pivot = pivot;
            target.position = worldPos;
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

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, null, out _dragFromMousePosition);
            gameObject.transform.SetAsLastSibling();
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false; // NOTE: May wish to update to latest mouse position...
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
