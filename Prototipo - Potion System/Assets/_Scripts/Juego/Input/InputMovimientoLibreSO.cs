using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Movimiento libre", menuName = "Input/Movimiento libre input")]
    public class InputMovimientoLibreSO : ScriptableObject, Inputs.IMovimientoLibreActions, MovimientoInput
    {
        public bool Interactuar { get; private set; }
        public Action EventoInteractuar;

        public bool Menu { get; private set; }
        public Action EventoMenu;

        public Vector2 DeltaMouse { get; private set; }
        public Vector2 Movimiento { get; private set; }

        private Inputs _playerControls = null;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.MovimientoLibre.SetCallbacks(this);
            }

            Activar();
        }

        private void OnDisable()
        {
            Desactivar();
        }

        public void Activar()
        {
            _playerControls.MovimientoLibre.Enable();
            ResetearValores();
        }

        public void Desactivar()
        {
            _playerControls.MovimientoLibre.Disable();
        }

        private void ResetearValores()
        {
            Interactuar = false;
            Menu = false;
            DeltaMouse = Vector2.zero;
            Movimiento = Vector2.zero;
        }

        public void OnInteractuar(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Interactuar = true;
                EventoInteractuar?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
                Interactuar = false;
        }

        public void OnMirar(InputAction.CallbackContext context)
        {
            DeltaMouse = context.ReadValue<Vector2>();
        }

        public void OnMover(InputAction.CallbackContext context)
        {
            Movimiento = context.ReadValue<Vector2>();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Interactuar = true;
                EventoMenu?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
                Interactuar = false;
        }
    }
}
