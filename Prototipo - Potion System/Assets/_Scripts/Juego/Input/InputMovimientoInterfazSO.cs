using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Movimiento crear pociones",  menuName = "Input/Crear pociones input")]
    public class InputMovimientoInterfazSO : ScriptableObject, Inputs.IMovimientoInterfazActions
    {
        public event Action EventoInteractuar;
        public event Action EventoCancelarInteraccion;
        public event Action EventoSalir;
        public event Action EventoCambiarIzquierda;
        public event Action EventoCambiarDerecha;

        private Inputs _playerControls = null;

        [SerializeField] private EstadoJugadorEventoSO _cambio;
        [SerializeField] private VoidEventoSO _eventoActivar, _eventoDesactivar;
        [Space]
        [SerializeField] [Range(0.01f, 1f)] private float _sencibilidadDeCambio = 0.1f;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.MovimientoInterfaz.SetCallbacks(this);
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
            if (nuevoEstado == EstadoJugador.CreandoPociones)
                Activar();
            else
                Desactivar();
        }

        private void Activar()
        {
            _eventoActivar?.Activar();
            _playerControls.MovimientoInterfaz.Enable();
        }

        private void Desactivar()
        {
            _eventoDesactivar?.Activar();
            _playerControls.MovimientoInterfaz.Disable();
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

        public void OnCambiarEstacion(InputAction.CallbackContext context)
        {
            float direccion = context.ReadValue<float>();

            if (direccion < -_sencibilidadDeCambio)
                EventoCambiarIzquierda?.Invoke();
            else if (direccion > _sencibilidadDeCambio)
                EventoCambiarDerecha?.Invoke();
        }
    }
}
