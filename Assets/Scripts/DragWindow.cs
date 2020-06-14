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

            float ls = go.transform.localScale.x;
            ls = AnimationData.ClampWithStep(factor, min, max, ls, step);

            go.transform.localScale = new Vector3(ls, ls, 1.0f);
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
