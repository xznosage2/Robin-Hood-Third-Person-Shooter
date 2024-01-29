using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeManager : MonoBehaviour
{
    public GameObject player { get; set; }
    PlayerInput playerInput;
    public GameManager gManager;
    int upgradeCost = 1000;
    float timer;

    [SerializeField] TMP_Text tempUI;

    private void Awake()
    {
        playerInput = player.GetComponent<PlayerInput>();
        playerInput.actions["Upgrade"].started += upgrade;
    }


    public void upgrade(InputAction.CallbackContext context)
    {
        if (player.GetComponent<charaterManager>().getScore() >= upgradeCost)
        {
            player.GetComponent<Shoot>().UpgradeArrow();
            player.GetComponent<charaterManager>().updateScore(upgradeCost * -1);
            upgradeCost += 500;
        }
        else if (tempUI != null)
        {
            timer = 3;
            timer -= Time.deltaTime;
            if (timer>=0)
            {
                tempUI.text = "Not enough score";
            }
            else
            {
                tempUI.text = "Press [U/Y] to upgrade. Score cost:"+upgradeCost;
            }
        }
    }


}
