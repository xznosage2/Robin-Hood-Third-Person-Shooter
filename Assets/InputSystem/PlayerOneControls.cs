// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerOneControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerOneControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerOneControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerOneControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""23b102b8-89dc-4be4-b032-639d69f4b197"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""ab4fa947-1dfc-436f-8d43-7fe1017f5209"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""c6cc3e8f-397b-4266-a321-1418ff53ae47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""40795aed-00b7-436e-8a81-db1cade0c308"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""9a133db5-adef-4bab-877e-6ce5fb690f8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""893de260-ed53-475e-be11-77169bc48a5e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Upgrade"",
                    ""type"": ""Button"",
                    ""id"": ""c9574257-a8c3-4bc3-9900-a1b84f24482a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5dd7a10e-73e9-4908-ac97-cd6e4b0410b3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e6efbfd6-843a-4c6a-8a0d-999961877ec6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82de9d75-3deb-4eb9-b0b0-b69815cc33d1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""92c8b5b8-8f70-4d70-b957-8bb0f18eaea0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d8c7175f-8faa-415d-8be6-7e48c9f4f07a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""0b2baaf8-0e86-4dae-afbc-ec8f0ec38f02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dcb8115a-51cf-4bc2-9578-cca34f22fa23"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e24866c5-0116-4f38-b0b0-1cab8f369a3b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""17740732-5608-4018-afff-e42afacfef6d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a9208c51-c662-4dad-9735-8795ecdb05f2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7bfcfaf7-7473-4d32-a424-9874940f3f69"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1de61d8-4e70-49be-b273-d1e4d2f6be7f"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1dbe8a5-32f6-4850-a6b0-6c83da84ff09"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""132c413a-cc1d-4b7a-ab58-83f2dff2c121"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea619f4c-b87e-41c4-a790-af57446ee2a2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""444a1edd-29ac-4b54-8c47-d8e445f74b17"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e9130c0-e936-450b-b529-056729210732"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c50becad-e677-4961-b73b-5056265617d0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""441e34d7-9f3c-4487-ad2b-086b9df8d1b4"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0e5ded4-a218-4a1c-a259-2b898678213a"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5c0f4700-6e2f-408d-89ff-e346714917d9"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""95a36031-a9ca-41f1-855a-e17477a3a978"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cdd90d44-2e7d-4746-9747-8176020923a3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Upgrade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a9977dd-f92d-4a13-aa6d-f43fd2d6fb60"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Upgrade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Walk = m_Movement.FindAction("Walk", throwIfNotFound: true);
        m_Movement_Sprint = m_Movement.FindAction("Sprint", throwIfNotFound: true);
        m_Movement_Shoot = m_Movement.FindAction("Shoot", throwIfNotFound: true);
        m_Movement_Aim = m_Movement.FindAction("Aim", throwIfNotFound: true);
        m_Movement_MouseLook = m_Movement.FindAction("MouseLook", throwIfNotFound: true);
        m_Movement_Upgrade = m_Movement.FindAction("Upgrade", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Walk;
    private readonly InputAction m_Movement_Sprint;
    private readonly InputAction m_Movement_Shoot;
    private readonly InputAction m_Movement_Aim;
    private readonly InputAction m_Movement_MouseLook;
    private readonly InputAction m_Movement_Upgrade;
    public struct MovementActions
    {
        private @PlayerOneControls m_Wrapper;
        public MovementActions(@PlayerOneControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Movement_Walk;
        public InputAction @Sprint => m_Wrapper.m_Movement_Sprint;
        public InputAction @Shoot => m_Wrapper.m_Movement_Shoot;
        public InputAction @Aim => m_Wrapper.m_Movement_Aim;
        public InputAction @MouseLook => m_Wrapper.m_Movement_MouseLook;
        public InputAction @Upgrade => m_Wrapper.m_Movement_Upgrade;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalk;
                @Sprint.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Shoot.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAim;
                @MouseLook.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseLook;
                @Upgrade.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnUpgrade;
                @Upgrade.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnUpgrade;
                @Upgrade.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnUpgrade;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Upgrade.started += instance.OnUpgrade;
                @Upgrade.performed += instance.OnUpgrade;
                @Upgrade.canceled += instance.OnUpgrade;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnUpgrade(InputAction.CallbackContext context);
    }
}
