using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int requiredCoins;
    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        requiredCoins = GameObject.FindGameObjectsWithTag("Coin").Length;   // return an array of all objects with the tag "Coin"
    }
    public void checkForCompletion(int coinCount) {
        
        if (coinCount >= requiredCoins) {
            game.loadNextLevel();
        }
        else
        {
            // TODO: Need to stop player going off screen - there is no rigidBody on the component
            Debug.Log("You do not have enough coins!");
        }
    }
    public int checkRequiredCoins() {                                      // called by Game object to display no of coins required
        return GameObject.FindGameObjectsWithTag("Coin").Length;           // return an array of all objects with the tag "Coin"
    }
}
