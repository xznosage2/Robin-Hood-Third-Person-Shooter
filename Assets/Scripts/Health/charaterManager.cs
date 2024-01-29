using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class charaterManager : MonoBehaviour, IDamagable
{
    [Header("UI")]
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] Slider healthUI;

    [SerializeField] public int health = 10;

    [SerializeField] public int MaxHealth = 100;

    [SerializeField] public int score = 0;

    public GameManager gameManager;

    public int playerIndex = 1;

    public void Awake()
    {
        if (healthUI != null)
        {
            healthUI.maxValue = MaxHealth;
        }
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (scoreUI != null)
        {
            scoreUI.text = score.ToString();
        }
        if (healthUI != null)
        {
            healthUI.value = health;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        Debug.Log("damage taken: " + damage);
        if (health <= 0)
        {
            DestroyGameObject();
        }
    }

    public void updateScore(int score)
    {
        this.score += score;
    }
    public int getScore()
    {
        return score;
    }


    public void SetHealth(int wave)
    {
        Debug.Log("Increased Health");
        health = (int)(wave * 1.05f);
    }

    public void DestroyGameObject()
    {
        if(gameObject.tag == "Player")
        {
            gameManager.PlayerDied();
        }
        Destroy(gameObject);
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void UpdateIndex(int num)
    {
        playerIndex = num;
    }
}

