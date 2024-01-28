using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MultiplayerManager: MonoBehaviour
{
	[SerializeField] Canvas canvas;
	[SerializeField] GameObject canvasObj;

    public static MultiplayerManager multiplayerManager {  get; private set; }
	private int _playerCount = 1;

	[SerializeField] private Multiplay_SO _multi_SO;

	public List<GameObject> _players = new List<GameObject>();

	[SerializeField] private LayerMask[] _layersMasks;

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
			_players[i].transform.position = new Vector3(i * 3, 1, 0);
			_players[i].GetComponent<charaterManager>().UpdateIndex(i);
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
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 21 is cam2
		_players[1].transform.GetChild(1).gameObject.layer = 21;

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
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 22 is cam3
		_players[2].transform.GetChild(1).gameObject.layer = 22;

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
		GameObject canv = Instantiate(canvasObj);
		canvas = canv.GetComponent<Canvas>();
		canvas.worldCamera = cam;
		canvas.planeDistance = 0.101f;
		// layer 23 is cam4
		_players[3].transform.GetChild(1).gameObject.layer = 23;

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
}
