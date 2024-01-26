using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance { get; private set; }

	private void Awake()
	{
		// If there is an Instance, and it's not me, delete myself.

		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}



	}

	public static float getPlayerMovement(bool getHorizontal, int playerNum)
	{
		switch (playerNum)
		{
			case 0: return GetPlayerOneMovement(getHorizontal);
			default: Debug.Log("PlayerNum not good"); return 0;
		}
	}

	private static float GetPlayerOneMovement(bool getHorizontal)
	{
		if (getHorizontal) return Input.GetAxisRaw("Horizontal");
		else return Input.GetAxisRaw("Vertical");
	}

}
