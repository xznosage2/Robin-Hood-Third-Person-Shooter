using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeManager : MonoBehaviour
{
    public GameObject player { get; set; }
    PlayerInput playerInput;

    private void Awake()
    {

        playerInput = player.GetComponent<PlayerInput>();
        playerInput.actions["Upgrade"].started+=upgrade;

    }


    public void upgrade(InputAction.CallbackContext context)
    {
        player.GetComponent<Shoot>().UpgradeArrow();
    }


}
