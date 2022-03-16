using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Menu input", menuName = "Input/Menu input")]
    public class InputMenuSO : ScriptableObject, Inputs.IMenuActions
    {
        public bool Menu { get; private set; }
        public Action EventoMenu;

        private Inputs _playerControls = null;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new Inputs();
                _playerControls.Menu.SetCallbacks(this);
            }

            SetActive(true);
        }

        private void OnDisable()
        {
            SetActive(false);
        }

        public void SetActive(bool activo)
        {
            if (activo)
            {
                _playerControls.Menu.Enable();
                ResetearValores();
            }
            else
            {
                _playerControls.Menu.Disable();
            }
        }

        private void ResetearValores()
        {
            Menu = false;
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Menu = true;
                EventoMenu?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
                Menu = false;
        }
    }
}
