﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private GameObject menu;                                // create variable menu of type GameObject
    private Game game;                                      // create variable goal of type GameObject
    private int Coins;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        Coins = goal.checkRequiredCoins();                  // get the required coins from the Goal object

        menu = transform.GetChild(0).gameObject;            // first child of Game Menu is the panel
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            menu.SetActive(!menu.activeSelf);         // we can now enable / disable the menu panel
        }
    }
}
