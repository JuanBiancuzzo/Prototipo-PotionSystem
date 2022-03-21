using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItIsNotOnlyMe.Eventos;

namespace ItIsNotOnlyMe.Inventario
{
    public class InventarioUI : MonoBehaviour
    {
        [SerializeField] private InventarioSO _inventario;

        [Space]

        [SerializeField] private EventoVoidSO _seActualizaInventario;

        [Space]

        [SerializeField] private ItemSlotsUI _itemSlots;

        private void OnEnable() => _seActualizaInventario.Evento += ActualizarInventario;

        private void OnDisable() => _seActualizaInventario.Evento -= ActualizarInventario;

        private void ActualizarInventario()
        {
            _itemSlots.Actualizar(_inventario);
        }
    }
}
