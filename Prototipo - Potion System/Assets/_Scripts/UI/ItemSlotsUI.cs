using UnityEngine;
using UnityEngine.UI;

namespace ItIsNotOnlyMe.Inventario
{
    public class ItemSlotsUI : MonoBehaviour
    {
        [SerializeField] private int _capacidad;

        [Space]

        [SerializeField] private GameObject _itemPrefab;

        public void Actualizar(InventarioSO inventario)
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);

            int i = 0;
            foreach (Stack stack in inventario)
            {
                /*ItemSO item = stack.GetItem() as ItemSO;

                GameObject itemSlot = Instantiate(_itemPrefab, transform);
                Image imagen = itemSlot.GetComponentInChildren<Image>();
                
                imagen.sprite = item.GetSprite();*/
                i++;
            }

            for (; i < _capacidad; i++)
            {
                Instantiate(_itemPrefab, transform);
            }
        }
    }
}
