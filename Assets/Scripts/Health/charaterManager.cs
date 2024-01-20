using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class charaterManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] Slider healthUI;

    [SerializeField]
    int health
    {
        get { return health; }
        set
        {
            health = value;
            healthUI.value = value;
            healthUI.maxValue = value;
        }
    }

    [SerializeField]
    int maxHealth
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value;
            healthUI.maxValue = value;
        }
    }
    [SerializeField]
    int score
    {

        get { return score; }
        set
        {
            score = value;
            scoreUI.text = value.ToString();
        }
    }

}

