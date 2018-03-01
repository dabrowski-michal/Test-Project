using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all player abilities like: jump, crouch, flying...
public class PlayerAbility : MonoBehaviour {

    //protected fields required for every ability
    [SerializeField] protected AudioSource abilitySound;
    protected Rigidbody playerRigidbody;
    protected PlayerController playerController;

    
    protected void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    //derived classes will implement their own behaviors in Fixed Update
    protected virtual void FixedUpdate()
    {
        
    }

}
