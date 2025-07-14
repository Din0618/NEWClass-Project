using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpd : MonoBehaviour
{   // Refrence to the Player 
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
      //grab a refrence to a plater 
      player = GameObject.Find("lil dude").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other) 
    {
      // if the player collides with coin, increase points and increase 
      if (other.name == "lil dude")
      {
        player.coinCount++;
        Destroy(this.gameObject);
      }
    }
}  
