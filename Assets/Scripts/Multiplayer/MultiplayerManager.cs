using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MultiplayerManager: MonoBehaviour
{
	[SerializeField] Canvas canvas;

    public static MultiplayerManager multiplayerManager {  get; private set; }
	private int _playerCount = 1;

	[SerializeField] private Multiplay_SO _multi_SO;

	private List<GameObject> _players = new List<GameObject>();

	private void Awake()
	{
		// If there is an multiplayerManager, and it's not me, delete myself.

		if (multiplayerManager != null && multiplayerManager != this)
		{
			Destroy(this);
		}
		else
		{
			multiplayerManager = this;
		}

		//stops the game from happening
		if (!_multi_SO.canStartGame) return;
		_playerCount = _multi_SO.playerCount;

		Debug.Log("Muldiplayer game started, Players Connected: " + _multi_SO.playerCount);

		for (int i = 0; i < _playerCount; i++)
		{
			_players.Add(Instantiate(_multi_SO.playerPrefab));
			_players[i].transform.position = new Vector3(i * 2, 0, 0);
			Debug.Log("Player " + i + " has been added");
			if (i != 0)
			{
				Destroy(_players[i].transform.GetChild(2).GetComponent<AudioListener>());
			}
		}

		setupPlayerCam();

		canvas = GetComponent<Canvas>();
	}

	private void Update()
	{
		
	}

	public void setGameOn()
	{
		_multi_SO.canStartGame = true;
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

		_multi_SO.playerCount = _playerCount;
	}
	#endregion

	#region Camera Setup

	private void setupPlayerCam()
	{
		if (canvas == null)
		{
			return;
		}

		Camera cam;
		switch (_playerCount)
		{
			case 1:
				cam = _players[0].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0, 0, 1, 1);
				canvas.worldCamera = cam;
				break;
			case 2:
				cam = _players[0].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0, 0.5f, 1, 0.5f);
                canvas.worldCamera = cam;
                cam = _players[1].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0, 0, 1, 0.5f);
                canvas.worldCamera = cam;
                break;
			case 3:
				cam = _players[0].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
				cam = _players[1].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
				cam = _players[2].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0.25f, 0, 0.5f, 0.5f);
                canvas.worldCamera = cam;
                break;
			case 4:
				cam = _players[0].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
				cam = _players[1].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
				cam = _players[2].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0, 0, 0.5f, 0.5f);
				cam = _players[3].transform.GetChild(2).GetComponent<Camera>();
				cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                canvas.worldCamera = cam;
                break;
		}
	}

	#endregion
}
