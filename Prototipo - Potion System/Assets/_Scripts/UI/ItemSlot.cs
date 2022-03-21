using UnityEngine;
using UnityEngine.EventSystems;

namespace ItIsNotOnlyMe.ItemHandler
{
    [RequireComponent(typeof(RectTransform))]
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            RectTransform rectTransformObjeto;
            if (!eventData.pointerDrag.TryGetComponent(out rectTransformObjeto))
                return;

            rectTransformObjeto.anchoredPosition = _rectTransform.anchoredPosition;
        }
    }
}
