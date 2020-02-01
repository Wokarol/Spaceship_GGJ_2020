// GENERATED AUTOMATICALLY FROM 'Assets/Game/InputMaps/GameplayInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameplayInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayInput"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""cc7f4cf3-ad37-4eac-8da5-10743808a8be"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""71f3a8c7-d4ca-46ff-8b77-b663f136b770"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""980b7cf0-7a3b-40a8-8f49-167e3cb87d9e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""0edc6a15-fb8a-4839-9035-2313d6a3e1ef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""8b74ebc3-d42d-4632-af42-7e22cd962506"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""286466a0-0ae1-4e37-b81d-1984ff42cd99"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00bed1d2-d1c2-41ba-9c58-23a85f68ab83"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""677a4a3c-8421-45e4-b68a-a614b91fd02e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0c842890-719d-4584-85eb-a7a7c277fe4a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ad742cd-fca1-49ad-bf85-69060d68d2ff"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""91a518c3-4b5e-4bf0-8603-6bbef6553d9b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0ab16e08-541d-407b-abd6-34a046b02025"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f36d5027-e5fe-4bbe-a6f7-5b0523cde126"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46289a09-be35-4d7c-8f09-4343b1476272"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ea9239-10ce-4508-b099-bc11f507c2eb"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa63e17e-8e10-4758-a29a-767e6d0c4f4e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c20d3f21-8fee-4e33-a2cb-797815e3a642"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31b3d626-b13e-4bc4-9a43-88b203954f6f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Movement = m_General.FindAction("Movement", throwIfNotFound: true);
        m_General_Pickup = m_General.FindAction("Pickup", throwIfNotFound: true);
        m_General_Swap = m_General.FindAction("Swap", throwIfNotFound: true);
        m_General_UseItem = m_General.FindAction("UseItem", throwIfNotFound: true);
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

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Movement;
    private readonly InputAction m_General_Pickup;
    private readonly InputAction m_General_Swap;
    private readonly InputAction m_General_UseItem;
    public struct GeneralActions
    {
        private @GameplayInput m_Wrapper;
        public GeneralActions(@GameplayInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_General_Movement;
        public InputAction @Pickup => m_Wrapper.m_General_Pickup;
        public InputAction @Swap => m_Wrapper.m_General_Swap;
        public InputAction @UseItem => m_Wrapper.m_General_UseItem;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                @Pickup.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPickup;
                @Swap.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSwap;
                @Swap.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSwap;
                @Swap.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSwap;
                @UseItem.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnUseItem;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @Swap.started += instance.OnSwap;
                @Swap.performed += instance.OnSwap;
                @Swap.canceled += instance.OnSwap;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGeneralActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
    }
}
