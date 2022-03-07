using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(menuName = "Input/Crear pociones input")]
    public class InputCrearPocionesSO : ScriptableObject, Inputs.ICreandoPocionesActions
    {
        public event Action EventoInteractuar;
        public event Action EventoCancelarInteraccion;
        public event Action EventoSalir;

        private Inputs _playerControls = null;

        [SerializeField] private EstadoJugadorEventoSO _cambio;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.CreandoPociones.SetCallbacks(this);
            }

            if (_cambio != null)
                _cambio.Evento += Cambiar;
        }
        private void OnDisable()
        {
            Desactivar();
            if (_cambio != null)
                _cambio.Evento -= Cambiar;
        }

        public void Cambiar(EstadoJugador nuevoEstado)
        {
            Desactivar();
            if (nuevoEstado == EstadoJugador.CreandoPociones)
                Activar();
        }

        private void Activar()
        {
            _playerControls.CreandoPociones.Enable();
        }

        private void Desactivar()
        {
            _playerControls.CreandoPociones.Disable();
        }

        public void OnSalir(InputAction.CallbackContext context)
        {
            EventoSalir?.Invoke();
        }

        public void OnInteractuar(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                EventoInteractuar?.Invoke();

            if (context.phase == InputActionPhase.Canceled)
                EventoCancelarInteraccion?.Invoke();
        }
    }
}
