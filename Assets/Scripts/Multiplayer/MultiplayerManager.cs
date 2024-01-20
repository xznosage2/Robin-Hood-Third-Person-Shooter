using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager: MonoBehaviour
{
    public static MultiplayerManager multiplayerManager {  get; private set; }
	private int _playerCount = 1;


	private void Awake()
	{
		// If there is an instance, and it's not me, delete myself.

		if (multiplayerManager != null && multiplayerManager != this)
		{
			Destroy(this);
		}
		else
		{
			multiplayerManager = this;
		}
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.P))
		{
			Debug.Log("Player Count: " + _playerCount);
		}
	}



	#region player count

	public int GetPlayerCount()
	{
		return _playerCount;
	}

	public void SetPlayerCount(int amount)
	{
		if (amount <= 0)
		{
			_playerCount = 1;
		}
		else if (amount >= 5)
		{
			_playerCount = 4;
		}
		else
		{
			_playerCount = amount;
		}
	}
	#endregion

}
