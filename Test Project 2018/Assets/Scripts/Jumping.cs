using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : PlayerAbility{


	protected override void FixedUpdate () {

        //can jump when is grounded
        if (playerController.Grounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * playerController.JumpForce, ForceMode.Impulse);
            abilitySound.Play();
        }
    }
}
