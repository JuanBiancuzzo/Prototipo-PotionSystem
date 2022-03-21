using System.Collections;
using UnityEngine;
using ItIsNotOnlyMe.Eventos;
using System.Collections.Generic;

namespace ItIsNotOnlyMe.Inventario
{
    [CreateAssetMenu(fileName = "Inventario", menuName = "Inventario System/Inventario")]
    public class InventarioSO : ScriptableObject, IInventario
    {
        [SerializeField] private EventoItemSO _agregarItem, _sacarItem;
        [SerializeField] private EventoVoidSO _seActualizaInventario;

        [Space]

        [SerializeField] private List<ItemSO> _items;

        [ContextMenu("Agregar items")]
        private void AgregarItems()
        {
            foreach (ItemSO item in _items)
                Agregar(item);
        }

        [ContextMenu("Sacar items")]
        private void SacarItems()
        {
            for (int i = 1; i < _items.Count; i++)
                Sacar(_items[i]);
        }

        private Inventario _inventario;

        public IInventario Inventario
        {
            get
            {
                if (_inventario == null)
                    _inventario = new Inventario();
                return _inventario;
            }
        }

        public bool Agregar(IItem item)
        {
            bool respuesta = Inventario.Agregar(item);
            if (respuesta)
            {
                _agregarItem?.Invoke(item as ItemSO);
                _seActualizaInventario?.Invoke();
            }
            return respuesta;
        }

        public bool Sacar(IItem item)
        {
            bool respuesta = Inventario.Sacar(item);
            if (respuesta)
            {
                _sacarItem?.Invoke(item as ItemSO);
                _seActualizaInventario?.Invoke();
            }
            return respuesta;
        }

        public int Cantidad()
        {
            return Inventario.Cantidad();
        }

        public IEnumerator GetEnumerator()
        {
            return Inventario.GetEnumerator();
        }
    }
}
