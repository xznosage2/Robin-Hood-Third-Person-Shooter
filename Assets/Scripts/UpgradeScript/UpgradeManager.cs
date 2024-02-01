using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeManager : MonoBehaviour
{
    public GameObject player;
    PlayerInput playerInput;
    public GameManager gManager;
    [SerializeField] TMP_Text upgradeText;
    public int upgradeCost = 1000;
    float timer;

    [SerializeField] TMP_Text tempUI;

    private void Awake()
    {
        playerInput = player.GetComponent<PlayerInput>();
        playerInput.actions["Upgrade"].started += upgrade;

        
    }

	private void Start()
	{
		gManager = player.GetComponent<charaterManager>().gameManager;
        upgradeText.text = "Points to Upgrade Weapons: " + upgradeCost;
	}


	public void upgrade(InputAction.CallbackContext context)
    {
        Debug.Log("Uppies");

        if (player.GetComponent<charaterManager>().getScore() >= upgradeCost)
        {
            player.GetComponent<Shoot>().UpgradeArrow();
            player.GetComponent<charaterManager>().updateScore(upgradeCost * -1);
            upgradeCost += 500;
            upgradeText.text = "Points to Upgrade Weapons: " + upgradeCost;
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
