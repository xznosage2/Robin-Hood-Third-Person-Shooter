using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Multiplayer_SO",menuName = "Multiplayer/multiPlayerData")]
public class Multiplay_SO : ScriptableObject
{
	public int playerCount = 1;
	public bool canStartGame = false;

	public GameObject playerPrefab;
}
