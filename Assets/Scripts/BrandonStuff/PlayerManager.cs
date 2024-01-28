using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int numPlayers = 1;

    private GameObject[] players = new GameObject[5];

	public void Awake()
	{
        players[0] = GameObject.Find("Player1");
        players[0] = GameObject.Find("Player2");
        players[0] = GameObject.Find("Player3");
        players[0] = GameObject.Find("Player4");
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
