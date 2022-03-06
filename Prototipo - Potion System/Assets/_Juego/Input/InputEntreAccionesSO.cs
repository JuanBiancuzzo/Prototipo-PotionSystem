using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(menuName = "Input/Player input")]
    public class InputEntreAccionesSO : ScriptableObject, Inputs.IEntreAccionesActions
    {

        public event Action<Vector2> EventoMover;
        public event Action<Vector2> EventoRotar;
        public event Action EventoInteractuar;
        public event Action EventoCancelarInteraccion;

        private Inputs _playerControls = null;

        [SerializeField] private EstadoJugadorEventoSO _cambio;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.EntreAcciones.SetCallbacks(this);
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

        private void Cambiar(EstadoJugador nuevoEstado)
        {
            Desactivar();
            if (nuevoEstado == EstadoJugador.EntreAcciones)
                Activar();
        }

        private void Activar()
        {
            _playerControls.EntreAcciones.Enable();
        }

        private void Desactivar()
        {
            _playerControls.EntreAcciones.Disable();
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
