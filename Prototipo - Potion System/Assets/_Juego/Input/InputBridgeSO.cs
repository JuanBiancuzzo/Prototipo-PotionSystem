using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(menuName = "Input/Player input")]
    public class InputBridgeSO : ScriptableObject, PlayerInputs.IPlayerActions
    {
        public event Action<Vector2> eventoMover;
        public event Action<Vector2> eventoRotar;
        public event Action eventoSalto;
        public event Action eventoCancelarSalto;

        private PlayerInputs playerControls = null;

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerInputs();
                playerControls.Player.SetCallbacks(this);
            }

            Abilitar();
        }

        private void OnDisable()
        {
            Desabilitar();
        }

        /*
        public void OnInteractuar(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                eventoInteractuar?.Invoke();
        }
        */

        private void Abilitar()
        {
            playerControls.Player.Enable();
        }

        private void Desabilitar()
        {
            playerControls?.Player.Disable();
        }

        public void OnMover(InputAction.CallbackContext context)
        {
            eventoMover?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnMirar(InputAction.CallbackContext context)
        {
            eventoRotar?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnSaltar(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                eventoSalto?.Invoke();

            if (context.phase == InputActionPhase.Canceled)
                eventoCancelarSalto?.Invoke();
        }
    }
}
