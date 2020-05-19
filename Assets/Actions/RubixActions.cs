// GENERATED AUTOMATICALLY FROM 'Assets/Actions/RubixActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Rubix : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Rubix()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RubixActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""3aabd3db-640b-4bc8-9b2d-2c52c825556a"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""cf87789b-136a-4d74-9cc8-b00cbdc9bb5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""ec3db5d2-f04c-425b-8997-f52471555d0d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""OuterL"",
                    ""type"": ""Button"",
                    ""id"": ""ae5b5b8b-cae4-4a97-b7dd-7f1f10b4d482"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""OuterR"",
                    ""type"": ""Button"",
                    ""id"": ""f0bfe440-2844-4bea-a91d-b5a6eb8497f9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""OuterU"",
                    ""type"": ""Button"",
                    ""id"": ""c26ec892-9b3f-45cd-8459-a58b37d520ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""OuterF"",
                    ""type"": ""Button"",
                    ""id"": ""baa08c4a-0379-41a2-8c54-6d9edabe7161"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""OuterD"",
                    ""type"": ""Button"",
                    ""id"": ""a63a76c4-25f2-4a9e-9eea-559ec75a8e56"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""OuterB"",
                    ""type"": ""Button"",
                    ""id"": ""062a89a2-3d1e-4ec0-b870-d302719568df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""BothL"",
                    ""type"": ""Button"",
                    ""id"": ""c3e6a427-f758-4312-b3b8-1f369b505b21"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""BothR"",
                    ""type"": ""Button"",
                    ""id"": ""7854076d-a11f-4271-a133-6ad63164d1b8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""BothU"",
                    ""type"": ""Button"",
                    ""id"": ""90c845d9-8760-48fc-904e-51af76366331"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""BothD"",
                    ""type"": ""Button"",
                    ""id"": ""fe45b102-cac1-457d-aa70-baa850290896"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""BothF"",
                    ""type"": ""Button"",
                    ""id"": ""783786bd-0524-46aa-8be7-f837f9d0723e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""BothB"",
                    ""type"": ""Button"",
                    ""id"": ""0ed8bb1a-9a50-49db-ae36-b9b1e5fd9126"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InnerL"",
                    ""type"": ""Button"",
                    ""id"": ""2550e55a-30f0-4d94-972a-ac42de5cf41f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InnerR"",
                    ""type"": ""Button"",
                    ""id"": ""cd822229-ef5e-47de-b7f9-c4001dddb5f1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InnerU"",
                    ""type"": ""Button"",
                    ""id"": ""12c041a9-72ba-41e1-8867-821da66d6195"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InnerD"",
                    ""type"": ""Button"",
                    ""id"": ""e59f87b1-30ee-461d-90c7-d40957771d5c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InnerF"",
                    ""type"": ""Button"",
                    ""id"": ""93b7e54f-950b-42bb-a52c-fdb2d55738d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""InnerB"",
                    ""type"": ""Button"",
                    ""id"": ""59d3d1f3-0480-4a71-bfc7-e6cc0af7ddf6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""1cdae035-f1b0-4807-8176-88310a8b3fa6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MidLR"",
                    ""type"": ""Button"",
                    ""id"": ""4b5c5dc8-948c-48d3-9715-a988dd4ff56c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MidUD"",
                    ""type"": ""Button"",
                    ""id"": ""fd9cf6d5-26f0-4e02-a32c-1a4b2cc7aaad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MidFB"",
                    ""type"": ""Button"",
                    ""id"": ""aa5e3d08-59c7-4c41-8d06-255179a6d268"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""AllLR"",
                    ""type"": ""Button"",
                    ""id"": ""bb19e40a-4a5b-4e3e-97f1-72fb84ec4b62"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""AllUD"",
                    ""type"": ""Button"",
                    ""id"": ""4ecaa6b5-f4af-41d6-bf33-ddf9b87b6d18"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""AllFB"",
                    ""type"": ""Button"",
                    ""id"": ""2634f9b3-22f4-4022-b44b-f4f4ba83629e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Wheel"",
                    ""type"": ""Button"",
                    ""id"": ""577621ae-37ee-47a6-9617-74dad8e85e36"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad742599-c79d-4abf-a95d-b52f62d035e2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23360977-136d-47aa-8f41-0b87df3fecf8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6684c691-6f79-46eb-ae9e-84e72ac2c97a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OuterL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fa02e67-8e99-4fbf-a91f-31cd2b949cbf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8020024b-ed51-472e-bfa8-ff3f1332ffd9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InnerL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46696267-b121-4f52-8392-141f2e8a58cf"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OuterR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""943a934f-3698-4eac-bb92-3b909d5afb9d"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8c1aa48-bf92-40d3-9ce7-676221f433b8"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothU"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e82297e5-a65e-4d05-b8d5-1c7131fc18e3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InnerD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6de1257-d761-4602-92aa-b06a84b71eb5"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OuterU"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72f17de2-f7a7-4f1f-bd28-bcb0de775591"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OuterD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""440b5610-c6d7-43c7-8572-57bfca563d41"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2169bbb8-a216-4a11-9f15-c6983fad4f49"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InnerR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5237cc9-ca3c-4a66-a9ad-67cafc66132a"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InnerU"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dc83f4c-ec4e-455c-87b6-ef1975f2f463"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OuterF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e15c90ed-32c4-4044-ad66-e9895cff090f"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OuterB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39895cdb-026a-4fe8-bf71-ffa5a9015efd"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""595fbf9b-aa98-41cd-8772-9a1a0e684a1f"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b592202-bf51-48e8-810a-5d96f2fcb133"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InnerB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""559e1022-5cd1-412e-8fc5-9b2d19c6bf16"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InnerF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""247b7b55-f906-4818-81c6-9365fc2143f3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7c127a3-f8e0-41f6-9e7a-94927b8de8ae"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MidLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03d56806-3f0c-4b39-996e-f61052d05cf8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MidUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0097245e-48ba-4bbf-ace6-30652b4670cc"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MidFB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ce3881e-d336-49b1-af8b-1fb3d179e693"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AllLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02a37fbb-4a10-482b-9f2f-bfeeed0ca889"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AllUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59f63c3f-d822-41ef-8369-1646a600aa56"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AllFB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a71d0dc4-3d15-46b0-b6e0-9453a81fbef3"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Escape = m_Player.FindAction("Escape", throwIfNotFound: true);
        m_Player_OuterL = m_Player.FindAction("OuterL", throwIfNotFound: true);
        m_Player_OuterR = m_Player.FindAction("OuterR", throwIfNotFound: true);
        m_Player_OuterU = m_Player.FindAction("OuterU", throwIfNotFound: true);
        m_Player_OuterF = m_Player.FindAction("OuterF", throwIfNotFound: true);
        m_Player_OuterD = m_Player.FindAction("OuterD", throwIfNotFound: true);
        m_Player_OuterB = m_Player.FindAction("OuterB", throwIfNotFound: true);
        m_Player_BothL = m_Player.FindAction("BothL", throwIfNotFound: true);
        m_Player_BothR = m_Player.FindAction("BothR", throwIfNotFound: true);
        m_Player_BothU = m_Player.FindAction("BothU", throwIfNotFound: true);
        m_Player_BothD = m_Player.FindAction("BothD", throwIfNotFound: true);
        m_Player_BothF = m_Player.FindAction("BothF", throwIfNotFound: true);
        m_Player_BothB = m_Player.FindAction("BothB", throwIfNotFound: true);
        m_Player_InnerL = m_Player.FindAction("InnerL", throwIfNotFound: true);
        m_Player_InnerR = m_Player.FindAction("InnerR", throwIfNotFound: true);
        m_Player_InnerU = m_Player.FindAction("InnerU", throwIfNotFound: true);
        m_Player_InnerD = m_Player.FindAction("InnerD", throwIfNotFound: true);
        m_Player_InnerF = m_Player.FindAction("InnerF", throwIfNotFound: true);
        m_Player_InnerB = m_Player.FindAction("InnerB", throwIfNotFound: true);
        m_Player_Space = m_Player.FindAction("Space", throwIfNotFound: true);
        m_Player_MidLR = m_Player.FindAction("MidLR", throwIfNotFound: true);
        m_Player_MidUD = m_Player.FindAction("MidUD", throwIfNotFound: true);
        m_Player_MidFB = m_Player.FindAction("MidFB", throwIfNotFound: true);
        m_Player_AllLR = m_Player.FindAction("AllLR", throwIfNotFound: true);
        m_Player_AllUD = m_Player.FindAction("AllUD", throwIfNotFound: true);
        m_Player_AllFB = m_Player.FindAction("AllFB", throwIfNotFound: true);
        m_Player_Wheel = m_Player.FindAction("Wheel", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Escape;
    private readonly InputAction m_Player_OuterL;
    private readonly InputAction m_Player_OuterR;
    private readonly InputAction m_Player_OuterU;
    private readonly InputAction m_Player_OuterF;
    private readonly InputAction m_Player_OuterD;
    private readonly InputAction m_Player_OuterB;
    private readonly InputAction m_Player_BothL;
    private readonly InputAction m_Player_BothR;
    private readonly InputAction m_Player_BothU;
    private readonly InputAction m_Player_BothD;
    private readonly InputAction m_Player_BothF;
    private readonly InputAction m_Player_BothB;
    private readonly InputAction m_Player_InnerL;
    private readonly InputAction m_Player_InnerR;
    private readonly InputAction m_Player_InnerU;
    private readonly InputAction m_Player_InnerD;
    private readonly InputAction m_Player_InnerF;
    private readonly InputAction m_Player_InnerB;
    private readonly InputAction m_Player_Space;
    private readonly InputAction m_Player_MidLR;
    private readonly InputAction m_Player_MidUD;
    private readonly InputAction m_Player_MidFB;
    private readonly InputAction m_Player_AllLR;
    private readonly InputAction m_Player_AllUD;
    private readonly InputAction m_Player_AllFB;
    private readonly InputAction m_Player_Wheel;
    public struct PlayerActions
    {
        private @Rubix m_Wrapper;
        public PlayerActions(@Rubix wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Escape => m_Wrapper.m_Player_Escape;
        public InputAction @OuterL => m_Wrapper.m_Player_OuterL;
        public InputAction @OuterR => m_Wrapper.m_Player_OuterR;
        public InputAction @OuterU => m_Wrapper.m_Player_OuterU;
        public InputAction @OuterF => m_Wrapper.m_Player_OuterF;
        public InputAction @OuterD => m_Wrapper.m_Player_OuterD;
        public InputAction @OuterB => m_Wrapper.m_Player_OuterB;
        public InputAction @BothL => m_Wrapper.m_Player_BothL;
        public InputAction @BothR => m_Wrapper.m_Player_BothR;
        public InputAction @BothU => m_Wrapper.m_Player_BothU;
        public InputAction @BothD => m_Wrapper.m_Player_BothD;
        public InputAction @BothF => m_Wrapper.m_Player_BothF;
        public InputAction @BothB => m_Wrapper.m_Player_BothB;
        public InputAction @InnerL => m_Wrapper.m_Player_InnerL;
        public InputAction @InnerR => m_Wrapper.m_Player_InnerR;
        public InputAction @InnerU => m_Wrapper.m_Player_InnerU;
        public InputAction @InnerD => m_Wrapper.m_Player_InnerD;
        public InputAction @InnerF => m_Wrapper.m_Player_InnerF;
        public InputAction @InnerB => m_Wrapper.m_Player_InnerB;
        public InputAction @Space => m_Wrapper.m_Player_Space;
        public InputAction @MidLR => m_Wrapper.m_Player_MidLR;
        public InputAction @MidUD => m_Wrapper.m_Player_MidUD;
        public InputAction @MidFB => m_Wrapper.m_Player_MidFB;
        public InputAction @AllLR => m_Wrapper.m_Player_AllLR;
        public InputAction @AllUD => m_Wrapper.m_Player_AllUD;
        public InputAction @AllFB => m_Wrapper.m_Player_AllFB;
        public InputAction @Wheel => m_Wrapper.m_Player_Wheel;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Escape.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                @OuterL.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterL;
                @OuterL.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterL;
                @OuterL.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterL;
                @OuterR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterR;
                @OuterR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterR;
                @OuterR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterR;
                @OuterU.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterU;
                @OuterU.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterU;
                @OuterU.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterU;
                @OuterF.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterF;
                @OuterF.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterF;
                @OuterF.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterF;
                @OuterD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterD;
                @OuterD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterD;
                @OuterD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterD;
                @OuterB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterB;
                @OuterB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterB;
                @OuterB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuterB;
                @BothL.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothL;
                @BothL.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothL;
                @BothL.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothL;
                @BothR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothR;
                @BothR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothR;
                @BothR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothR;
                @BothU.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothU;
                @BothU.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothU;
                @BothU.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothU;
                @BothD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothD;
                @BothD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothD;
                @BothD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothD;
                @BothF.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothF;
                @BothF.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothF;
                @BothF.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothF;
                @BothB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothB;
                @BothB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothB;
                @BothB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBothB;
                @InnerL.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerL;
                @InnerL.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerL;
                @InnerL.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerL;
                @InnerR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerR;
                @InnerR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerR;
                @InnerR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerR;
                @InnerU.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerU;
                @InnerU.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerU;
                @InnerU.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerU;
                @InnerD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerD;
                @InnerD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerD;
                @InnerD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerD;
                @InnerF.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerF;
                @InnerF.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerF;
                @InnerF.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerF;
                @InnerB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerB;
                @InnerB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerB;
                @InnerB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInnerB;
                @Space.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpace;
                @MidLR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidLR;
                @MidLR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidLR;
                @MidLR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidLR;
                @MidUD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidUD;
                @MidUD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidUD;
                @MidUD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidUD;
                @MidFB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidFB;
                @MidFB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidFB;
                @MidFB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMidFB;
                @AllLR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllLR;
                @AllLR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllLR;
                @AllLR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllLR;
                @AllUD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllUD;
                @AllUD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllUD;
                @AllUD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllUD;
                @AllFB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllFB;
                @AllFB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllFB;
                @AllFB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAllFB;
                @Wheel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWheel;
                @Wheel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWheel;
                @Wheel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWheel;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @OuterL.started += instance.OnOuterL;
                @OuterL.performed += instance.OnOuterL;
                @OuterL.canceled += instance.OnOuterL;
                @OuterR.started += instance.OnOuterR;
                @OuterR.performed += instance.OnOuterR;
                @OuterR.canceled += instance.OnOuterR;
                @OuterU.started += instance.OnOuterU;
                @OuterU.performed += instance.OnOuterU;
                @OuterU.canceled += instance.OnOuterU;
                @OuterF.started += instance.OnOuterF;
                @OuterF.performed += instance.OnOuterF;
                @OuterF.canceled += instance.OnOuterF;
                @OuterD.started += instance.OnOuterD;
                @OuterD.performed += instance.OnOuterD;
                @OuterD.canceled += instance.OnOuterD;
                @OuterB.started += instance.OnOuterB;
                @OuterB.performed += instance.OnOuterB;
                @OuterB.canceled += instance.OnOuterB;
                @BothL.started += instance.OnBothL;
                @BothL.performed += instance.OnBothL;
                @BothL.canceled += instance.OnBothL;
                @BothR.started += instance.OnBothR;
                @BothR.performed += instance.OnBothR;
                @BothR.canceled += instance.OnBothR;
                @BothU.started += instance.OnBothU;
                @BothU.performed += instance.OnBothU;
                @BothU.canceled += instance.OnBothU;
                @BothD.started += instance.OnBothD;
                @BothD.performed += instance.OnBothD;
                @BothD.canceled += instance.OnBothD;
                @BothF.started += instance.OnBothF;
                @BothF.performed += instance.OnBothF;
                @BothF.canceled += instance.OnBothF;
                @BothB.started += instance.OnBothB;
                @BothB.performed += instance.OnBothB;
                @BothB.canceled += instance.OnBothB;
                @InnerL.started += instance.OnInnerL;
                @InnerL.performed += instance.OnInnerL;
                @InnerL.canceled += instance.OnInnerL;
                @InnerR.started += instance.OnInnerR;
                @InnerR.performed += instance.OnInnerR;
                @InnerR.canceled += instance.OnInnerR;
                @InnerU.started += instance.OnInnerU;
                @InnerU.performed += instance.OnInnerU;
                @InnerU.canceled += instance.OnInnerU;
                @InnerD.started += instance.OnInnerD;
                @InnerD.performed += instance.OnInnerD;
                @InnerD.canceled += instance.OnInnerD;
                @InnerF.started += instance.OnInnerF;
                @InnerF.performed += instance.OnInnerF;
                @InnerF.canceled += instance.OnInnerF;
                @InnerB.started += instance.OnInnerB;
                @InnerB.performed += instance.OnInnerB;
                @InnerB.canceled += instance.OnInnerB;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @MidLR.started += instance.OnMidLR;
                @MidLR.performed += instance.OnMidLR;
                @MidLR.canceled += instance.OnMidLR;
                @MidUD.started += instance.OnMidUD;
                @MidUD.performed += instance.OnMidUD;
                @MidUD.canceled += instance.OnMidUD;
                @MidFB.started += instance.OnMidFB;
                @MidFB.performed += instance.OnMidFB;
                @MidFB.canceled += instance.OnMidFB;
                @AllLR.started += instance.OnAllLR;
                @AllLR.performed += instance.OnAllLR;
                @AllLR.canceled += instance.OnAllLR;
                @AllUD.started += instance.OnAllUD;
                @AllUD.performed += instance.OnAllUD;
                @AllUD.canceled += instance.OnAllUD;
                @AllFB.started += instance.OnAllFB;
                @AllFB.performed += instance.OnAllFB;
                @AllFB.canceled += instance.OnAllFB;
                @Wheel.started += instance.OnWheel;
                @Wheel.performed += instance.OnWheel;
                @Wheel.canceled += instance.OnWheel;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
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
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnOuterL(InputAction.CallbackContext context);
        void OnOuterR(InputAction.CallbackContext context);
        void OnOuterU(InputAction.CallbackContext context);
        void OnOuterF(InputAction.CallbackContext context);
        void OnOuterD(InputAction.CallbackContext context);
        void OnOuterB(InputAction.CallbackContext context);
        void OnBothL(InputAction.CallbackContext context);
        void OnBothR(InputAction.CallbackContext context);
        void OnBothU(InputAction.CallbackContext context);
        void OnBothD(InputAction.CallbackContext context);
        void OnBothF(InputAction.CallbackContext context);
        void OnBothB(InputAction.CallbackContext context);
        void OnInnerL(InputAction.CallbackContext context);
        void OnInnerR(InputAction.CallbackContext context);
        void OnInnerU(InputAction.CallbackContext context);
        void OnInnerD(InputAction.CallbackContext context);
        void OnInnerF(InputAction.CallbackContext context);
        void OnInnerB(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnMidLR(InputAction.CallbackContext context);
        void OnMidUD(InputAction.CallbackContext context);
        void OnMidFB(InputAction.CallbackContext context);
        void OnAllLR(InputAction.CallbackContext context);
        void OnAllUD(InputAction.CallbackContext context);
        void OnAllFB(InputAction.CallbackContext context);
        void OnWheel(InputAction.CallbackContext context);
    }
}
