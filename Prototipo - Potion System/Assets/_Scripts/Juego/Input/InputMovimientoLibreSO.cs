using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Movimiento libre", menuName = "Input/Movimiento libre input")]
    public class InputMovimientoLibreSO : ScriptableObject, Inputs.IMovimientoLibreActions
    {

        public event Action<Vector2> EventoMover;
        public event Action<Vector2> EventoRotar;
        public event Action EventoInteractuar;
        public event Action EventoCancelarInteraccion;

        private Inputs _playerControls = null;

        [SerializeField] private EstadoJugadorEventoSO _cambio;
        [SerializeField] private VoidEventoSO _eventoActivar, _eventoDesactivar;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.MovimientoLibre.SetCallbacks(this);
            }

            if (_cambio != null)
                _cambio.Evento += Cambiar;
            Activar();
        }

        private void OnDisable()
        {
            Desactivar();
            if (_cambio != null)
                _cambio.Evento -= Cambiar;
        }

        private void Cambiar(EstadoJugador nuevoEstado)
        {
            if (nuevoEstado == EstadoJugador.MovimientoLibre)
                Activar();
            else
                Desactivar();
        }

        private void Activar()
        {
            _eventoActivar?.Activar();
            _playerControls.MovimientoLibre.Enable();
        }

        private void Desactivar()
        {
            _eventoDesactivar?.Activar();
            _playerControls.MovimientoLibre.Disable();
        }

        public void OnMover(InputAction.CallbackContext context)
        {
            EventoMover?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnMirar(InputAction.CallbackContext context)
        {
            EventoRotar?.Invoke(context.ReadValue<Vector2>());
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
