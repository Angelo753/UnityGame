﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int coins;
    public Text coinText;
    // Use this for initialization
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "Gifts: " + coins;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }
    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.gameObject.SetActive(true);
    }
    public void AddCoins(int numberOfCoins)
    {
        coins += numberOfCoins;
        coinText.text = "Gifts: " + coins;
    }
}