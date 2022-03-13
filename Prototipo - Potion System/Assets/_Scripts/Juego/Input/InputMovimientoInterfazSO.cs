using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Movimiento crear pociones", menuName = "Input/Crear pociones input")]
    public class InputMovimientoInterfazSO : ScriptableObject, Inputs.IMovimientoInterfazActions
    {
        public float CambiarDireccion { get; private set; }
        public bool Interactuar { get; private set; }
        public bool Salir { get; private set; }

        private Inputs _playerControls = null;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.MovimientoInterfaz.SetCallbacks(this);
            }

            Activar();
        }

        private void OnDisable()
        {
            Desactivar();
        }
        public void Activar()
        {
            _playerControls.MovimientoInterfaz.Enable();
            ResetearValores();
        }

        public void Desactivar()
        {
            _playerControls.MovimientoInterfaz.Disable();
        }

        private void ResetearValores()
        {
            CambiarDireccion = 0f;
            Interactuar = false;
            Salir = false;
        }


        public void OnCambiarEstacion(InputAction.CallbackContext context)
        {
            CambiarDireccion = context.ReadValue<float>();
        }

        public void OnInteractuar(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                Interactuar = true;

            if (context.phase == InputActionPhase.Canceled)
                Interactuar = false;
        }

        public void OnSalir(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                Salir = true;

            if (context.phase == InputActionPhase.Canceled)
                Salir = false;
        }
    }
}
