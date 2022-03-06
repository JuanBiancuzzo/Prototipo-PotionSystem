using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(menuName = "Input/Player input")]
    public class InputBridgeSO : ScriptableObject, Inputs.IEntreAccionesActions, Inputs.ICreandoPocionesActions
    {
        private enum Estado
        {
            EntreAcciones,
            CreandoPociones
        }

        public event Action<Vector2> EventoMover;
        public event Action<Vector2> EventoRotar;
        public event Action EventoInteractuar;
        public event Action EventoCancelarInteraccion;

        public event Action EventoInteractuarMouse;
        public event Action EventoCancelarInteraccionMouse;

        private Inputs _playerControls = null;

        private Estado _estado;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.EntreAcciones.SetCallbacks(this);
                _playerControls.CreandoPociones.SetCallbacks(this);
            }

            ActivarEntreAcciones();
            _estado = Estado.EntreAcciones;
        }

        private void OnDisable()
        {
            DesactivarCreandoPociones();
            DesactivarEntreAcciones();
        }

        private void Cambiar()
        {
            switch (_estado)
            {
                case Estado.EntreAcciones:
                    DesactivarEntreAcciones();
                    ActivarCreandoPociones();
                    _estado = Estado.CreandoPociones;
                    break;
                case Estado.CreandoPociones:
                    DesactivarCreandoPociones();
                    ActivarEntreAcciones();
                    _estado = Estado.EntreAcciones;
                    break;
            }
        }

        private void ActivarEntreAcciones()
        {
            _playerControls.EntreAcciones.Enable();
        }

        private void ActivarCreandoPociones()
        {
            _playerControls.CreandoPociones.Enable();
        }

        private void DesactivarEntreAcciones()
        {
            _playerControls.EntreAcciones.Disable();
        }

        private void DesactivarCreandoPociones()
        {
            _playerControls.CreandoPociones.Disable();
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
