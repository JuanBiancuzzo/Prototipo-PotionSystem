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

        private void Update()
        {
            Salir();
        }

        private void Salir()
        {
            if (_inputPlayer.Salir)
                _sceneManager.SalirDeEstado(EstadoJugador.CreandoPociones);
        }
    }
}
