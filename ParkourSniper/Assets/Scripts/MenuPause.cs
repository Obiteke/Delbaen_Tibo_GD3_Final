// GENERATED AUTOMATICALLY FROM 'Assets/Input/MenuPause.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MenuPauseInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuPauseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuPause"",
    ""maps"": [
        {
            ""name"": ""PausingMenu"",
            ""id"": ""ed3a9d14-0170-41bc-8383-342952ce8a93"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""a81bacfb-00d3-4f80-b59b-d68528dd70d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa719d98-ae42-4c70-ae8b-f9dce4f5fbc2"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PausingMenu
        m_PausingMenu = asset.FindActionMap("PausingMenu", throwIfNotFound: true);
        m_PausingMenu_Escape = m_PausingMenu.FindAction("Escape", throwIfNotFound: true);
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

    // PausingMenu
    private readonly InputActionMap m_PausingMenu;
    private IPausingMenuActions m_PausingMenuActionsCallbackInterface;
    private readonly InputAction m_PausingMenu_Escape;
    public struct PausingMenuActions
    {
        private @MenuPauseInput m_Wrapper;
        public PausingMenuActions(@MenuPauseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_PausingMenu_Escape;
        public InputActionMap Get() { return m_Wrapper.m_PausingMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PausingMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPausingMenuActions instance)
        {
            if (m_Wrapper.m_PausingMenuActionsCallbackInterface != null)
            {
                @Escape.started -= m_Wrapper.m_PausingMenuActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_PausingMenuActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_PausingMenuActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_PausingMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public PausingMenuActions @PausingMenu => new PausingMenuActions(this);
    public interface IPausingMenuActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}
