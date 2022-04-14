// GENERATED AUTOMATICALLY FROM 'Assets/InputControls/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""DepthRay"",
            ""id"": ""23cd7bf6-888a-43e4-bb0a-6c434504f6f8"",
            ""actions"": [
                {
                    ""name"": ""CastRay"",
                    ""type"": ""Value"",
                    ""id"": ""d3e0bbea-c84d-4334-8727-90bdce684e4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveSphere"",
                    ""type"": ""Button"",
                    ""id"": ""7762bf7b-b0d7-4f25-ad38-31663ddc3cc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1be571b-5d74-410c-9174-e33b00142517"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastRay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5992f5e6-5a3a-4623-aaf7-a5085e6179df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e5a9aa8d-5605-4aa0-ae4e-0c86e0b75ce9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""731ff3de-86aa-4b21-850c-1533f266b1c7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DepthRay
        m_DepthRay = asset.FindActionMap("DepthRay", throwIfNotFound: true);
        m_DepthRay_CastRay = m_DepthRay.FindAction("CastRay", throwIfNotFound: true);
        m_DepthRay_MoveSphere = m_DepthRay.FindAction("MoveSphere", throwIfNotFound: true);
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

    // DepthRay
    private readonly InputActionMap m_DepthRay;
    private IDepthRayActions m_DepthRayActionsCallbackInterface;
    private readonly InputAction m_DepthRay_CastRay;
    private readonly InputAction m_DepthRay_MoveSphere;
    public struct DepthRayActions
    {
        private @InputMaster m_Wrapper;
        public DepthRayActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastRay => m_Wrapper.m_DepthRay_CastRay;
        public InputAction @MoveSphere => m_Wrapper.m_DepthRay_MoveSphere;
        public InputActionMap Get() { return m_Wrapper.m_DepthRay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DepthRayActions set) { return set.Get(); }
        public void SetCallbacks(IDepthRayActions instance)
        {
            if (m_Wrapper.m_DepthRayActionsCallbackInterface != null)
            {
                @CastRay.started -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnCastRay;
                @CastRay.performed -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnCastRay;
                @CastRay.canceled -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnCastRay;
                @MoveSphere.started -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnMoveSphere;
                @MoveSphere.performed -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnMoveSphere;
                @MoveSphere.canceled -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnMoveSphere;
            }
            m_Wrapper.m_DepthRayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CastRay.started += instance.OnCastRay;
                @CastRay.performed += instance.OnCastRay;
                @CastRay.canceled += instance.OnCastRay;
                @MoveSphere.started += instance.OnMoveSphere;
                @MoveSphere.performed += instance.OnMoveSphere;
                @MoveSphere.canceled += instance.OnMoveSphere;
            }
        }
    }
    public DepthRayActions @DepthRay => new DepthRayActions(this);
    public interface IDepthRayActions
    {
        void OnCastRay(InputAction.CallbackContext context);
        void OnMoveSphere(InputAction.CallbackContext context);
    }
}
