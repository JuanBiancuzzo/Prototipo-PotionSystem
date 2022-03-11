using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class MovimientoPocionesController : MonoBehaviour
    {
        [SerializeField] private SceneManager _sceneManager;

        [Space]

        [SerializeField] private InputMovimientoInterfazSO _inputPlayer;

        private void OnEnable()
        {
            _inputPlayer.EventoSalir += Salir;
        }

        private void OnDisable()
        {
            _inputPlayer.EventoSalir -= Salir;
        }

        private void Interactuar()
        {
            // ray cast para agarrar el objeto y de esa forma moverlo
        }

        private void Salir()
        {
            _sceneManager.SalirDeEstado(EstadoJugador.CreandoPociones);
        }
    }
}
