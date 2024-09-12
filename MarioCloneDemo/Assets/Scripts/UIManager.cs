using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI points;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] GameObject gameOver;

    private float currentPoints = 0;
    private float currentHealth = 100;
    private bool isGameOver = false;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void IncreaseScore(float newPoints)
    {
        currentPoints += newPoints;
        points.text = "Score: " + currentPoints;
    }

    public void DecreaseHealth(float damage)
    {
        currentHealth -= damage;
        health.text = "Health: " + currentHealth;
        if (currentHealth <= 0)
        {
           // Scene
        }
    }

    public void InitiateGameOver()
    {
        isGameOver = true;
        gameOver.SetActive(true);
    }
}
