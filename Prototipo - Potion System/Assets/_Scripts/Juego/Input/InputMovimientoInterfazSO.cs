using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Movimiento crear pociones", menuName = "Input/Crear pociones input")]
    public class InputMovimientoInterfazSO : ScriptableObject, Inputs.IMovimientoInterfazActions, MovimientoInput
    {
        public float Navegar { get; private set; }
        public bool Click { get; private set; }
        public bool Salir { get; private set; }

        private Inputs _playerControls = null;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.MovimientoInterfaz.SetCallbacks(this);
            }
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
            Navegar = 0f;
            Click = false;
            Salir = false;
        }

        public void OnSalir(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                Salir = true;

            if (context.phase == InputActionPhase.Canceled)
                Salir = false;
        }

        public void OnNavegar(InputAction.CallbackContext context)
        {
            Navegar = context.ReadValue<float>();
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                Click = true;

            if (context.phase == InputActionPhase.Canceled)
                Click = false;
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            
        }
    }
}
