//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/_Scripts/Juego/Input/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""MovimientoLibre"",
            ""id"": ""e7fcdf1a-1ddc-4a51-9a66-7777e15c47af"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""Value"",
                    ""id"": ""1f0514e1-9b96-4f78-950b-c5c6bc1a6d21"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mirar"",
                    ""type"": ""Value"",
                    ""id"": ""f20a8ec8-e08d-4d90-8d52-ac322684ad33"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interactuar"",
                    ""type"": ""Button"",
                    ""id"": ""3f1fb61f-794f-494a-9d33-4c0f050e8789"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Flechas"",
                    ""id"": ""00433930-f527-46c7-ac80-a8d51acb9893"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1984a672-da69-4f52-a905-5b331443ee42"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a7909742-9e01-4aa0-aab8-08c9b46ece56"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f227a72-5e28-485f-95cc-ffc6b1bbfbac"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0bac7864-b2d9-4934-89f0-c8b980d49e2e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AWSD"",
                    ""id"": ""9504009f-134f-4340-923d-9eda75d3d5d2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""12a90f8e-a722-4d9a-9a21-1814001d30a4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""90d9330e-3552-47cb-8b63-2e20fba19148"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7074404d-3557-4b80-985b-8e9af99a0132"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f1480d4c-d33f-4e09-b3f3-c961eab70174"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""50c2d45b-ffb0-43b5-8d27-f635dd405a16"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a06a9bad-af36-4e3c-9fe7-1233950cec9e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interactuar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""a3339ccd-e98c-4d2b-aa3e-5443a0bf5232"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""a724a245-4b03-42cb-809c-21970ac36261"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a3e9c789-1be6-4e46-8a67-d118fc08ec1d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7bd0e4f-924f-4e75-b8eb-d10375051f1e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovimientoLibre
        m_MovimientoLibre = asset.FindActionMap("MovimientoLibre", throwIfNotFound: true);
        m_MovimientoLibre_Mover = m_MovimientoLibre.FindAction("Mover", throwIfNotFound: true);
        m_MovimientoLibre_Mirar = m_MovimientoLibre.FindAction("Mirar", throwIfNotFound: true);
        m_MovimientoLibre_Interactuar = m_MovimientoLibre.FindAction("Interactuar", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Menu = m_Menu.FindAction("Menu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MovimientoLibre
    private readonly InputActionMap m_MovimientoLibre;
    private IMovimientoLibreActions m_MovimientoLibreActionsCallbackInterface;
    private readonly InputAction m_MovimientoLibre_Mover;
    private readonly InputAction m_MovimientoLibre_Mirar;
    private readonly InputAction m_MovimientoLibre_Interactuar;
    public struct MovimientoLibreActions
    {
        private @Inputs m_Wrapper;
        public MovimientoLibreActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_MovimientoLibre_Mover;
        public InputAction @Mirar => m_Wrapper.m_MovimientoLibre_Mirar;
        public InputAction @Interactuar => m_Wrapper.m_MovimientoLibre_Interactuar;
        public InputActionMap Get() { return m_Wrapper.m_MovimientoLibre; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoLibreActions set) { return set.Get(); }
        public void SetCallbacks(IMovimientoLibreActions instance)
        {
            if (m_Wrapper.m_MovimientoLibreActionsCallbackInterface != null)
            {
                @Mover.started -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnMover;
                @Mirar.started -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnMirar;
                @Mirar.performed -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnMirar;
                @Mirar.canceled -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnMirar;
                @Interactuar.started -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnInteractuar;
                @Interactuar.performed -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnInteractuar;
                @Interactuar.canceled -= m_Wrapper.m_MovimientoLibreActionsCallbackInterface.OnInteractuar;
            }
            m_Wrapper.m_MovimientoLibreActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
                @Mirar.started += instance.OnMirar;
                @Mirar.performed += instance.OnMirar;
                @Mirar.canceled += instance.OnMirar;
                @Interactuar.started += instance.OnInteractuar;
                @Interactuar.performed += instance.OnInteractuar;
                @Interactuar.canceled += instance.OnInteractuar;
            }
        }
    }
    public MovimientoLibreActions @MovimientoLibre => new MovimientoLibreActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Menu;
    public struct MenuActions
    {
        private @Inputs m_Wrapper;
        public MenuActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_Menu_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Menu.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IMovimientoLibreActions
    {
        void OnMover(InputAction.CallbackContext context);
        void OnMirar(InputAction.CallbackContext context);
        void OnInteractuar(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnMenu(InputAction.CallbackContext context);
    }
}
