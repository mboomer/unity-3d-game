using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float attackLength = 0.5f;                      // attack will last for half a second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                                                            // deltaTime is the length of time the last frame took
        attackLength -= Time.deltaTime;                     // count down from 0.5 sec on each frame update until reaches zero


        if (attackLength <= 0) {                            // when countdown reaches zero
            gameObject.SetActive(false);                    // sword is inactive...gameObect refers to sword, the object created from this class
            attackLength = .5f;                             // reset attack length again
        }
    }
    private void OnTriggerEnter(Collider collider) {        // if sword collides with an enemy the enemy is destroyed
    
        // Debug.Log("--- Collision with Sword ---");

        if (collider.CompareTag("Enemy")) {
            Destroy(collider.gameObject);
        }
    }
}
