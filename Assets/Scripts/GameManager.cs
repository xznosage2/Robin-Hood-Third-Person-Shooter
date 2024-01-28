using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public MultiplayerManager multiplayer;

	[SerializeField] Transform[] spawnPoints;
	[SerializeField] GameObject Zombie;
	public MultiplayerManager MultiplayerManager;
	public GameObject[] Players = new GameObject[4];

	public int round = 1;
	public int spawnNumber = 5;
	public int liveEnemies = 0;

	public int totalEnemiesSpawned = 0;
	public int enemiesDefeated = 0;

	bool canSpawn = true;
	float spawnCoolDown = 0.5f;

	int numPlayer = 0;

	// Start is called before the first frame update

	public void Awake()
	{
		Players = MultiplayerManager.GetPlayers();
		for(int i = 0; i < Players.Count(); i++)
		{
			if (Players[i] != null)
			{
				numPlayer++;
			}
		}
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		SpawnEnemies();
	}

	public void SpawnEnemies()
	{
		if(totalEnemiesSpawned < spawnNumber && canSpawn == true)
		{
			Debug.Log("Spawned Enemy");
			int random = Random.Range(0, spawnPoints.Length);
			GameObject zom = Instantiate(Zombie, spawnPoints[random]);
			zom.GetComponent<charaterManager>().SetHealth(round);

			totalEnemiesSpawned += 1;
			canSpawn = false;
			Invoke(nameof(CoolDown), spawnCoolDown);
		}
	}

	public void CheckEndRound()
	{
		if (spawnNumber == totalEnemiesSpawned)
		{
			Debug.Log("Changed round");
			ChangeRound();
			spawnNumber *= 2;
			totalEnemiesSpawned = 0;
			SpawnEnemies();
		}
	}

	public void ChangeRound()
	{
		round += 1;
	}

	public void setPlayerPoint(int index)
	{
		Players[index].GetComponent<charaterManager>().updateScore(100);
	}

	public void EnemyDied(int index)
	{
		liveEnemies--;
		setPlayerPoint(index);
		CheckEndRound();
	}

	public void CoolDown()
	{
		canSpawn = true;
	}

	public void CheckGameOver()
	{
		if(numPlayer == 0)
		{
			SceneManager.LoadScene("GameOver");
		}
	}

	public void PlayerDied()
	{
		numPlayer--;
		CheckGameOver();
	}

}


