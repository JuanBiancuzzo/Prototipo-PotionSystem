using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Scene Manager", menuName = "Manager/Scene Manager")]
    public class SceneManager : ScriptableObject
    {
        [System.Serializable]
        private struct CambioDeEstados
        {
            [SerializeField]
            private EstadoJugador _estadoActual, _estadoDeseado;

            public bool EstadoActual(EstadoJugador estado)
            {
                return _estadoActual == estado;
            }

            public EstadoJugador EstadoDeseado()
            {
                return _estadoDeseado;
            }
        }

        [SerializeField] private EstadoJugador _estadoJugador = EstadoJugador.MovimientoLibre;
        [SerializeField] private EstadoJugadorEventoSO _cambiar;
        [SerializeField] private List<CambioDeEstados> _cambiosDeEstado;

        public void SalirDeEstado(EstadoJugador estado)
        {
            foreach (CambioDeEstados cambio in _cambiosDeEstado)
                if (cambio.EstadoActual(estado))
                {
                    _estadoJugador = cambio.EstadoDeseado();
                    _cambiar?.Activar(_estadoJugador);
                    return;
                }
        }
    }
}
