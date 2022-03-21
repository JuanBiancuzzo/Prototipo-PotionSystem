using System;
using UnityEngine;
using ItIsNotOnlyMe.Inventario;

namespace ItIsNotOnlyMe.Eventos
{ 
    [CreateAssetMenu(fileName = "Evento Item", menuName = "Eventos/Evento Item")]
    public class EventoItemSO : ScriptableObject
    {
        public Action<ItemSO> Evento;

        public void Invoke(ItemSO item)
        {
            Evento?.Invoke(item);
        }
    }
}