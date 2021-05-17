using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text RingsCounter;
    public Text ScoreCounter;
    public Text LifeCounter;
    public Text TimeCounter;
    public GameManager Level;

    public void Reset()
    {
        
    }

    public void Start()
    {
        Level = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (Level == null)
        {
            enabled = false;
            return;
        }

        Level.OnValueChange.AddListener(UpdateRings);
        Level.OnValueChange.AddListener(UpdateScore);
        Level.OnValueChange.AddListener(UpdateLives);
    }

    public void Update()
    {
        UpdateAll();
    }

    public void UpdateAll()
    {
        UpdateRings();
        UpdateScore();
        UpdateTimer();
        UpdateLives();
    }

    public void UpdateRings()
    {
        RingsCounter.text = (Level.rings).ToString();
    }

    public void UpdateScore()
    {
        ScoreCounter.text = (Level.score).ToString();
    }

    public void UpdateTimer()
    {
        TimeCounter.text = (Level._time).ToString();
    }

    public void UpdateLives()
    {
        LifeCounter.text = (Level.life).ToString();
    }
}
