using System;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Evento cambio estado jugador", menuName = "Evento/Cambio Estado Jugador")]
    public class EstadoJugadorEventoSO : ScriptableObject
    {
        public event Action<EstadoJugador> Evento;

        public void Activar(EstadoJugador estadoNuevo)
        {
            Evento?.Invoke(estadoNuevo);
        }
    }
}
