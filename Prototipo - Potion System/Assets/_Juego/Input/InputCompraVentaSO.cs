using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(menuName = "Input/Compra venta input")]
    public class InputCompraVentaSO : ScriptableObject, Inputs.IComprarVenderActions
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
                _playerControls.ComprarVender.SetCallbacks(this);
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
            if (nuevoEstado == EstadoJugador.CompraVenta)
                Activar();
        }

        private void Activar()
        {
            _playerControls.ComprarVender.Enable();
        }

        private void Desactivar()
        {
            _playerControls.ComprarVender.Disable();
        }

        public void OnInteractuar(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                EventoInteractuar?.Invoke();

            if (context.phase == InputActionPhase.Canceled)
                EventoCancelarInteraccion?.Invoke();
        }

        public void OnSalir(InputAction.CallbackContext context)
        {
            EventoSalir?.Invoke();
        }
    }
}
