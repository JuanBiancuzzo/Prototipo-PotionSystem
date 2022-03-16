using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Evento void", menuName = "Eventos/Tipo void")]
    public class VoidEventoSO : ScriptableObject
    {
        public event Action Evento;

        public void Activar()
        {
            Evento?.Invoke();
        }
    }
}
