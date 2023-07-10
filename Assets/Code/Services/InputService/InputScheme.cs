//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Code/Services/InputService/InputScheme.inputactions
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

public partial class @InputScheme: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputScheme()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputScheme"",
    ""maps"": [
        {
            ""name"": ""Clicker"",
            ""id"": ""ff3b2bcf-25da-4c7a-a97c-75bfe45cb041"",
            ""actions"": [
                {
                    ""name"": ""ScreenTouch"",
                    ""type"": ""Button"",
                    ""id"": ""63a7e504-8e51-4609-9779-15d32e1c6759"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ScreenTouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f1a5cf0d-d646-45b6-9c9f-2606a943a71d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""8c03048f-c24d-4093-8055-ada545d4fec8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""f0344261-2b2d-41ea-a501-cfab75c1ca3e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraDragInitial"",
                    ""type"": ""Button"",
                    ""id"": ""a373a69b-ffed-480b-ba45-d16d37c93514"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraDragDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1aea882f-2bf8-4f30-9161-120821e8b415"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""049c7a01-00b8-4837-a87f-aef997b66bdf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5ea8b54-e0d8-4297-9cc0-b57fbf47610e"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""ScreenTouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e43ecdd6-5689-41c5-9e3e-aae1decfaef0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fc0d091-a1df-4293-ad5c-11971616cf4a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraDragInitial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb1067aa-45de-4dd4-b176-81b74ee73cb8"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""CameraDragInitial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb03c4c8-157f-48d7-81f8-59b4c461fae1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraDragDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427f25d1-e7d1-40ee-97e8-9c8af045f373"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraDragDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6fad636-4e26-401e-b03f-5f85414ecf60"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""ScreenTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Clicker
        m_Clicker = asset.FindActionMap("Clicker", throwIfNotFound: true);
        m_Clicker_ScreenTouch = m_Clicker.FindAction("ScreenTouch", throwIfNotFound: true);
        m_Clicker_ScreenTouchPosition = m_Clicker.FindAction("ScreenTouchPosition", throwIfNotFound: true);
        m_Clicker_MouseClick = m_Clicker.FindAction("MouseClick", throwIfNotFound: true);
        m_Clicker_MousePosition = m_Clicker.FindAction("MousePosition", throwIfNotFound: true);
        m_Clicker_CameraDragInitial = m_Clicker.FindAction("CameraDragInitial", throwIfNotFound: true);
        m_Clicker_CameraDragDelta = m_Clicker.FindAction("CameraDragDelta", throwIfNotFound: true);
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

    // Clicker
    private readonly InputActionMap m_Clicker;
    private List<IClickerActions> m_ClickerActionsCallbackInterfaces = new List<IClickerActions>();
    private readonly InputAction m_Clicker_ScreenTouch;
    private readonly InputAction m_Clicker_ScreenTouchPosition;
    private readonly InputAction m_Clicker_MouseClick;
    private readonly InputAction m_Clicker_MousePosition;
    private readonly InputAction m_Clicker_CameraDragInitial;
    private readonly InputAction m_Clicker_CameraDragDelta;
    public struct ClickerActions
    {
        private @InputScheme m_Wrapper;
        public ClickerActions(@InputScheme wrapper) { m_Wrapper = wrapper; }
        public InputAction @ScreenTouch => m_Wrapper.m_Clicker_ScreenTouch;
        public InputAction @ScreenTouchPosition => m_Wrapper.m_Clicker_ScreenTouchPosition;
        public InputAction @MouseClick => m_Wrapper.m_Clicker_MouseClick;
        public InputAction @MousePosition => m_Wrapper.m_Clicker_MousePosition;
        public InputAction @CameraDragInitial => m_Wrapper.m_Clicker_CameraDragInitial;
        public InputAction @CameraDragDelta => m_Wrapper.m_Clicker_CameraDragDelta;
        public InputActionMap Get() { return m_Wrapper.m_Clicker; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClickerActions set) { return set.Get(); }
        public void AddCallbacks(IClickerActions instance)
        {
            if (instance == null || m_Wrapper.m_ClickerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ClickerActionsCallbackInterfaces.Add(instance);
            @ScreenTouch.started += instance.OnScreenTouch;
            @ScreenTouch.performed += instance.OnScreenTouch;
            @ScreenTouch.canceled += instance.OnScreenTouch;
            @ScreenTouchPosition.started += instance.OnScreenTouchPosition;
            @ScreenTouchPosition.performed += instance.OnScreenTouchPosition;
            @ScreenTouchPosition.canceled += instance.OnScreenTouchPosition;
            @MouseClick.started += instance.OnMouseClick;
            @MouseClick.performed += instance.OnMouseClick;
            @MouseClick.canceled += instance.OnMouseClick;
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
            @CameraDragInitial.started += instance.OnCameraDragInitial;
            @CameraDragInitial.performed += instance.OnCameraDragInitial;
            @CameraDragInitial.canceled += instance.OnCameraDragInitial;
            @CameraDragDelta.started += instance.OnCameraDragDelta;
            @CameraDragDelta.performed += instance.OnCameraDragDelta;
            @CameraDragDelta.canceled += instance.OnCameraDragDelta;
        }

        private void UnregisterCallbacks(IClickerActions instance)
        {
            @ScreenTouch.started -= instance.OnScreenTouch;
            @ScreenTouch.performed -= instance.OnScreenTouch;
            @ScreenTouch.canceled -= instance.OnScreenTouch;
            @ScreenTouchPosition.started -= instance.OnScreenTouchPosition;
            @ScreenTouchPosition.performed -= instance.OnScreenTouchPosition;
            @ScreenTouchPosition.canceled -= instance.OnScreenTouchPosition;
            @MouseClick.started -= instance.OnMouseClick;
            @MouseClick.performed -= instance.OnMouseClick;
            @MouseClick.canceled -= instance.OnMouseClick;
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
            @CameraDragInitial.started -= instance.OnCameraDragInitial;
            @CameraDragInitial.performed -= instance.OnCameraDragInitial;
            @CameraDragInitial.canceled -= instance.OnCameraDragInitial;
            @CameraDragDelta.started -= instance.OnCameraDragDelta;
            @CameraDragDelta.performed -= instance.OnCameraDragDelta;
            @CameraDragDelta.canceled -= instance.OnCameraDragDelta;
        }

        public void RemoveCallbacks(IClickerActions instance)
        {
            if (m_Wrapper.m_ClickerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IClickerActions instance)
        {
            foreach (var item in m_Wrapper.m_ClickerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ClickerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ClickerActions @Clicker => new ClickerActions(this);
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IClickerActions
    {
        void OnScreenTouch(InputAction.CallbackContext context);
        void OnScreenTouchPosition(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCameraDragInitial(InputAction.CallbackContext context);
        void OnCameraDragDelta(InputAction.CallbackContext context);
    }
}
