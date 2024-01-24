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

	public void Awake()
	{
		if (healthUI != null)
		{
			healthUI.maxValue = MaxHealth;
		}
	}

	public void Update()
	{
		if(scoreUI != null)
        {
            scoreUI.text = score.ToString();
        }
        if(healthUI != null)
        {
            healthUI.value = health;
        }
	}

	public void TakeDamage(float damage)
	{
		health -= (int)damage;
        Debug.Log("damage taken: " + damage);
        if(health <= 0)
        {
            DestroyGameObject();
        }
	}
    
    public void SetHealth(int wave)
    {
        health = wave * 2;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}

