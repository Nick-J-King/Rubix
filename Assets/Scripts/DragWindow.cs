using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Rubix.UI
{ 
    public class DragWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public RectTransform dragRectTransform; // Rect transform of panel being dragged.
        public RectTransform canvasRt;          // Rect transform of canvas for reference.

        private Vector2 localOrigPosition;

        private Vector2 localStartPoint;
        private Vector2 localStartPosition;

        public bool isDragging = false;     // Whether we are currently dragging...


        // Start is called before the first frame update
        public virtual void Start()
        {
            isDragging = false;
            localOrigPosition = transform.localPosition;
        }


        public virtual void Update()
        {
            if (!isDragging)
                return;

            // Convert eventData position to canvas rt position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRt, Mouse.current.position.ReadValue(), null, out Vector2 localPoint);

            dragRectTransform.localPosition = localPoint - localStartPoint + localStartPosition;
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            isDragging = true;

            // Convert eventData position to canvas rt position.
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRt, eventData.position, null, out localStartPoint);

            // Get rt for the start position, so we can do our proper deltas..
            localStartPosition = dragRectTransform.localPosition;
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false;
        }


        public void ResetPosition()
        {
            dragRectTransform.localPosition = localOrigPosition;
        }


        public void ResetPositionAndScale()
        {
            dragRectTransform.localPosition = localOrigPosition;
            dragRectTransform.localScale = Vector3.one;
        }
    }
}
