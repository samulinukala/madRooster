//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/player movement.inputactions
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

public partial class @Playermovement : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Playermovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""player movement"",
    ""maps"": [
        {
            ""name"": ""playerScripts"",
            ""id"": ""e55f5d00-9c8f-425b-a59d-13356c4e8939"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""cab9d4ce-a541-476c-9ff3-95ffac4c4ffd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""aim"",
                    ""type"": ""Value"",
                    ""id"": ""20ef8b78-ec59-495b-85b4-d7c7811a2b6e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""906fbcc9-e5ac-490a-ba35-6868bd727b5e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0a413fd-da16-40de-9085-ec5221351898"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerScripts
        m_playerMovement = asset.FindActionMap("playerScripts", throwIfNotFound: true);
        m_playerMovement_move = m_playerMovement.FindAction("move", throwIfNotFound: true);
        m_playerMovement_aim = m_playerMovement.FindAction("aim", throwIfNotFound: true);
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

    // playerScripts
    private readonly InputActionMap m_playerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_playerMovement_move;
    private readonly InputAction m_playerMovement_aim;
    public struct PlayerMovementActions
    {
        private @Playermovement m_Wrapper;
        public PlayerMovementActions(@Playermovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_playerMovement_move;
        public InputAction @aim => m_Wrapper.m_playerMovement_aim;
        public InputActionMap Get() { return m_Wrapper.m_playerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @aim.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAim;
                @aim.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAim;
                @aim.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @aim.started += instance.OnAim;
                @aim.performed += instance.OnAim;
                @aim.canceled += instance.OnAim;
            }
        }
    }
    public PlayerMovementActions @playerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
