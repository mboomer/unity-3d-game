using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private bool lastLevel;
    [SerializeField] private TMPro.TextMeshProUGUI levelText;           // a variable of type TMPro.TextMeshProGUI

    private Goal goal;                                                  // Create variable of type goal, to access the required coins

    private int nextLevel;                                
    private int Coins;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Next Level is : " + nextLevel);
        nextLevel = level + 1;                                          // level by default is 0 as it wasnt assigned a value when it was defined   

        goal = FindObjectOfType<Goal>();
        Coins = goal.checkRequiredCoins();                              // get the required coins from the Goal object

        // value of level is taken from the UI value on the game object
        // level-0 is main-menu which doesnt have to display the level Text
        if (level > 0) {
            levelText.text = string.Format("Level-{0}\nCollect {1} Coins", level, Coins);
        }
            // Debug.Log(levelText);
    }

    public void LoadLevel(string levelName) {
            SceneManager.LoadScene(levelName);
    }
    // check if at the last level, if not...load the next scene, if yes...go to main menu or load level-1
    public void loadNextLevel ()
    {
        if (!lastLevel) {
            string sceneName = "Level-" + nextLevel;
            LoadLevel(sceneName);
        }
        else {
            LoadLevel("Main-Menu");                                     // at end of game go to main menu
        }
    }
    // if collision with enemy then reload the current level - this will be called by the player when a collision is detected so needs to be public
    public void reloadCurrentLevel() {
        LoadLevel("Level-" + level);
    }
    // this will quit the game
    public void Quit () {
        Application.Quit();
    }
}
