using System;
using UnityEngine;

namespace ItIsNotOnlyMe.Eventos
{
    [CreateAssetMenu(fileName = "Evento Void", menuName = "Eventos/Evento Void")]
    public class EventoVoidSO : ScriptableObject
    {
        public Action Evento;

        public void Invoke()
        {
            Evento?.Invoke();
        }
    }
}