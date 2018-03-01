using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    [SerializeField] private AudioSource jumpSound;
    private Rigidbody playerRigidbody;
    private PlayerController playerController;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }


    //moving player rigidbody in FixedUpdate
    private void FixedUpdate()
    {
        if (playerController.Grounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * playerController.JumpForce, ForceMode.Impulse);
            jumpSound.Play();
        }
    }
}
