using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance = null;
    private int score;
    private int coinsCollected;
    public GameObject[] coins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    public void coinCollected()
    {
        coinsCollected++;
        score = score + 100;
    }

    public void lap()
    {
        score = score + 1000;
        Follower.instance.increaseSpeed();

        // reload all coins
        foreach (GameObject coin in coins)
        {
            coin.GetComponent<Renderer>().enabled = true;
        }
    }
}
