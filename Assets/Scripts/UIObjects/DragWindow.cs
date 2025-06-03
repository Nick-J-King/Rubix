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
        Vector2 _origPivot;

        Vector2 _dragFromMousePosition;
        Vector2 _dragToMousePosition;


        public virtual void Start()
        {
            isDragging = false;
            _localOrigPosition = dragRectTransform.localPosition;
            _origPivot = dragRectTransform.pivot;
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

            RectTransformUtility.ScreenPointToLocalPointInRectangle(dragRectTransform, screenPoint, null, out Vector2 localPoint);

            Vector3 [] corners = new Vector3[4];

            dragRectTransform.GetLocalCorners(corners);

            var xDelta = corners[2].x - corners[0].x;
            var yDelta = corners[1].y - corners[0].y;
            var x = (localPoint.x - corners[0].x) / xDelta;
            var y = (localPoint.y - corners[0].y) / yDelta;

            Vector2 newPivot = new Vector2(x,y);

            var offset = newPivot - dragRectTransform.pivot;

            offset.Scale(dragRectTransform.rect.size);

            var worldPos = dragRectTransform.position + dragRectTransform.TransformVector(offset);

            dragRectTransform.pivot = newPivot;
            dragRectTransform.position = worldPos;
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


        public void ResetPositionAndScale()
        {
            dragRectTransform.localPosition = _localOrigPosition;
            dragRectTransform.localScale = Vector3.one;
            dragRectTransform.pivot = _origPivot;
        }
    }
}
