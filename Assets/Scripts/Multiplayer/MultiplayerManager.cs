using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class MultiplayerManager: MonoBehaviour
{
	[SerializeField] Canvas canvas;
	[SerializeField] GameObject canvasObj;

    public static MultiplayerManager multiplayerManager {  get; private set; }
	private int _playerCount = 1;

	[SerializeField] private Multiplay_SO _multi_SO;

	public List<GameObject> _players = new List<GameObject>();

	[SerializeField] private LayerMask[] _layersMasks;

	[SerializeField] private PlayerInputManager _playerInputManager;
	private int _playerIndex = 0;

	[SerializeField] private Transform[] _spawnPoints;

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

		//Debug.Log("Muldiplayer game started, Players Connected: " + _multi_SO.playerCount);
		InputDevice[] controllers = getAllController();

		_playerInputManager.onPlayerJoined += swapPlayerIndex;

		for (int i = 0; i < _playerCount; i++)
		{
			if (i == 0)
			{
				_players.Add(_playerInputManager.JoinPlayer(0, 0, "Keyboard", InputSystem.devices[0]).gameObject);	
				//_players.Add(_playerInputManager.JoinPlayer(0, 0, "Gamepad", controllers[0]).gameObject);	

			}
			else if (i == 1)
			{
				_players.Add(_playerInputManager.JoinPlayer(1, 1, "Gamepad", controllers[0]).gameObject);
			}
			else if (i == 2)
			{
				_players.Add(_playerInputManager.JoinPlayer(2, 2, "Gamepad", controllers[1]).gameObject);
			}
			else
			{
				_players.Add(_playerInputManager.JoinPlayer(3, 3, "Gamepad", controllers[2]).gameObject);
			}
			

			_players[i].transform.position = _spawnPoints[i].position;
			_players[i].GetComponent<charaterManager>().UpdateIndex(i);
			//Debug.Log("Player " + i + " has been added"); 
			
		}

		setupPlayerCam();

		canvas = GetComponent<Canvas>();
	}

	private void swapPlayerIndex(PlayerInput input)
	{
		input.transform.GetChild(1).GetComponent<CinemachineInputProvider>().PlayerIndex = _playerIndex++;
	}

	private InputDevice[] getAllController()
	{
		InputDevice[] controller = new InputDevice[4];
		int controllerNum = 0;

		for (int i = 0; i < InputSystem.devices.Count; i++)
		{
			if (InputSystem.devices[i].name == "XInputControllerWindows" ||
				InputSystem.devices[i].name == "XInputControllerWindows1" ||
				InputSystem.devices[i].name == "XInputControllerWindows2" ||
					InputSystem.devices[i].name == "XInputControllerWindows3")
			{
				controller[controllerNum] = InputSystem.devices[i];
				controllerNum++;
			}
		}

		return controller;
	}

	private void Update()
	{
		
	}

	public GameObject[] GetPlayers()
	{
		return _players.ToArray();
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

	// bigger cam setup
	private void setupPlayerCam()
	{
		if (canvas == null)
		{
			return;
		}

		switch (_playerCount)
		{
			case 1:
				setupPlayerOneCam();
				break;
			case 2:
				setupPlayerOneCam();
				setupPlayerTwoCam();
				break;
			case 3:
				setupPlayerOneCam();
				setupPlayerTwoCam();
				setupPlayerThreeCam();
				break;
			case 4:
				setupPlayerOneCam();
				setupPlayerTwoCam();
				setupPlayerThreeCam();
				setupPlayerFourCam();
				
                break;
		}
	}

	private void setupPlayerOneCam()
	{
		Canvas canvas;
		Camera cam;
		Rect rect = new Rect();

		switch (_multi_SO.playerCount)
		{
			case 1: rect = new Rect(0, 0, 1, 1); break;
			case 2: rect = new Rect(0, 0.5f, 1, 0.5f); break;
			case 3: rect = new Rect(0, 0.5f, 0.5f, 0.5f); break;
			case 4: rect = new Rect(0, 0.5f, 0.5f, 0.5f); break;
		}

		cam = _players[0].transform.GetChild(2).GetComponent<Camera>();
		cam.rect = rect;
		cam.cullingMask = _layersMasks[0];
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 20 is cam1
		_players[0].transform.GetChild(0).gameObject.layer = 20;
		_players[0].GetComponent<UpgradeManager>().upgradeText = transform.GetChild(6).GetComponent<TMP_Text>();

		charaterManager charMan = _players[0].GetComponent<charaterManager>();

		charMan.scoreUI = canvas.transform.GetChild(4).GetComponent<TMP_Text>();
		charMan.healthUI = canvas.transform.GetChild(7).transform.GetChild(0).GetComponent<UnityEngine.UI.Slider>();
			
		setCanvasActive(1, canv);
	}

	private void setupPlayerTwoCam()
	{
		Canvas canvas;
		Camera cam;
		Rect rect = new Rect();

		switch (_multi_SO.playerCount)
		{
			case 2: rect = new Rect(0, 0, 1, 0.5f); break;
			case 3: rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f); break;
			case 4: rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f); break;
		}

		cam = _players[1].transform.GetChild(2).GetComponent<Camera>();
		cam.rect = rect;
		cam.cullingMask = _layersMasks[1];
		Destroy(cam.gameObject.GetComponent<AudioListener>());
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 21 is cam2
		_players[1].transform.GetChild(1).gameObject.layer = 21;
        _players[1].GetComponent<UpgradeManager>().upgradeText = transform.GetChild(6).GetComponent<TMP_Text>();

        charaterManager charMan = _players[1].GetComponent<charaterManager>();

		charMan.scoreUI = canvas.transform.GetChild(4).GetComponent<TMP_Text>();
		charMan.healthUI = canvas.transform.GetChild(7).transform.GetChild(0).GetComponent<UnityEngine.UI.Slider>();

		setCanvasActive(2, canv);

	}

	private void setupPlayerThreeCam()
	{
		Canvas canvas;
		Camera cam;
		Rect rect = new Rect();

		switch (_multi_SO.playerCount)
		{
			case 3: rect = new Rect(0.25f, 0, 0.5f, 0.5f); break;
			case 4: rect = new Rect(0, 0, 0.5f, 0.5f); break;
		}

		cam = _players[2].transform.GetChild(2).GetComponent<Camera>();
		cam.rect = rect;
		cam.cullingMask = _layersMasks[2];
		Destroy(cam.gameObject.GetComponent<AudioListener>());
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 22 is cam3
		_players[2].transform.GetChild(1).gameObject.layer = 22;
        _players[2].GetComponent<UpgradeManager>().upgradeText = transform.GetChild(6).GetComponent<TMP_Text>();

        charaterManager charMan = _players[2].GetComponent<charaterManager>();

		charMan.scoreUI = canvas.transform.GetChild(4).GetComponent<TMP_Text>();
		charMan.healthUI = canvas.transform.GetChild(7).transform.GetChild(0).GetComponent<UnityEngine.UI.Slider>();

		setCanvasActive(3, canv);
	}

	private void setupPlayerFourCam()
	{
		Canvas canvas;
		Camera cam;
		Rect rect = new Rect(0.5f, 0, 0.5f, 0.5f);

		cam = _players[3].transform.GetChild(2).GetComponent<Camera>();
		cam.rect = rect;
		cam.cullingMask = _layersMasks[3];
		Destroy(cam.gameObject.GetComponent<AudioListener>());
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 23 is cam4
		_players[3].transform.GetChild(1).gameObject.layer = 23;
        _players[3].GetComponent<UpgradeManager>().upgradeText = transform.GetChild(6).GetComponent<TMP_Text>();

        charaterManager charMan = _players[4].GetComponent<charaterManager>();

		charMan.scoreUI = canvas.transform.GetChild(4).GetComponent<TMP_Text>();
		charMan.healthUI = canvas.transform.GetChild(7).transform.GetChild(0).GetComponent<UnityEngine.UI.Slider>();

		setCanvasActive(4, canv);
	}

	private void setCanvasActive(int playerNum, GameObject canvas)
	{
		GameObject uiParent;
		switch (_multi_SO.playerCount)
		{
			case 1: uiParent = canvas.transform.GetChild(0).gameObject; uiParent.SetActive(true); break;
			case 2: uiParent = canvas.transform.GetChild(1).gameObject; uiParent.SetActive(true); break;
			case 3: uiParent = canvas.transform.GetChild(2).gameObject; uiParent.SetActive(true); break;
			case 4: uiParent = canvas.transform.GetChild(3).gameObject; uiParent.SetActive(true); break;
			default: uiParent = null; break;
		}

		// Future use case - Player will get their ui test to be bigger
		//switch (playerNum)
		//{
		//	case 1: uiParent.transform.GetChild(0).gameObject.SetActive(true); break;
		//	case 2: uiParent.transform.GetChild(1).gameObject.SetActive(true); break;
		//	case 3: uiParent.transform.GetChild(2).gameObject.SetActive(true); break;
		//	case 4: uiParent.transform.GetChild(3).gameObject.SetActive(true); break;
		//}

		canvas.transform.GetChild(4).gameObject.SetActive(true);
		canvas.transform.GetChild(5).gameObject.SetActive(true);
		canvas.transform.GetChild(6).gameObject.SetActive(true);
	}

	#endregion

	private void setISM()
	{
		for (int i = 0; i < _playerCount; i++)
		{
			InputDevice[] many = InputSystem.devices.ToArray();
			InputDevice device;
			PlayerInput pi;
			switch (i)
			{
				case 1:
					//gets the devices that connectedto the player
					InputDevice[] devices = { InputSystem.devices[0], InputSystem.devices[1] };
					//print(devices[0].name + ", " + devices[1].name);
					//device = InputUser.GetUnpairedInputDevices()[0];
					PlayerInput pio = _playerInputManager.JoinPlayer(1, 1, "Keyboard", devices);
					//PlayerInput pio = _playerInputManager.JoinPlayer(1, 1, "Gamepad", device);

					if (pio != null) _players.Add(pio.gameObject);
					else print("WTF why am I NULLLLL");
					break;
				case 0:
					//device = device = InputUser.GetUnpairedInputDevices()[1];
					//pi = _playerInputManager.JoinPlayer(1, 1, "Gamepad", device);
					device = InputSystem.devices[3];
					pi = _playerInputManager.JoinPlayer(0, 0, "Gamepad", device);
					if (pi == null) { Debug.Log("WTF"); return; }
					else _players.Add(pi.gameObject);
					break;
				case 2:
					device = InputSystem.devices[4];
					pi = _playerInputManager.JoinPlayer(2, 2, "Gamepad", device);
					_players.Add(pi.gameObject);
					break;
				case 3:
					device = InputSystem.devices[5];
					pi = _playerInputManager.JoinPlayer(3, 3, "MainScheme", device);
					_players.Add(pi.gameObject);
					break;
			}
		}
	}
}
