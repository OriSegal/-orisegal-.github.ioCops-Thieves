using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public Text Life;

    int MaxLives = 3;

    float lifeReplenishTime = 1800f;

    int _lives;
    public int lives
    {
        set
        {
            _lives = value;
            PlayerPrefs.SetInt("Lives", _lives);
        }
        get
        {
            return _lives;
        }
    }

    public double timerForLife;

    void Awake()
    {

        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetString("LifeUpdateTime", DateTime.Now.ToString());
        }
        lives = PlayerPrefs.GetInt("Lives", MaxLives);


        if (lives < MaxLives)
        {

            float timerToAdd = (float)(System.DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("LifeUpdateTime"))).TotalSeconds;

            UpdateLives(timerToAdd);
        }
    }
   
    void Update()
    {
        Life.text = lives.ToString();
        Debug.Log(lives);
        if(lives < MaxLives)
        {
            timerForLife += Time.deltaTime;
            if(timerForLife > lifeReplenishTime)
            {
                
                UpdateLives(timerForLife);
            }
        }
        
    }

    void UpdateLives(double timerToAdd)
    {
        if(lives < MaxLives)
        {
            int liveesToAdd = Mathf.FloorToInt((float)timerToAdd / lifeReplenishTime);
            timerForLife = (float)timerToAdd % lifeReplenishTime;
            lives += liveesToAdd;
            if(lives > MaxLives)
            {
                lives = MaxLives;
                timerForLife = 0;
            }
        }
        PlayerPrefs.SetString("LifeUpdateTime", DateTime.Now.ToString());
    }

    public void LostLife()
    {
        lives--;
    }

    public void GainLife()
    {
        lives++;
    }
}
