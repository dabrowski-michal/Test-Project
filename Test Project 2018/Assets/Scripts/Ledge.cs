using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour {

    [SerializeField] protected GameObject movingPlatform;
    [SerializeField] protected GameObject player;


    //allows the ledge to move the player 
    protected void OnTriggerEnter()
    {
        player.transform.parent = movingPlatform.transform;
    }

    //detaches player from the ledge
    protected void OnTriggerExit()
    {
        player.transform.parent = null; 
    }
}
