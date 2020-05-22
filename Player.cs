using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;                  // this makes the private variables available to the UI
    [SerializeField] private Game game;                             // a game variable of type Game, which we created as part of Game.cs class
    [SerializeField] private int coins;                             // a variable of type int
    [SerializeField] private TMPro.TextMeshProUGUI coinText;        // a variable of type TMPro.TextMexhProGUI

    private bool jump;
    private Vector3 inputVector;
    private GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        sword      = transform.GetChild(0).gameObject;              // sword is thefirst child of the Player
        game       = FindObjectOfType<Game>();                      // find the Game class and assign to game object  
        playerBody = GetComponent<Rigidbody>();                     // access the Ridigbody component on the player    
    }

    // Update is called once per frame
    void Update()
    {
        // this speeds up the up/down left/right movement
        inputVector = new Vector3(Input.GetAxis("Horizontal") * 10f, playerBody.velocity.y, Input.GetAxis("Vertical") * 10f);
        
        // this makes the player object rotate to look in the direction it is moving
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));        
    
        if (Input.GetButtonDown("Jump")) {                  // has the jump button been pressed
            jump = true;                                    // check every frame if jump has been pressed
        }
        if (Input.GetButtonDown("Attack")) {                // has the attack button button been pressed
            PerformAttack();                                // display the sword
        }    
    }
    private void FixedUpdate() {
        // this is to ensure that update is only at 50 frames/sec
        playerBody.velocity = inputVector;

        if (jump && IsGrounded()) {                                                  // only jump if object is on the ground
            playerBody.AddForce(Vector3.up * 20f, ForceMode.Impulse);                // apply a single boost of force vertically
            jump = false;   
        }
    }
    bool IsGrounded () {                                                            // create a boolean method to check if object is on the ground
        float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.01f;      // distance from object center +  a little bit more
        Ray ray = new Ray(transform.position, Vector3.down);                        // create a ray downwards to edge of object
        return Physics.Raycast(ray, rayDistance);                                   // if something below object - return true
    }
    private void OnCollisionEnter(Collision collision)  {                          // passes a parameter of type Collision
            
        // print("OnCollision Entered : " + collision.gameObject.tag);

       if (collision.gameObject.CompareTag("Enemy")) {                            // is tag on object the Player collides with "Enemy"
          game.reloadCurrentLevel();                                              // reloadCurrentLevel is a public method on our Game class            
       }
   }
    private void OnTriggerEnter(Collider other) {                                   // collider is actualy on the object, so we dont need to specify gameObject
        // print("Trigger Entered : " + other.tag);

         switch (other.tag) {
            case "Coin" : 
                coins++;
                coinText.text = string.Format("Coins\n{0}", coins);
                Destroy(other.gameObject);
                break;
            case "Goal" : 
                // get the Object Goal and allow access to the public methods in Goal
                other.gameObject.GetComponent<Goal>().checkForCompletion(coins);
                break;
            default : 
                break;
        }
    }
    private void PerformAttack() {          
        if (!sword.activeSelf) {                    // if the sword isnt active when the attack key is pressed...the make it active
            sword.SetActive(true);
        }
    }
 }