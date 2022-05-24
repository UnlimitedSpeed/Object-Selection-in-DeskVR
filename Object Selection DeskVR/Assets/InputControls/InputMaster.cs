//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/InputControls/InputMaster.inputactions
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

public partial class @InputMaster : IInputActionCollection2, IDisposable
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
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveSphere"",
                    ""type"": ""Value"",
                    ""id"": ""7762bf7b-b0d7-4f25-ad38-31663ddc3cc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""b65c3c23-7724-4dee-b1af-b0c56f07615f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae281d4e-9f79-4291-a368-68a1bbaf250b"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastRay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""960b8213-0626-42fe-8284-825afcb9e5d3"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""867a061b-4175-450d-b135-298ef20a9eac"",
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
                    ""id"": ""a36eaba4-4372-4427-bd85-3814edbb54f9"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a060075e-4bb7-4b51-98f8-57fe251ebe05"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""RopeCursor"",
            ""id"": ""4a9455b2-587d-41cb-b681-dce2359032c1"",
            ""actions"": [
                {
                    ""name"": ""CastRay"",
                    ""type"": ""Value"",
                    ""id"": ""7d450c6f-0f8d-4289-886e-ffb214512a81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveSphere"",
                    ""type"": ""Value"",
                    ""id"": ""b8e029d3-8c15-4281-af9b-10ca00682662"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""a334f505-bb64-474c-9cc0-aa172090d635"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""601b58bd-b780-4dd4-bef3-0f90cf337628"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastRay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14a50f4b-0241-4121-87cf-af9cf093fa13"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""72cdb3ec-25af-499c-89c5-4d6409c6ab6f"",
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
                    ""id"": ""3d2483a8-8157-4164-af9c-881ce80cedcf"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f6c46497-d629-4b14-9fb8-5c5f99d4791d"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""TouchPad"",
            ""id"": ""d0da20ae-d0c7-42aa-8b76-2a49d1d98f0a"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""11ef1abd-5d86-47ba-844e-9112e79febb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveTouch"",
                    ""type"": ""Value"",
                    ""id"": ""f91d8ca3-10e4-4d34-b436-fb04d3f5a664"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""710b156d-4a8b-455a-9173-ddbc7d733f16"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5eff482a-1bc6-4f93-a2b9-4c2b5a29032c"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SceneManager"",
            ""id"": ""7c702777-213b-43c6-89d0-171e4c19ec14"",
            ""actions"": [
                {
                    ""name"": ""Scene1"",
                    ""type"": ""Button"",
                    ""id"": ""9cfc1d98-f973-4750-820a-a67c628be407"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scene2"",
                    ""type"": ""Button"",
                    ""id"": ""eb811051-35a0-4524-9c55-3c3e7a9dc49a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scene3"",
                    ""type"": ""Button"",
                    ""id"": ""eee1fb03-f40a-49f6-bcb9-368d461d5f92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scene4"",
                    ""type"": ""Button"",
                    ""id"": ""355bf71c-be37-4184-9eb3-68579f336cd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scene5"",
                    ""type"": ""Button"",
                    ""id"": ""76a6d7dc-d53b-4314-bfe8-02a810621f2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1cfd578e-0c30-41c3-b633-f2379f5432d9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bf876a4-12af-4380-8449-3ea9e4ee2c31"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""502cdd9b-03a5-485c-9ec0-f75f0dc16fd8"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""828eafc4-0356-4b14-a5e9-78b0571fbb9b"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edd87bb1-1b80-4057-af05-f45c9488c58d"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        m_DepthRay_Confirm = m_DepthRay.FindAction("Confirm", throwIfNotFound: true);
        // RopeCursor
        m_RopeCursor = asset.FindActionMap("RopeCursor", throwIfNotFound: true);
        m_RopeCursor_CastRay = m_RopeCursor.FindAction("CastRay", throwIfNotFound: true);
        m_RopeCursor_MoveSphere = m_RopeCursor.FindAction("MoveSphere", throwIfNotFound: true);
        m_RopeCursor_Confirm = m_RopeCursor.FindAction("Confirm", throwIfNotFound: true);
        // TouchPad
        m_TouchPad = asset.FindActionMap("TouchPad", throwIfNotFound: true);
        m_TouchPad_Touch = m_TouchPad.FindAction("Touch", throwIfNotFound: true);
        m_TouchPad_MoveTouch = m_TouchPad.FindAction("MoveTouch", throwIfNotFound: true);
        // SceneManager
        m_SceneManager = asset.FindActionMap("SceneManager", throwIfNotFound: true);
        m_SceneManager_Scene1 = m_SceneManager.FindAction("Scene1", throwIfNotFound: true);
        m_SceneManager_Scene2 = m_SceneManager.FindAction("Scene2", throwIfNotFound: true);
        m_SceneManager_Scene3 = m_SceneManager.FindAction("Scene3", throwIfNotFound: true);
        m_SceneManager_Scene4 = m_SceneManager.FindAction("Scene4", throwIfNotFound: true);
        m_SceneManager_Scene5 = m_SceneManager.FindAction("Scene5", throwIfNotFound: true);
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

    // DepthRay
    private readonly InputActionMap m_DepthRay;
    private IDepthRayActions m_DepthRayActionsCallbackInterface;
    private readonly InputAction m_DepthRay_CastRay;
    private readonly InputAction m_DepthRay_MoveSphere;
    private readonly InputAction m_DepthRay_Confirm;
    public struct DepthRayActions
    {
        private @InputMaster m_Wrapper;
        public DepthRayActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastRay => m_Wrapper.m_DepthRay_CastRay;
        public InputAction @MoveSphere => m_Wrapper.m_DepthRay_MoveSphere;
        public InputAction @Confirm => m_Wrapper.m_DepthRay_Confirm;
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
                @Confirm.started -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_DepthRayActionsCallbackInterface.OnConfirm;
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
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public DepthRayActions @DepthRay => new DepthRayActions(this);

    // RopeCursor
    private readonly InputActionMap m_RopeCursor;
    private IRopeCursorActions m_RopeCursorActionsCallbackInterface;
    private readonly InputAction m_RopeCursor_CastRay;
    private readonly InputAction m_RopeCursor_MoveSphere;
    private readonly InputAction m_RopeCursor_Confirm;
    public struct RopeCursorActions
    {
        private @InputMaster m_Wrapper;
        public RopeCursorActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastRay => m_Wrapper.m_RopeCursor_CastRay;
        public InputAction @MoveSphere => m_Wrapper.m_RopeCursor_MoveSphere;
        public InputAction @Confirm => m_Wrapper.m_RopeCursor_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_RopeCursor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RopeCursorActions set) { return set.Get(); }
        public void SetCallbacks(IRopeCursorActions instance)
        {
            if (m_Wrapper.m_RopeCursorActionsCallbackInterface != null)
            {
                @CastRay.started -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnCastRay;
                @CastRay.performed -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnCastRay;
                @CastRay.canceled -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnCastRay;
                @MoveSphere.started -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnMoveSphere;
                @MoveSphere.performed -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnMoveSphere;
                @MoveSphere.canceled -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnMoveSphere;
                @Confirm.started -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_RopeCursorActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_RopeCursorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CastRay.started += instance.OnCastRay;
                @CastRay.performed += instance.OnCastRay;
                @CastRay.canceled += instance.OnCastRay;
                @MoveSphere.started += instance.OnMoveSphere;
                @MoveSphere.performed += instance.OnMoveSphere;
                @MoveSphere.canceled += instance.OnMoveSphere;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public RopeCursorActions @RopeCursor => new RopeCursorActions(this);

    // TouchPad
    private readonly InputActionMap m_TouchPad;
    private ITouchPadActions m_TouchPadActionsCallbackInterface;
    private readonly InputAction m_TouchPad_Touch;
    private readonly InputAction m_TouchPad_MoveTouch;
    public struct TouchPadActions
    {
        private @InputMaster m_Wrapper;
        public TouchPadActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_TouchPad_Touch;
        public InputAction @MoveTouch => m_Wrapper.m_TouchPad_MoveTouch;
        public InputActionMap Get() { return m_Wrapper.m_TouchPad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchPadActions set) { return set.Get(); }
        public void SetCallbacks(ITouchPadActions instance)
        {
            if (m_Wrapper.m_TouchPadActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_TouchPadActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_TouchPadActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_TouchPadActionsCallbackInterface.OnTouch;
                @MoveTouch.started -= m_Wrapper.m_TouchPadActionsCallbackInterface.OnMoveTouch;
                @MoveTouch.performed -= m_Wrapper.m_TouchPadActionsCallbackInterface.OnMoveTouch;
                @MoveTouch.canceled -= m_Wrapper.m_TouchPadActionsCallbackInterface.OnMoveTouch;
            }
            m_Wrapper.m_TouchPadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @MoveTouch.started += instance.OnMoveTouch;
                @MoveTouch.performed += instance.OnMoveTouch;
                @MoveTouch.canceled += instance.OnMoveTouch;
            }
        }
    }
    public TouchPadActions @TouchPad => new TouchPadActions(this);

    // SceneManager
    private readonly InputActionMap m_SceneManager;
    private ISceneManagerActions m_SceneManagerActionsCallbackInterface;
    private readonly InputAction m_SceneManager_Scene1;
    private readonly InputAction m_SceneManager_Scene2;
    private readonly InputAction m_SceneManager_Scene3;
    private readonly InputAction m_SceneManager_Scene4;
    private readonly InputAction m_SceneManager_Scene5;
    public struct SceneManagerActions
    {
        private @InputMaster m_Wrapper;
        public SceneManagerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scene1 => m_Wrapper.m_SceneManager_Scene1;
        public InputAction @Scene2 => m_Wrapper.m_SceneManager_Scene2;
        public InputAction @Scene3 => m_Wrapper.m_SceneManager_Scene3;
        public InputAction @Scene4 => m_Wrapper.m_SceneManager_Scene4;
        public InputAction @Scene5 => m_Wrapper.m_SceneManager_Scene5;
        public InputActionMap Get() { return m_Wrapper.m_SceneManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SceneManagerActions set) { return set.Get(); }
        public void SetCallbacks(ISceneManagerActions instance)
        {
            if (m_Wrapper.m_SceneManagerActionsCallbackInterface != null)
            {
                @Scene1.started -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene1;
                @Scene1.performed -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene1;
                @Scene1.canceled -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene1;
                @Scene2.started -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene2;
                @Scene2.performed -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene2;
                @Scene2.canceled -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene2;
                @Scene3.started -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene3;
                @Scene3.performed -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene3;
                @Scene3.canceled -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene3;
                @Scene4.started -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene4;
                @Scene4.performed -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene4;
                @Scene4.canceled -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene4;
                @Scene5.started -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene5;
                @Scene5.performed -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene5;
                @Scene5.canceled -= m_Wrapper.m_SceneManagerActionsCallbackInterface.OnScene5;
            }
            m_Wrapper.m_SceneManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scene1.started += instance.OnScene1;
                @Scene1.performed += instance.OnScene1;
                @Scene1.canceled += instance.OnScene1;
                @Scene2.started += instance.OnScene2;
                @Scene2.performed += instance.OnScene2;
                @Scene2.canceled += instance.OnScene2;
                @Scene3.started += instance.OnScene3;
                @Scene3.performed += instance.OnScene3;
                @Scene3.canceled += instance.OnScene3;
                @Scene4.started += instance.OnScene4;
                @Scene4.performed += instance.OnScene4;
                @Scene4.canceled += instance.OnScene4;
                @Scene5.started += instance.OnScene5;
                @Scene5.performed += instance.OnScene5;
                @Scene5.canceled += instance.OnScene5;
            }
        }
    }
    public SceneManagerActions @SceneManager => new SceneManagerActions(this);
    public interface IDepthRayActions
    {
        void OnCastRay(InputAction.CallbackContext context);
        void OnMoveSphere(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
    public interface IRopeCursorActions
    {
        void OnCastRay(InputAction.CallbackContext context);
        void OnMoveSphere(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
    public interface ITouchPadActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnMoveTouch(InputAction.CallbackContext context);
    }
    public interface ISceneManagerActions
    {
        void OnScene1(InputAction.CallbackContext context);
        void OnScene2(InputAction.CallbackContext context);
        void OnScene3(InputAction.CallbackContext context);
        void OnScene4(InputAction.CallbackContext context);
        void OnScene5(InputAction.CallbackContext context);
    }
}
